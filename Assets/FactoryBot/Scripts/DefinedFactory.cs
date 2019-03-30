using System.Collections.Generic;

namespace FactoryBot{
    public class DefinedFactory<T>
    {
        private Dictionary<string, object> instanceParams = new Dictionary<string, object>();

        internal DefinedFactory(Dictionary<string, object> instanceParams){
            this.instanceParams = instanceParams;
        }

        public T Build(Dictionary<string, object> overrideParams = default(Dictionary<string, object>))
        {
            Dictionary<string, object> defiedParams = this.MergeDictionary(overrideParams);
            return Factory.Build<T>(defiedParams);
        }

        public List<T> BuildList(Dictionary<string, object> overrideParams = default(Dictionary<string, object>), int count = 1)
        {
            Dictionary<string, object> defiedParams = this.MergeDictionary(overrideParams);
            return Factory.BuildList<T>(defiedParams, count);
        }

        private Dictionary<string, object> MergeDictionary(Dictionary<string, object> overrideParams = default(Dictionary<string, object>)){
            Dictionary<string, object> overrideDictionary = new Dictionary<string, object>();
            if(overrideParams != null){
                overrideDictionary = overrideParams;
            }
            Dictionary<string, object> mergedInstanceParams = new Dictionary<string, object>(this.instanceParams);
            foreach (KeyValuePair<string, object> p in overrideDictionary)
            {
                if(mergedInstanceParams.ContainsKey(p.Key)){
                    mergedInstanceParams[p.Key] = p.Value;
                }else{
                    mergedInstanceParams.Add(p.Key, p.Value);
                }
            }
            return mergedInstanceParams;
        }
    }
}
