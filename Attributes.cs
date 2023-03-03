using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComposedWeaponPlanning
{
    public class RequiredAttribute: Attribute
    {
        public RequiredAttribute(int quantity=1)
        {
            Quantity = quantity;
        }

        public int Quantity { get; set; } = 1;
    }

    public class OptionalAttribute: Attribute
    {
        
    }
}