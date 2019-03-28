using System.Collections.Generic;
using System;
using System.Reflection;

namespace FactoryBot{
    public class DefinedFactory<T>
    {
        private Dictionary<string, object> instanceParams = new Dictionary<string, object>();

        internal DefinedFactory(Dictionary<string, object> instanceParams){
            this.instanceParams = instanceParams;
        }

        public T Build(Dictionary<string, object> overrideParams = default(Dictionary<string, object>))
        {
            this.instanceParams = this.MergeDictionary(overrideParams);
            return Factory.Build<T>(this.instanceParams);
        }

        public List<T> BuildList(Dictionary<string, object> instanceParams = default(Dictionary<string, object>), int count = 1)
        {
            this.instanceParams = this.MergeDictionary(overrideParams);
            return Factory.BuildList<T>(this.instanceParams, count);
        }

        private Dictionary<string, object> MergeDictionary(Dictionary<string, object> overrideParams = default(Dictionary<string, object>)){
            Dictionary<string, object> mergedInstanceParams = new Dictionary<string, object>(this.instanceParams);
            foreach (KeyValuePair<string, object> p in overrideParams)
            {
                if(mergedInstanceParams.ContainKey(p.Key)){
                    mergedInstanceParams[p.Key] = p.Value;
                }else{
                    mergedInstanceParams.Add(p.Key, p.Value);
                }
            }
            return mergedInstanceParams;
        }
    }
}
