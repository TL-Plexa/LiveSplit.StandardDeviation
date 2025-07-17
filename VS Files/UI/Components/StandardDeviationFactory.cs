using LiveSplit.Model;
using System;
using LiveSplit.UI.Components;

[assembly: ComponentFactory(typeof(StandardDeviationFactory))]

namespace LiveSplit.UI.Components
{
    public class StandardDeviationFactory : IComponentFactory
    {
        public string ComponentName => "Standard Deviation";

        public string Description => "Displays standard deviation statistics for current and/or previous splits with configurable extra data.";

        public ComponentCategory Category => ComponentCategory.Information;

        public IComponent Create(LiveSplitState state) => new StandardDeviationComponent(state);

        public string UpdateName => ComponentName;

        public string UpdateURL => "";

        public string XMLURL => "";

        public Version Version => Version.Parse("1.0.0");
    }
}
