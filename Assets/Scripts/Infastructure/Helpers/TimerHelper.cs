using System;
using System.Threading.Tasks;

namespace Asteroids
{
    internal class TimerHelper
    {
        public static async Task ExecuteAfterTimeAsync(float timeInSec, Action action)
        {
            await Task.Delay(TimeSpan.FromSeconds(timeInSec));
            action.Invoke();
        }
    }
}
