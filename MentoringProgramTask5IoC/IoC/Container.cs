using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MentoringProgramTask5IoC.IoC
{
    public class Container
    {
        public delegate object Creator(Container container);

        private readonly Dictionary<Type, Creator> _typeToCreator
            = new Dictionary<Type, Creator>();

        public Dictionary<string, Dictionary<string, Type>> Configuration { get; } =
            new Dictionary<string, Dictionary<string, Type>>();

        public void Register<T1, T2>() where T2 : new() => 
            _typeToCreator.Add(typeof(T1), delegate { return new T2(); });

        public void Register<T1, T2>(params object[] configuredParameters) => 
            _typeToCreator.Add(typeof(T1), delegate { return typeof(T2)
                .GetConstructor(configuredParameters.Select(_ => _.GetType()).ToArray())?
                .Invoke(configuredParameters); });

        public void Register<T1, T2>(params Type[] parameters) => 
            _typeToCreator.Add(typeof(T1), delegate { return typeof(T2)
                .GetConstructor(parameters)?
                .Invoke(parameters.Select(Create).ToArray()); });

        public void Register<T1, T2>(Dictionary<string, Type> propetrties) where T2 : new() => 
            _typeToCreator.Add(typeof(T1), delegate
            {
                var resultObj = new T2();
                var typeProperties = typeof(T2).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Where(_ => propetrties[_.Name] != null);
                foreach (var property in typeProperties)
                {
                    property.SetValue(resultObj, Create(propetrties[property.Name]));
                }

                return resultObj;
            });

        public T Create<T>() => (T)_typeToCreator[typeof(T)](this);

        private object Create(Type type) => _typeToCreator[type](this);
    }
}
