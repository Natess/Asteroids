using Newtonsoft.Json;
using System;

namespace Asteroids.Lesson6
{
    internal class MagFactory
    {
        internal static bool TryParse(string unit, out IUnit result)
        {
            result = null;
            try
            {
                var commonUnit = JsonConvert.DeserializeObject<RootUnit>(unit);
                if (commonUnit.Unit.Type == "mag")
                {
                    result = new MagUnit(commonUnit.Unit.Health);
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