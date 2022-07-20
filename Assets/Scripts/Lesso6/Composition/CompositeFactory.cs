using System;

namespace Asteroids.Lesson6
{
    internal class CompositeFactory
    {
        internal static IUnit UnitParse(string unit)
        {
            IUnit result;
            if (MagFactory.TryParse(unit, out result))
                return result;
            if (InfantryFactory.TryParse(unit, out result))
                return result;
            throw new ArgumentException($"Get incorrect value \"{unit}\"");
        }
    }


}