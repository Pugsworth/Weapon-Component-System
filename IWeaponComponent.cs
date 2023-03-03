using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComposedWeaponPlanning
{
    public interface IWeaponComponent
    {
        public WeaponStats Stats { get; }
        public bool IsOptional { get; }
        public bool IsRequired { get; }

        public int Quantity { get; }
        public int MinQuantity { get; }
        public int MaxQuantity { get; }

        /**
          * Set which stats this component contributes to the weapon.
          */
        public bool SetStats(WeaponStats stats);
    }
}