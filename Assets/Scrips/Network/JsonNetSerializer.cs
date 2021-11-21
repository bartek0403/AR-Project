using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace BWG.Network
{
    public class JsonNetSerializer : ISerializer
    {
        public T Deserialize<T>(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                return JsonConvert.DeserializeObject<T>(s);
            }
            else
            {
                throw new System.Exception("Serializer input string cant be empty or null");
            }
        }
    }
}
