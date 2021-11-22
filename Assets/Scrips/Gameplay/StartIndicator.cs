using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

namespace BWG
{
    public class StartIndicator : MonoBehaviour, IPointerClickHandler
    {
        public System.Action OnClick;

        private IRaycastProvider _raycastProvider;

        public void SetRaycastProvider(IRaycastProvider provider)
        {
            _raycastProvider = provider;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke();
        }


        private void Update()
        {
            RepositionSelf();
        }

        private void RepositionSelf()
        {
            if (_raycastProvider != null)
            {
                var pose = _raycastProvider.GetRaycastResult(new Vector3(0.5f, 0.5f, 0));
                if (pose.position != Vector3.zero)
                    transform.SetPositionAndRotation(pose.position, pose.rotation);
            }
        }

    }
}
