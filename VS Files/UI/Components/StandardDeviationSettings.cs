using System;
using System.Windows.Forms;
using System.Xml;

using LiveSplit.Model;

namespace LiveSplit.UI.Components
{
    public partial class StandardDeviationSettings : UserControl
    {
        public enum DecimalPrecision
        {
            Whole,
            Tenths,
            Hundredths
        }

        public enum TimeFormat
        {
            Seconds,      // Always show as "690s" 
            TimeFormat    // Show as "11:30" or "1:10:06"
        }

        // Add event to notify when settings change
        public event EventHandler SettingsChanged;

        // Main display options
        public bool ShowCurrentSplit { get; set; } = true;
        public bool ShowPreviousSplit { get; set; } = false;
        public bool Display2Rows { get; set; } = false;
        public DecimalPrecision Precision { get; set; } = DecimalPrecision.Hundredths;
        public TimeFormat AverageTimeFormat { get; set; } = TimeFormat.TimeFormat;

        // Current split extra data options
        public bool ShowCurrentSigma { get; set; } = false;
        public bool ShowCurrentAverage { get; set; } = false;
        public bool ShowCurrentCount { get; set; } = false;

        // Previous split extra data options
        public bool ShowPreviousSigma { get; set; } = false;
        public bool ShowPreviousAverage { get; set; } = false;
        public bool ShowPreviousCount { get; set; } = false;

        public LayoutMode Mode { get; set; }

        public StandardDeviationSettings()
        {
            InitializeComponent();

            // Set default precision and time format
            Precision = DecimalPrecision.Hundredths;
            AverageTimeFormat = TimeFormat.TimeFormat;
        }

        // Helper method to trigger settings changed event
        private void OnSettingsChanged()
        {
            SettingsChanged?.Invoke(this, EventArgs.Empty);
        }

        // Event handlers for main checkboxes
        private void chkShowCurrent_CheckedChanged(object sender, EventArgs e)
        {
            ShowCurrentSplit = chkShowCurrent.Checked;
            UpdateControls();
            OnSettingsChanged();
        }

        private void chkShowPrevious_CheckedChanged(object sender, EventArgs e)
        {
            ShowPreviousSplit = chkShowPrevious.Checked;
            UpdateControls();
            OnSettingsChanged();
        }

        private void chkDisplay2Rows_CheckedChanged(object sender, EventArgs e)
        {
            Display2Rows = chkDisplay2Rows.Checked;
            OnSettingsChanged();
        }

        // Event handlers for current split extra data
        private void chkCurrentSigma_CheckedChanged(object sender, EventArgs e)
        {
            ShowCurrentSigma = chkCurrentSigma.Checked;
            OnSettingsChanged();
        }

        private void chkCurrentAverage_CheckedChanged(object sender, EventArgs e)
        {
            ShowCurrentAverage = chkCurrentAverage.Checked;
            OnSettingsChanged();
        }

        private void chkCurrentCount_CheckedChanged(object sender, EventArgs e)
        {
            ShowCurrentCount = chkCurrentCount.Checked;
            OnSettingsChanged();
        }

        // Event handlers for previous split extra data
        private void chkPreviousSigma_CheckedChanged(object sender, EventArgs e)
        {
            ShowPreviousSigma = chkPreviousSigma.Checked;
            OnSettingsChanged();
        }

        private void chkPreviousAverage_CheckedChanged(object sender, EventArgs e)
        {
            ShowPreviousAverage = chkPreviousAverage.Checked;
            OnSettingsChanged();
        }

        private void chkPreviousCount_CheckedChanged(object sender, EventArgs e)
        {
            ShowPreviousCount = chkPreviousCount.Checked;
            OnSettingsChanged();
        }

        // Event handlers for decimal precision radio buttons
        private void rdoDecimalWhole_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDecimalWhole.Checked)
            {
                Precision = DecimalPrecision.Whole;
                OnSettingsChanged();
            }
        }

        private void rdoDecimalTenths_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDecimalTenths.Checked)
            {
                Precision = DecimalPrecision.Tenths;
                OnSettingsChanged();
            }
        }

        private void rdoDecimalHundredths_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDecimalHundredths.Checked)
            {
                Precision = DecimalPrecision.Hundredths;
                OnSettingsChanged();
            }
        }

        // Event handlers for time format radio buttons
        private void rdoTimeFormatSeconds_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTimeFormatSeconds.Checked)
            {
                AverageTimeFormat = TimeFormat.Seconds;
                OnSettingsChanged();
            }
        }

        private void rdoTimeFormatTime_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTimeFormatTime.Checked)
            {
                AverageTimeFormat = TimeFormat.TimeFormat;
                OnSettingsChanged();
            }
        }

        // Load event handler
        private void StandardDeviationSettings_Load(object sender, EventArgs e)
        {
            // Handle 2-row display based on layout mode
            if (Mode == LayoutMode.Horizontal)
            {
                chkDisplay2Rows.Enabled = false;
                chkDisplay2Rows.DataBindings.Clear();
                chkDisplay2Rows.Checked = true;
            }
            else
            {
                chkDisplay2Rows.Enabled = true;
                chkDisplay2Rows.DataBindings.Clear();
                chkDisplay2Rows.DataBindings.Add("Checked", this, "Display2Rows", false, DataSourceUpdateMode.OnPropertyChanged);
            }

            UpdateControlValues();
            UpdateControls();
        }

        // Helper methods
        private void UpdateControls()
        {
            // Enable/disable current split extra data options
            if (currentGroup != null)
            {
                chkCurrentSigma.Enabled = ShowCurrentSplit;
                chkCurrentAverage.Enabled = ShowCurrentSplit;
                chkCurrentCount.Enabled = ShowCurrentSplit;
            }

            // Enable/disable previous split extra data options
            if (previousGroup != null)
            {
                chkPreviousSigma.Enabled = ShowPreviousSplit;
                chkPreviousAverage.Enabled = ShowPreviousSplit;
                chkPreviousCount.Enabled = ShowPreviousSplit;
            }
        }

        private void UpdateControlValues()
        {
            // Update main checkboxes
            if (chkShowCurrent != null) chkShowCurrent.Checked = ShowCurrentSplit;
            if (chkShowPrevious != null) chkShowPrevious.Checked = ShowPreviousSplit;
            if (chkDisplay2Rows != null) chkDisplay2Rows.Checked = Display2Rows;

            // Update current split checkboxes
            if (chkCurrentSigma != null) chkCurrentSigma.Checked = ShowCurrentSigma;
            if (chkCurrentAverage != null) chkCurrentAverage.Checked = ShowCurrentAverage;
            if (chkCurrentCount != null) chkCurrentCount.Checked = ShowCurrentCount;

            // Update previous split checkboxes
            if (chkPreviousSigma != null) chkPreviousSigma.Checked = ShowPreviousSigma;
            if (chkPreviousAverage != null) chkPreviousAverage.Checked = ShowPreviousAverage;
            if (chkPreviousCount != null) chkPreviousCount.Checked = ShowPreviousCount;

            // Update decimal precision radio buttons
            if (rdoDecimalWhole != null) rdoDecimalWhole.Checked = (Precision == DecimalPrecision.Whole);
            if (rdoDecimalTenths != null) rdoDecimalTenths.Checked = (Precision == DecimalPrecision.Tenths);
            if (rdoDecimalHundredths != null) rdoDecimalHundredths.Checked = (Precision == DecimalPrecision.Hundredths);

            // Update time format radio buttons
            if (rdoTimeFormatSeconds != null) rdoTimeFormatSeconds.Checked = (AverageTimeFormat == TimeFormat.Seconds);
            if (rdoTimeFormatTime != null) rdoTimeFormatTime.Checked = (AverageTimeFormat == TimeFormat.TimeFormat);
        }

        // Settings save/load methods
        public XmlNode GetSettings(XmlDocument document)
        {
            var settingsNode = document.CreateElement("Settings");
            CreateSettingsNode(document, settingsNode);
            return settingsNode;
        }

        private int CreateSettingsNode(XmlDocument document, XmlElement parent)
        {
            return SettingsHelper.CreateSetting(document, parent, "Version", "1.0") ^
                SettingsHelper.CreateSetting(document, parent, "ShowCurrentSplit", ShowCurrentSplit) ^
                SettingsHelper.CreateSetting(document, parent, "ShowPreviousSplit", ShowPreviousSplit) ^
                SettingsHelper.CreateSetting(document, parent, "Display2Rows", Display2Rows) ^
                SettingsHelper.CreateSetting(document, parent, "Precision", Precision) ^
                SettingsHelper.CreateSetting(document, parent, "AverageTimeFormat", AverageTimeFormat) ^
                SettingsHelper.CreateSetting(document, parent, "ShowCurrentSigma", ShowCurrentSigma) ^
                SettingsHelper.CreateSetting(document, parent, "ShowCurrentAverage", ShowCurrentAverage) ^
                SettingsHelper.CreateSetting(document, parent, "ShowCurrentCount", ShowCurrentCount) ^
                SettingsHelper.CreateSetting(document, parent, "ShowPreviousSigma", ShowPreviousSigma) ^
                SettingsHelper.CreateSetting(document, parent, "ShowPreviousAverage", ShowPreviousAverage) ^
                SettingsHelper.CreateSetting(document, parent, "ShowPreviousCount", ShowPreviousCount);
        }

        public void SetSettings(XmlNode settings)
        {
            var element = (XmlElement)settings;

            ShowCurrentSplit = SettingsHelper.ParseBool(element["ShowCurrentSplit"], true);
            ShowPreviousSplit = SettingsHelper.ParseBool(element["ShowPreviousSplit"], false);
            Display2Rows = SettingsHelper.ParseBool(element["Display2Rows"], false);
            Precision = SettingsHelper.ParseEnum<DecimalPrecision>(element["Precision"]);
            AverageTimeFormat = SettingsHelper.ParseEnum<TimeFormat>(element["AverageTimeFormat"]);

            ShowCurrentSigma = SettingsHelper.ParseBool(element["ShowCurrentSigma"], false);
            ShowCurrentAverage = SettingsHelper.ParseBool(element["ShowCurrentAverage"], false);
            ShowCurrentCount = SettingsHelper.ParseBool(element["ShowCurrentCount"], false);

            ShowPreviousSigma = SettingsHelper.ParseBool(element["ShowPreviousSigma"], false);
            ShowPreviousAverage = SettingsHelper.ParseBool(element["ShowPreviousAverage"], false);
            ShowPreviousCount = SettingsHelper.ParseBool(element["ShowPreviousCount"], false);

            UpdateControlValues();
            UpdateControls();
        }

        public int GetSettingsHashCode()
        {
            return CreateSettingsNode(null, null);
        }

        private void mainLayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rdoTimeFormatSeconds_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void rdoTimeFormatTime_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}
