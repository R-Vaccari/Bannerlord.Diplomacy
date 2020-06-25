﻿namespace DiplomacyFixes
{
    abstract class DiplomacyCost
    {
        public float Value { get; }

        public DiplomacyCost(float value)
        {
            this.Value = value;
        }

        public abstract void ApplyCost();
        public abstract bool CanPayCost();
    }
}
