using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BWG.UI
{
    public class FactPresenter : MonoBehaviour
    {
        [SerializeField]
        private Text _text;

        public void SetText(string text)
        {
            _text.text = text;
        }

        public void ScheduleLifetime(float time)
        {
            Destroy(gameObject, time);
        }
    }
}
