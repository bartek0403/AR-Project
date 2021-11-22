using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using BWG.UI;

namespace BWG
{
    public class GameManager : MonoBehaviour
    {
        static readonly int propsToSpawn = 5;

        [SerializeField]
        private StartIndicator _indicatorPrefab;
        [SerializeField]
        private GameObject _characterPrefab;
        [SerializeField]
        private GameObject[] _propPrefabs;
        [SerializeField]
        private CollectibleCounter _collectibleCounterPrefab;

        private StartIndicator _indicator;
        private CollectibleCounter _collectibleCounter;
        private IRaycastProvider _raycastProvider;

        public void SetRaycastProvider(IRaycastProvider provider)
        {
            _raycastProvider = provider;
        }

        public Character SpawnCharacter(Vector3 pos, Quaternion rot)
        {
            var character = Instantiate(_characterPrefab).GetComponent<Character>();
            character.transform.SetPositionAndRotation(pos, rot);
            if (_collectibleCounter == null)
                SpawnCollectibleCounter();
            _collectibleCounter.SetCharacter(character);
            // inject refference
            character.SetInputProvider(new TouchCharacterInputProvider());
            character.SetRaycastProvider(_raycastProvider);
            return character;
        }

        public GameObject SpawnProp(Vector3 pos, Quaternion rot)
        {
            var prop = Instantiate(_propPrefabs[UnityEngine.Random.Range(0, _propPrefabs.Length)]).GetComponent<FactDisplayCollectible>();
            prop.transform.SetPositionAndRotation(pos, rot);
            // inject refference
            prop.SetDisplayer(new DogFactDisplayer());
            return prop.gameObject;
        }

        public GameObject SpawnIndicator(Vector3 pos, Quaternion rot)
        {
            _indicator = Instantiate(_indicatorPrefab);
            _indicator.transform.SetPositionAndRotation(pos, rot);
            _indicator.GetComponent<StartIndicator>().SetRaycastProvider(_raycastProvider);
            return _indicator.gameObject;
        }

        public GameObject SpawnCollectibleCounter()
        {
            _collectibleCounter = Instantiate(_collectibleCounterPrefab);
            return _collectibleCounter.gameObject;
        }

        private void Awake()
        {
            // initialize raycaster, override for tests
            SetRaycastProvider(gameObject.AddComponent<ARRaycastProvider>());
            SpawnIndicator(transform.position, transform.rotation);
            _indicator.OnClick += SpawnCharacterAndProps;            
        }

        private void SpawnCharacterAndProps()
        {
            SpawnCharacter(_indicator.transform.position, _indicator.transform.rotation);

            int numOfSpawnedProps = 0;
            for (int i = 0; i < 100; i++)
            {
                if (numOfSpawnedProps >= propsToSpawn)
                    break;

                var pose = _raycastProvider.GetRaycastResult(new Vector3(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f)));
                if (pose.position != Vector3.zero)
                {
                    SpawnProp(pose.position, pose.rotation);
                    numOfSpawnedProps++;
                }
            }

            Destroy(_indicator.gameObject);
        }
    }
}
