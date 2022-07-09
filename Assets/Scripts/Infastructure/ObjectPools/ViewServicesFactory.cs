using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    internal class ViewServicesFactory
    {
        private static ViewServices _viewServices;

        internal static IViewServices Instance()
        {
            if (_viewServices == null)
                _viewServices = new ViewServices();
            return _viewServices;
        }
    }
}
