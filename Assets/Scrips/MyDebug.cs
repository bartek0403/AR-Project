using BWG.Network;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BWG
{
    public class MyDebug : MonoBehaviour
    {
        private async void Awake()
        {
            var provider = new DogFactsProvider();
            var task = await provider.GetDogFactUnity();
            Debug.Log(task.fact);
        }
    }
}
