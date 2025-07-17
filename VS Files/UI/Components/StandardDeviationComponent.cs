using LiveSplit.Model;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LiveSplit.UI.Components
{
    public class StandardDeviationComponent : IComponent
    {
        // Internal components for displaying current and previous split statistics
        protected List<InfoTextComponent> InternalComponents { get; set; }

        // Settings and state
        public StandardDeviationSettings Settings { get; set; }
        protected LiveSplitState CurrentState { get; set; }

        // Cached statistics data
        protected List<double> StandardDeviations { get; set; }
        protected List<double> AverageTimes { get; set; }
        protected List<List<double>> SplitTimesData { get; set; }

        // Current split statistics
        protected double CurrentSigmaFromMean { get; set; }
        protected double PreviousSigmaFromMean { get; set; }

        // Invalidation flags for performance
        protected bool StatisticsValid { get; set; }
        protected bool CurrentSplitValid { get; set; }
        private bool settingsSubscribed = false;

        public string ComponentName => "Standard Deviation";

        // Layout properties
        public float HorizontalWidth => InternalComponents.Count > 0 ? InternalComponents.Max(c => c.HorizontalWidth) : 0;
        public float MinimumWidth => InternalComponents.Count > 0 ? InternalComponents.Max(c => c.MinimumWidth) : 0;
        public float VerticalHeight => InternalComponents.Sum(c => c.VerticalHeight);
        public float MinimumHeight => InternalComponents.Sum(c => c.MinimumHeight);

        public float PaddingTop => InternalComponents.Count > 0 ? InternalComponents.First().PaddingTop : 0;
        public float PaddingLeft => InternalComponents.Count > 0 ? InternalComponents.Max(c => c.PaddingLeft) : 0;
        public float PaddingBottom => InternalComponents.Count > 0 ? InternalComponents.Last().PaddingBottom : 0;
        public float PaddingRight => InternalComponents.Count > 0 ? InternalComponents.Max(c => c.PaddingRight) : 0;

        public IDictionary<string, Action> ContextMenuControls => null;

        public StandardDeviationComponent(LiveSplitState state)
        {
            Settings = new StandardDeviationSettings();
            InternalComponents = new List<InfoTextComponent>();

            // Subscribe to state events
            state.OnStart += state_OnStart;
            state.OnSplit += state_OnSplitChange;
            state.OnSkipSplit += state_OnSplitChange;
            state.OnUndoSplit += state_OnSplitChange;
            state.OnReset += state_OnReset;
            CurrentState = state;

            StatisticsValid = false;
            CurrentSplitValid = false;

            UpdateInternalComponents();
        }

        private void UpdateInternalComponents()
        {
            InternalComponents.Clear();

            // Create components based on settings
            if (Settings.ShowCurrentSplit)
                InternalComponents.Add(new InfoTextComponent("Current Std Dev", ""));

            if (Settings.ShowPreviousSplit)
                InternalComponents.Add(new InfoTextComponent("Previous Std Dev", ""));

            // If nothing is enabled, show a placeholder
            if (InternalComponents.Count == 0)
                InternalComponents.Add(new InfoTextComponent("Std Dev", "No splits enabled"));
        }

        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
        {
            float currentY = 0;
            float componentHeight = height / Math.Max(InternalComponents.Count, 1);

            foreach (var component in InternalComponents)
            {
                component.NameLabel.HasShadow = component.ValueLabel.HasShadow = state.LayoutSettings.DropShadows;
                component.NameLabel.ForeColor = state.LayoutSettings.TextColor;
                component.ValueLabel.ForeColor = state.LayoutSettings.TextColor;

                var componentRegion = new Region(new RectangleF(0, currentY, float.MaxValue, componentHeight));
                componentRegion.Intersect(clipRegion);

                g.TranslateTransform(0, currentY);
                component.DrawHorizontal(g, state, componentHeight, componentRegion);
                g.TranslateTransform(0, -currentY);

                currentY += componentHeight;
            }
        }

        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
        {
            float currentY = 0;

            foreach (var component in InternalComponents)
            {
                component.DisplayTwoRows = Settings.Display2Rows;
                component.NameLabel.HasShadow = component.ValueLabel.HasShadow = state.LayoutSettings.DropShadows;
                component.NameLabel.ForeColor = state.LayoutSettings.TextColor;
                component.ValueLabel.ForeColor = state.LayoutSettings.TextColor;

                float componentHeight = component.VerticalHeight;
                var componentRegion = new Region(new RectangleF(0, currentY, width, componentHeight));
                componentRegion.Intersect(clipRegion);

                g.TranslateTransform(0, currentY);
                component.DrawVertical(g, state, width, componentRegion);
                g.TranslateTransform(0, -currentY);

                currentY += componentHeight;
            }
        }

        public Control GetSettingsControl(LayoutMode mode)
        {
            Settings.Mode = mode;

            // Subscribe to settings changes if not already subscribed
            if (!settingsSubscribed)
            {
                Settings.SettingsChanged += Settings_SettingsChanged;
                settingsSubscribed = true;
            }

            return Settings;
        }

        public System.Xml.XmlNode GetSettings(System.Xml.XmlDocument document)
        {
            return Settings.GetSettings(document);
        }

        public void SetSettings(System.Xml.XmlNode settings)
        {
            Settings.SetSettings(settings);
            UpdateInternalComponents();
            StatisticsValid = false;
            CurrentSplitValid = false;
        }

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            // Calculate statistics if needed
            if (!StatisticsValid)
            {
                StatisticsValid = true;
                CalculateStatistics(state);
                // Force sigma recalculation after statistics are updated
                CurrentSplitValid = false;
            }

            // Update current split data if needed OR always update sigma comparisons
            if (!CurrentSplitValid)
            {
                CurrentSplitValid = true;
                UpdateSigmaComparisons(state);
            }
            else
            {
                // Always recalculate Current Split sigma (PB comparison) since it doesn't depend on timer state
                UpdateCurrentSplitSigma(state);
            }

            // Update component displays
            UpdateComponentDisplays(state);

            // Update all internal components
            foreach (var component in InternalComponents)
            {
                component.Update(invalidator, state, width, height, mode);
            }
        }

        public void Dispose()
        {
            CurrentState.OnStart -= state_OnStart;
            CurrentState.OnSplit -= state_OnSplitChange;
            CurrentState.OnSkipSplit -= state_OnSplitChange;
            CurrentState.OnUndoSplit -= state_OnSplitChange;
            CurrentState.OnReset -= state_OnReset;

            // Unsubscribe from settings changes
            if (settingsSubscribed)
            {
                Settings.SettingsChanged -= Settings_SettingsChanged;
                settingsSubscribed = false;
            }
        }

        private void Settings_SettingsChanged(object sender, EventArgs e)
        {
            UpdateInternalComponents();
            StatisticsValid = false;
            CurrentSplitValid = false;
        }

        public int GetSettingsHashCode() => Settings.GetSettingsHashCode();

        // Event handlers
        void state_OnStart(object sender, EventArgs e)
        {
            StatisticsValid = false;
            CurrentSplitValid = false;
        }

        void state_OnSplitChange(object sender, EventArgs e)
        {
            CurrentSplitValid = false;
        }

        void state_OnReset(object sender, TimerPhase e)
        {
            StatisticsValid = false;  // Recalculate statistics on reset
            CurrentSplitValid = false;
        }

        // Statistics calculation methods
        private void CalculateStatistics(LiveSplitState state)
        {
            StandardDeviations = new List<double>();
            AverageTimes = new List<double>();
            SplitTimesData = new List<List<double>>();

            for (int i = 0; i < state.Run.Count; i++)
            {
                var segment = state.Run[i];
                var times = GetSplitTimes(segment, state, i);

                // Calculate standard deviation and average
                double stdDev = CalculateStandardDeviation(times);
                double average = times.Count > 0 ? times.Average() : 0;

                StandardDeviations.Add(stdDev);
                AverageTimes.Add(average);
                SplitTimesData.Add(new List<double>(times));
            }
        }

        private void UpdateSigmaComparisons(LiveSplitState state)
        {
            CurrentSigmaFromMean = 0;
            PreviousSigmaFromMean = 0;

            // Current Split Sigma: How does the PB for this split compare to historical distribution?
            UpdateCurrentSplitSigma(state);

            // Previous Split Sigma: How did the just-completed split perform vs historical?
            if (state.CurrentSplitIndex > 0)
            {
                int prevIndex = state.CurrentSplitIndex - 1;

                if (prevIndex < StandardDeviations.Count)
                {
                    // Get the actual segment time from the current run
                    double? actualSegmentTime = GetCurrentRunSegmentTime(state, prevIndex);

                    if (actualSegmentTime.HasValue)
                    {
                        double avgTime = AverageTimes[prevIndex];
                        double stdDev = StandardDeviations[prevIndex];

                        if (stdDev > 0)
                        {
                            PreviousSigmaFromMean = (actualSegmentTime.Value - avgTime) / stdDev;
                        }
                    }
                }
            }
        }

        private void UpdateCurrentSplitSigma(LiveSplitState state)
        {
            // Current Split Sigma: How does the PB segment time for this split compare to historical distribution?
            int currentIndex = Math.Max(0, state.CurrentSplitIndex);

            if (currentIndex < StandardDeviations.Count &&
                currentIndex < state.Run.Count &&
                StandardDeviations.Count > 0)
            {
                // Get the PB segment time (not cumulative split time)
                double? pbSegmentTime = GetPBSegmentTime(state, currentIndex);

                if (pbSegmentTime.HasValue && StandardDeviations.Count > currentIndex)
                {
                    double avgTime = AverageTimes[currentIndex];
                    double stdDev = StandardDeviations[currentIndex];

                    if (stdDev > 0)
                    {
                        CurrentSigmaFromMean = (pbSegmentTime.Value - avgTime) / stdDev;
                    }
                }
            }
        }

        private double? GetPBSegmentTime(LiveSplitState state, int segmentIndex)
        {
            if (segmentIndex >= state.Run.Count)
                return null;

            var segment = state.Run[segmentIndex];

            // Get the PB cumulative split time for this segment
            var pbCumulativeTime = segment.PersonalBestSplitTime.RealTime;

            if (!pbCumulativeTime.HasValue)
            {
                System.Diagnostics.Debug.WriteLine($"Segment {segmentIndex} has no PB split time");
                return null;
            }

            // For the first segment, segment time = cumulative time
            if (segmentIndex == 0)
            {
                double segmentTime = pbCumulativeTime.Value.TotalSeconds;
                System.Diagnostics.Debug.WriteLine($"Segment 0 PB time: {segmentTime}s");
                return segmentTime;
            }

            // For subsequent segments, subtract the previous cumulative time
            var prevSegment = state.Run[segmentIndex - 1];
            var prevPBCumulativeTime = prevSegment.PersonalBestSplitTime.RealTime;

            if (!prevPBCumulativeTime.HasValue)
            {
                System.Diagnostics.Debug.WriteLine($"Previous segment has no PB split time");
                return null;
            }

            // Calculate segment time: current cumulative - previous cumulative
            double calculatedSegmentTime = (pbCumulativeTime.Value - prevPBCumulativeTime.Value).TotalSeconds;

            System.Diagnostics.Debug.WriteLine($"Segment {segmentIndex} PB segment time: {calculatedSegmentTime}s");
            System.Diagnostics.Debug.WriteLine($"  (Current cumulative: {pbCumulativeTime.Value.TotalSeconds}s - Previous: {prevPBCumulativeTime.Value.TotalSeconds}s)");

            return calculatedSegmentTime;
        }

        private void UpdateComponentDisplays(LiveSplitState state)
        {
            int componentIndex = 0;

            if (Settings.ShowCurrentSplit && componentIndex < InternalComponents.Count)
            {
                var component = InternalComponents[componentIndex++];

                // Adaptive naming: use "Current SD" if both are shown, "Std Dev" if only one
                component.InformationName = (Settings.ShowCurrentSplit && Settings.ShowPreviousSplit) ? "Current SD" : "Std Dev";

                // Handle case where CurrentSplitIndex is -1 (timer not started) by defaulting to segment 0
                int currentIndex = Math.Max(0, state.CurrentSplitIndex);

                if (currentIndex < StandardDeviations.Count && StandardDeviations.Count > 0)
                {
                    double stdDev = StandardDeviations[currentIndex];
                    var times = SplitTimesData[currentIndex];

                    // Show PB sigma comparison for current split
                    component.InformationValue = FormatStandardDeviationDisplay(
                        stdDev,
                        times,
                        AverageTimes[currentIndex],
                        CurrentSigmaFromMean, // How does PB compare to historical distribution?
                        Settings.ShowCurrentSigma, // Show sigma for PB vs historical
                        Settings.ShowCurrentAverage,
                        Settings.ShowCurrentCount
                    );
                }
                else
                {
                    component.InformationValue = "No data";
                }
            }

            if (Settings.ShowPreviousSplit && componentIndex < InternalComponents.Count)
            {
                var component = InternalComponents[componentIndex++];

                // Adaptive naming: use "Previous SD" if both are shown, "Std Dev" if only one
                component.InformationName = (Settings.ShowCurrentSplit && Settings.ShowPreviousSplit) ? "Previous SD" : "Std Dev";

                // PREVIOUS SPLIT: Show live performance data for the split we just completed
                if (state.CurrentSplitIndex > 0)
                {
                    int prevIndex = state.CurrentSplitIndex - 1;
                    if (prevIndex < StandardDeviations.Count && StandardDeviations.Count > 0)
                    {
                        double stdDev = StandardDeviations[prevIndex];
                        var times = SplitTimesData[prevIndex];

                        // Previous split shows live performance vs historical
                        component.InformationValue = FormatStandardDeviationDisplay(
                            stdDev,
                            times,
                            AverageTimes[prevIndex],
                            PreviousSigmaFromMean, // Live comparison: how did we just perform?
                            Settings.ShowPreviousSigma, // Can show sigma for previous (live data)
                            Settings.ShowPreviousAverage,
                            Settings.ShowPreviousCount
                        );
                    }
                    else
                    {
                        component.InformationValue = "No data";
                    }
                }
                else
                {
                    component.InformationValue = "No previous";
                }
            }
        }

        private string FormatStandardDeviationDisplay(double stdDev, List<double> times, double average, double sigma,
            bool showSigma, bool showAverage, bool showCount)
        {
            var parts = new List<string>();

            // Base standard deviation with configurable precision and time format
            if (times.Count > 1)
            {
                parts.Add(FormatTime(stdDev, "std dev"));
            }
            else if (times.Count == 1)
            {
                parts.Add("0s");
            }
            else
            {
                return "No data";
            }

            // Build extra info in brackets
            var extraInfo = new List<string>();

            // Sigma comparison
            if (showSigma && Math.Abs(sigma) > 0.01)
            {
                string sign = sigma >= 0 ? "+" : "";
                extraInfo.Add($"{sign}{sigma:F1}σ");
            }

            // Average time with μ symbol and time formatting
            if (showAverage && times.Count > 0)
            {
                string formattedAverage = FormatTime(average, "average");
                extraInfo.Add($"μ={formattedAverage}");
            }

            // Count
            if (showCount)
            {
                extraInfo.Add($"n={times.Count}");
            }

            // Combine main value with extra info in brackets
            if (extraInfo.Count > 0)
            {
                parts.Add($"({string.Join(", ", extraInfo)})");
            }

            return string.Join(" ", parts);
        }

        private string FormatTime(double timeSeconds, string context)
        {
            // Check if user wants time format or always seconds
            if (Settings.AverageTimeFormat == StandardDeviationSettings.TimeFormat.TimeFormat)
            {
                // For time format mode, different thresholds based on context
                double threshold = (context == "std dev") ? 60 : 60; // Could make these different if needed

                if (timeSeconds >= threshold)
                {
                    int roundedSeconds = (int)Math.Round(timeSeconds);

                    // Convert to h:mm:ss format where appropriate
                    if (roundedSeconds >= 3600) // 1 hour or more
                    {
                        int hours = roundedSeconds / 3600;
                        int minutes = (roundedSeconds % 3600) / 60;
                        int seconds = roundedSeconds % 60;
                        return $"{hours}:{minutes:D2}:{seconds:D2}";
                    }
                    else // 1 minute or more (but less than 1 hour)
                    {
                        int minutes = roundedSeconds / 60;
                        int seconds = roundedSeconds % 60;
                        return $"{minutes}:{seconds:D2}";
                    }
                }
                else
                {
                    // Use user-defined precision for values under threshold
                    string format = Settings.Precision == StandardDeviationSettings.DecimalPrecision.Whole ? "F0" :
                                   Settings.Precision == StandardDeviationSettings.DecimalPrecision.Tenths ? "F1" : "F2";
                    return $"{timeSeconds.ToString(format)}s";
                }
            }
            else
            {
                // Always use seconds format with appropriate precision
                if (timeSeconds >= 100)
                {
                    // For large values, round to whole seconds regardless of user precision
                    return $"{Math.Round(timeSeconds):F0}s";
                }
                else
                {
                    // Use user-defined precision for smaller values
                    string format = Settings.Precision == StandardDeviationSettings.DecimalPrecision.Whole ? "F0" :
                                   Settings.Precision == StandardDeviationSettings.DecimalPrecision.Tenths ? "F1" : "F2";
                    return $"{timeSeconds.ToString(format)}s";
                }
            }
        }

        // Helper method to get split times with proper exclusion logic
        private List<double> GetSplitTimes(ISegment segment, LiveSplitState state, int index)
        {
            var times = new List<double>();

            if (segment.SegmentHistory == null)
                return times;

            // First segment: use all RealTime values directly
            if (index == 0)
            {
                foreach (var entry in segment.SegmentHistory)
                {
                    if (entry.Value.RealTime.HasValue)
                        times.Add(entry.Value.RealTime.Value.TotalSeconds);
                }
                return times;
            }

            var prevSegment = state.Run[index - 1];
            var prevHistory = prevSegment.SegmentHistory;

            foreach (var entry in segment.SegmentHistory)
            {
                var id = entry.Key;
                var curr = entry.Value;

                // Only include if:
                // - this split has a RealTime
                // - previous split has an entry for this ID AND also has a RealTime
                if (curr.RealTime.HasValue &&
                    prevHistory.TryGetValue(id, out var prev) &&
                    prev.RealTime.HasValue)
                {
                    times.Add(curr.RealTime.Value.TotalSeconds);
                }
            }

            return times;
        }

        // Calculate standard deviation using sample standard deviation
        private double CalculateStandardDeviation(List<double> values)
        {
            if (values.Count <= 1) return 0;

            double mean = values.Average();
            double sumOfSquaredDifferences = values.Sum(val => Math.Pow(val - mean, 2));
            double variance = sumOfSquaredDifferences / (values.Count - 1); // Sample standard deviation

            return Math.Sqrt(variance);
        }

        private double? GetCurrentRunSegmentTime(LiveSplitState state, int segmentIndex)
        {
            if (segmentIndex >= state.Run.Count)
                return null;

            var segment = state.Run[segmentIndex];
            var currentSplitTime = segment.SplitTime.RealTime;

            if (!currentSplitTime.HasValue)
                return null;

            // For the first segment, return the split time directly
            if (segmentIndex == 0)
            {
                return currentSplitTime.Value.TotalSeconds;
            }

            // For subsequent segments, we need the previous split to exist AND have a RealTime
            var prevSegment = state.Run[segmentIndex - 1];
            var prevSplitTime = prevSegment.SplitTime.RealTime;

            if (!prevSplitTime.HasValue)
            {
                return null;
            }

            // Both current and previous have RealTime, so calculate segment time
            var segmentTime = currentSplitTime.Value - prevSplitTime.Value;
            return segmentTime.TotalSeconds;
        }
    }
}
