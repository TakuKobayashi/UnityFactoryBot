using System.Collections.Generic;
using System;
using System.Reflection;

public class FactoryBase{
    protected static T Factory<T>(Dictionary<string, object> param = default(Dictionary<string, object>)){
		Type t = typeof(T);
		T instance = (T) Activator.CreateInstance(t);
		FieldInfo[] fields = t.GetFields();
		foreach(KeyValuePair<string, object> p in param){
			FieldInfo info = Array.Find(fields, (f) => f.Name == p.Key);
			info.SetValue(instance, p.Value);
        }
		return instance;
	}
}