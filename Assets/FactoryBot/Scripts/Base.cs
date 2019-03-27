using System.Collections.Generic;
using System;
using System.Reflection;

namespace FactoryBot{
    public class Factory
    {
        public static T Build<T>(Dictionary<string, object> param = default(Dictionary<string, object>))
        {
            Type t = typeof(T);
            T instance = (T)Activator.CreateInstance(t);
            FieldInfo[] fields = t.GetFields();
            foreach (KeyValuePair<string, object> p in param)
            {
                FieldInfo info = Array.Find(fields, (f) => f.Name == p.Key);
                info.SetValue(instance, p.Value);
            }
            return instance;
        }

        public static List<T> BuildList<T>(Dictionary<string, object> param = default(Dictionary<string, object>), int count = 1)
        {
            Type t = typeof(T);
            T instance = (T)Activator.CreateInstance(t);
            FieldInfo[] fields = t.GetFields();
            foreach (KeyValuePair<string, object> p in param)
            {
                FieldInfo info = Array.Find(fields, (f) => f.Name == p.Key);
                info.SetValue(instance, p.Value);
            }
            return instance;
        }
    }
}
