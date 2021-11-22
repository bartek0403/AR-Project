using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UniRx.Triggers;
using UniRx;

namespace BWG
{
    public class Character : MonoBehaviour
    {
        public ReactiveProperty<int> CollectedCollectibles { get; private set; }

        private ICharacterInputProvider _inputProvider;
        private IRaycastProvider _raycastProvider;
        private bool _groudFound;
        public void SetInputProvider(ICharacterInputProvider provider)
        {
            _inputProvider = provider;
        }

        public void SetRaycastProvider(IRaycastProvider provider)
        {
            _raycastProvider = provider;
        }


        private void Awake()
        {
            CollectedCollectibles = new ReactiveProperty<int>();

            // on trigger enter handle
            this.OnTriggerEnterAsObservable().Subscribe(x =>
            {
                var collectible = x.GetComponent<ICollectible>();
                if (collectible != null)
                {
                    collectible.Collect();
                    CollectedCollectibles.Value++;
                }
            });
        }

        // Update is called once per frame
        void Update()
        {
            if(!_groudFound)
                MoveCharacterToGround();
            UpdateTurn();
        }

        private void UpdateTurn()
        {
            if (_inputProvider != null)
            {
                if (_inputProvider.GetLeftDirection())
                {
                    transform.Rotate(Vector3.up, -90);
                }
                else if (_inputProvider.GetRightDirection())
                {
                    transform.Rotate(Vector3.up, 90);
                }
            }
        }

        private void MoveCharacterToGround()
        {
            if (_raycastProvider != null)
            {
                var characterPosOnScreen = _raycastProvider.GetPositionOnScreen(transform.position);
                var pose = _raycastProvider.GetRaycastResult(characterPosOnScreen);
                if (pose.position != Vector3.zero)
                {
                    Vector3 targetPosition = new Vector3(transform.position.x, pose.position.y, transform.position.z);
                    transform.position = targetPosition;
                    _groudFound = true;
                }
            }
        }

        private void OnDestroy()
        {
            _inputProvider = null;
        }
    }
}
