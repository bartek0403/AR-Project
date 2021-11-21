using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace BWG
{
    public class ARRaycastProvider : MonoBehaviour, IRaycastProvider
    {
        private Camera _mainCamera;
        private ARRaycastManager _arRaycastManager;
        private List<ARRaycastHit> _buffer = new List<ARRaycastHit>();

        private void Awake()
        {
            _arRaycastManager = FindObjectOfType<ARRaycastManager>();
            _mainCamera = Camera.main;
        }

        public Pose GetRaycastResult(Vector3 origin)
        {
            _arRaycastManager.Raycast(origin, _buffer, UnityEngine.XR.ARSubsystems.TrackableType.All);
            if (_buffer.Count > 0)
            {
                return _buffer[0].pose;
            }
            return default;
        }

        public Vector2 GetPositionOnScreen(Vector3 worldPos)
        {
            return _mainCamera.WorldToViewportPoint(worldPos);
        }
    }
}
