using System.Collections.Generic;
using System;
using System.Reflection;

namespace FactoryBot{
    public class Factory
    {
        public static DefinedFactory<T> Define<T>(Dictionary<string, object> instanceParams = default(Dictionary<string, object>))
        {
            return new DefinedFactory(instanceParams);
        }

        public static T Build<T>(Dictionary<string, object> instanceParams = default(Dictionary<string, object>))
        {
            Type t = typeof(T);
            T instance = (T)Activator.CreateInstance(t);
            FieldInfo[] fields = t.GetFields();
            foreach (KeyValuePair<string, object> p in instanceParams)
            {
                FieldInfo info = Array.Find(fields, (f) => f.Name == p.Key);
                info.SetValue(instance, p.Value);
            }
            return instance;
        }

        public static List<T> BuildList<T>(Dictionary<string, object> instanceParams = default(Dictionary<string, object>), int count = 1)
        {
            List<T> instanceList = new List<T>();
            for (int i = 0;i < count;++i)
            {
                T instance = Build<T>(instanceParams);
                instanceList.Add(instance);
            }
            return instanceList;
        }
    }
}
