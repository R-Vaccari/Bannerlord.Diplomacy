﻿using TaleWorlds.CampaignSystem;

namespace Diplomacy.DiplomaticAction.NonAggressionPact
{
    internal sealed class NonAggressionPactScoringModel : AbstractScoringModel<NonAggressionPactScoringModel>
    {
        public NonAggressionPactScoringModel() : base(new NonAggressionPactScores()) { }

        public class NonAggressionPactScores : IScores
        {
            public int Base => 50;
            public int BelowMedianStrength => 50;
            public int HasCommonEnemy => 50;
            public int ExistingAllianceWithEnemy => -1000;
            public int ExistingAllianceWithNeutral => -50;
            public int Relationship => 50;
            public float Tendency => Settings.Instance!.NonAggressionPactTendency;
            public int NonAggressionPactWithEnemy => -20;
            public int NonAggressionPactWithNeutral => -10;
        }
    }
}
