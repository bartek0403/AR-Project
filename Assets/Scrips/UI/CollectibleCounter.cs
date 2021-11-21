using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

namespace BWG.UI
{
    public class CollectibleCounter : MonoBehaviour
    {
        [SerializeField]
        private Text _counter;

        public void SetCharacter(Character character)
        {
            character.CollectedCollectibles.Subscribe(x => _counter.text = x.ToString());
        }
    }
}
