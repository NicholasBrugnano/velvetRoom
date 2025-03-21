using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonEx
{
    class Singleton
    {
        private static Singleton _instance;

        private static readonly object _instanceLock = new object();
        private Singleton()
        {

        }

        public static Singleton GetInstance()
        {
            lock (_instanceLock)
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
            }
            return _instance;
        }
    }
}
