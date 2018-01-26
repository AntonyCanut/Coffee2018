using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Coffee2018.IOC
{
    public class Container
    {
        private static readonly Container _current = new Container();
        public static Container Current => _current;


        private static readonly Dictionary<Type, Func<object>> _map = new Dictionary<Type, Func<object>>();

        protected Container()
        {

        }

        private object CreateInstance(Type type)
        {
            object result;

            var constructors = type.GetTypeInfo().DeclaredConstructors;
            var constructor = constructors.FirstOrDefault();

            if (constructor == null)
                result = Activator.CreateInstance(type);
            else
            {
                var typeparameters = constructor.GetParameters();
                object[] parameters = new object[typeparameters.Length];
                for (int i = 0; i < parameters.Length; i++)
                    parameters[i] = Resolve(typeparameters[i].ParameterType);
                result = Activator.CreateInstance(type, parameters);
            }

            return result;
        }

        private T CreateInstance<T>()
        {
            return (T)CreateInstance(typeof(T));
        }

        public object Resolve(Type @interface)
        {
            var resolver = _map[@interface];
            return resolver();
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public void Register(Type @interface, Type implementation)
        {
            _map.Add(@interface, () => CreateInstance(implementation));
        }

        public void Register<TInferface, TImplementation>()
        {
            Register(typeof(TInferface), typeof(TImplementation));
        }

        public void Register(Type @interface, Func<object> resolver)
        {
            _map.Add(@interface, resolver);
        }

        public void Register<T>()
        {
            Register(typeof(T), typeof(T));
        }

        public void Register<T>(Func<object> resolver)
        {
            Register(typeof(T), resolver);
        }

        public void Clear()
        {
            _map.Clear();
        }

    }
}