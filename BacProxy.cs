using System;
using System.Reflection;

namespace dn {
    public class BacProxy<T> : DispatchProxy {
        private T decorated;

        public static T CreateProxy(T decorated) {
            if (!decorated.GetType().Name.EndsWith("Bac")) {
                return decorated;
            }

            object proxy = Create<T, BacProxy<T>>();
            ((BacProxy<T>)proxy).init(decorated);
            return (T)proxy;
        }

        protected override object Invoke(MethodInfo targetMethod, object[] args) {
            if (targetMethod == null) {
                throw new ArgumentException(nameof(targetMethod));
            }

            object retval = null;

            if (targetMethod.Name.StartsWith("Insert") || targetMethod.Name.StartsWith("Update")) {
                Console.WriteLine("Creating Write Transaction");
            } else {
                Console.WriteLine("Creating Read Transaction");
            }

            try {
                retval = targetMethod.Invoke(decorated, args);
            } catch(Exception e) {
                Console.WriteLine("Rolling Back Transaction!");
                throw e;
            }
            
            Console.WriteLine("Committing Transaction");

            return retval;
        }

        private void init(T decorated) {
            this.decorated = decorated;
        }
    }
}
