using System.Net;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.Threading.Tasks;

namespace BWG.Network
{
    public class DogFactsProvider : MonoBehaviour
    {
        [System.Obsolete("Use GetDogFactUnity()")]
        public static DogFact GetDogFact()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://dog-facts-api.herokuapp.com/api/v1/resources/dogs?number=1");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<List<DogFact>>(json)[0];

        }

        public async Task<DogFact> GetDogFactUnity()
        {
            var client = new BaseHttpClient();
            client.SetSerializer(new JsonNetSerializer());
            var facts = await client.Get<List<DogFact>>("https://dog-facts-api.herokuapp.com/api/v1/resources/dogs?number=1");
            return facts[0];
        }
    }
}
