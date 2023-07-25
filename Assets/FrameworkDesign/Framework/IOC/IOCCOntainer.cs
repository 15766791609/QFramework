using System;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign
{


    public class IOCCOntainer 
    {
        private Dictionary<Type, object> mInstances = new Dictionary<Type, object>();
        //×¢²áÊÂ¼þ
        public void Register<T> (T instance)
        {
            var key = typeof(T);
            if(mInstances.ContainsKey(key))
            {
                mInstances[key] = instance;
            }
            else
            {
                mInstances.Add(key, instance);
            }
        }

        public T Get<T>() where T:class
        {
            var key = typeof(T);
            if(mInstances.TryGetValue(key, out var retInstance))
            {
                return retInstance as T;
            }
            return null;
        }
    }
}