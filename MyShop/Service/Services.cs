using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Service
{
    public class Services
    {
        private static Dictionary<string, object> _services { get; set; } = new();

        public static void Register<TParent, TChild>()
        {
            var parentType = typeof(TParent);
            var childType = Activator.CreateInstance(typeof(TChild));
            _services.Add(parentType.Name, childType!);
        }

        public static TParent Get<TParent>()
        {
            var parentType = typeof(TParent);
            return (TParent)_services[parentType.Name];
        }
    }
}
