using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using BWG.UI;

namespace BWG.Test
{
    public class DogFactzisplayTest
    {
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator CollectPropAndAssertFactIsShown()
        {
            yield return null;
            var result = SetupScene();
            result.prop.GetComponent<ICollectible>().Collect();
            yield return new WaitForSeconds(2f);
            Assert.IsNotEmpty(GameObject.FindObjectOfType<FactPresenter>().GetComponentInChildren<UnityEngine.UI.Text>().text);
        }

        [UnityTest]
        public IEnumerator SimulateClickAndAssertCharacterRotationChanged()
        {
            yield return null;
            var result = SetupScene();
            yield return null;
            var beforeRotation = result.character.transform.rotation;
            var inputProvider = new FakeCharacterInputProvider();
            inputProvider.SetFakeInput(true, false);
            result.character.GetComponent<Character>().SetInputProvider(inputProvider);
            yield return null;
            Assert.AreNotEqual(beforeRotation, result.character.transform.rotation);
        }

        private SceneSetupResult SetupScene()
        {
            var manager = GameObject.Instantiate(Resources.Load<GameManager>("GameManager"));
            manager.SetRaycastProvider(new FakeRaycastProvider());
            var prop = manager.SpawnProp(new Vector3(100, 100, 100), Quaternion.identity);
            var character = manager.SpawnCharacter(new Vector3(200, 200, 200), Quaternion.identity);
            return new SceneSetupResult { manager = manager, character = character.gameObject, prop = prop };
        }

        private struct SceneSetupResult
        {
            public GameManager manager;
            public GameObject character;
            public GameObject prop;
        }
    }
}
