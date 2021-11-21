using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace BWG.Network
{
    public class BaseHttpClient
    {
        private ISerializer _serializer;


        public BaseHttpClient(ISerializer serializer)
        {
            _serializer = serializer;
        }

        public BaseHttpClient() { }


        public void SetSerializer(ISerializer serializer)
        {
            _serializer = serializer;
        }

        public async Task<T> Get<T>(string url)
        {
            if (_serializer == null)
                throw new MissingReferenceException("No serializer assigned");

            using UnityWebRequest request = UnityWebRequest.Get(url);
            UnityWebRequestAsyncOperation handler = request.SendWebRequest();
            while (!handler.isDone)
                await Task.Yield();

            switch (request.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                    Debug.LogError("Connection error");
                    break;
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError("Data processing error");
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError("Protocol error");
                    break;
            }

            return _serializer.Deserialize<T>(request.downloadHandler.text);
        }
    }
}
