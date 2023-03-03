using System;
using System.Collections.Generic;

namespace ComposedWeaponPlanning
{
    using components;

    class ComposedWeapon
    {
        [Required] private WeaponBody body;
        [Required] private WeaponStock stock;
        [Required(1)] private List<WeaponBarrel> barrels;
        [Required] private WeaponGrip grip;
        [Required] private WeaponMagazine magazine;
        [Required] private WeaponOptic optic;
        [Optional] private WeaponUnderbarrel underbarrel;
    }
}