﻿using TaleWorlds.GauntletUI;

namespace Diplomacy.Widgets
{
    class KingdomDiplomacyPanelTabControlWidget : ListPanel
    {
        private Widget _statsPanel;
        private Widget _overviewPanel;
        private ButtonWidget _overviewButton;
        private ButtonWidget _statsButton;

        public KingdomDiplomacyPanelTabControlWidget(UIContext context) : base(context)
        {
        }

        protected override void OnLateUpdate(float dt)
        {
            base.OnLateUpdate(dt);
            OverviewButton.IsSelected = OverviewPanel.IsVisible;
            StatsButton.IsSelected = StatsPanel.IsVisible;
        }

        [Editor(false)]
        public ButtonWidget OverviewButton
        {
            get
            {
                return _overviewButton;
            }
            set
            {
                if (_overviewButton != value)
                {
                    _overviewButton = value;
                    base.OnPropertyChanged(value, "OverviewButton");
                }
            }
        }

        [Editor(false)]
        public ButtonWidget StatsButton
        {
            get
            {
                return _statsButton;
            }
            set
            {
                if (_statsButton != value)
                {
                    _statsButton = value;
                    base.OnPropertyChanged(value, "StatsButton");
                }
            }
        }

        [Editor(false)]
        public Widget OverviewPanel
        {
            get
            {
                return _overviewPanel;
            }
            set
            {
                if (_overviewPanel != value)
                {
                    _overviewPanel = value;
                    base.OnPropertyChanged(value, "OverviewPanel");
                }
            }
        }

        [Editor(false)]
        public Widget StatsPanel
        {
            get
            {
                return _statsPanel;
            }
            set
            {
                if (_statsPanel != value)
                {
                    _statsPanel = value;
                    base.OnPropertyChanged(value, "StatsPanel");
                }
            }
        }
    }
}
