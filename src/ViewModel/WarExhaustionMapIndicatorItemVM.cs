﻿using Diplomacy.GauntletInterfaces;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Engine.Screens;
using TaleWorlds.Library;

namespace Diplomacy.ViewModel
{
    internal sealed class WarExhaustionMapIndicatorItemVM : TaleWorlds.Library.ViewModel
    {
        private readonly Kingdom _opposingKingdom;
        private bool _isCriticalFaction1;
        private bool _isCriticalFaction2;
        private int _playerWarExhaustion, _opponentWarExhaustion;

        [DataSourceProperty]
        public int OpponentWarExhaustion
        {
            get => _opponentWarExhaustion;
            set
            {
                if (value != _opponentWarExhaustion)
                {
                    _opponentWarExhaustion = value;
                    OnPropertyChanged(nameof(OpponentWarExhaustion));
                }
            }
        }

        [DataSourceProperty]
        public int PlayerWarExhaustion
        {
            get => _playerWarExhaustion;
            set
            {
                if (value != _playerWarExhaustion)
                {
                    _playerWarExhaustion = value;
                    OnPropertyChanged(nameof(PlayerWarExhaustion));
                }
            }
        }

        [DataSourceProperty] public ImageIdentifierVM Faction1Visual { get; set; } = null!;

        [DataSourceProperty] public ImageIdentifierVM Faction2Visual { get; set; } = null!;

        [DataSourceProperty]
        public bool IsCriticalFaction1
        {
            get => _isCriticalFaction1;
            set
            {
                if (value != _isCriticalFaction1)
                {
                    _isCriticalFaction1 = value;
                    OnPropertyChangedWithValue(value, nameof(IsCriticalFaction1));
                }
            }
        }

        [DataSourceProperty]
        public bool IsCriticalFaction2
        {
            get => _isCriticalFaction2;
            set
            {
                if (value != _isCriticalFaction2)
                {
                    _isCriticalFaction2 = value;
                    OnPropertyChangedWithValue(value, nameof(IsCriticalFaction2));
                }
            }
        }

        public WarExhaustionMapIndicatorItemVM(Kingdom opposingKingdom)
        {
            _opposingKingdom = opposingKingdom;
            RefreshValues();
        }

        public override void RefreshValues()
        {
            base.RefreshValues();
            var playerKingdom = Clan.PlayerClan.Kingdom;

            UpdateWarExhaustion();
            Faction1Visual = new ImageIdentifierVM(BannerCode.CreateFrom(playerKingdom.Banner), true);
            Faction2Visual = new ImageIdentifierVM(BannerCode.CreateFrom(_opposingKingdom.Banner), true);
        }

        public void UpdateWarExhaustion()
        {
            PlayerWarExhaustion = (int) WarExhaustionManager.Instance.GetWarExhaustion(Clan.PlayerClan.Kingdom, _opposingKingdom);
            OpponentWarExhaustion = (int) WarExhaustionManager.Instance.GetWarExhaustion(_opposingKingdom, Clan.PlayerClan.Kingdom);
            IsCriticalFaction1 = WarExhaustionManager.Instance.IsCriticalWarExhaustion(Clan.PlayerClan.Kingdom, _opposingKingdom);
            IsCriticalFaction2 = WarExhaustionManager.Instance.IsCriticalWarExhaustion(_opposingKingdom, Clan.PlayerClan.Kingdom);
        }

        [UsedImplicitly]
        private void OpenDetailedWarView()
        {
            new DetailWarViewInterface().ShowInterface(ScreenManager.TopScreen, _opposingKingdom);
        }
    }
}