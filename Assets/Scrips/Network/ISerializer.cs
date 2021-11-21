using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BWG.Network
{
    public interface ISerializer
    {
        //void Serialize(string s);
        T Deserialize<T>(string s);
    }
}
