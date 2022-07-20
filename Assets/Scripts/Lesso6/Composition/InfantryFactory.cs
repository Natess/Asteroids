using Newtonsoft.Json;
using System;

namespace Asteroids.Lesson6
{
    internal class InfantryFactory
    {
        internal static bool TryParse(string unit, out IUnit result)
        {
            result = null;
            try
            {
                var commonUnit = JsonConvert.DeserializeObject<RootUnit>(unit);
                if (commonUnit.Unit.Type == "infantry")
                {
                    result = new InfantryUnit(commonUnit.Unit.Health);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}