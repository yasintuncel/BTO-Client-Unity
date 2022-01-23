// created by yasintuncel
using BattleTacticsOnline.Networking.Http.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace BattleTacticsOnline.Networking.Http
{
    public class HttpRequest<T>
    {
        readonly string url;
        readonly IRequest<T> iRequest;
        readonly UnityWebRequest unityWebRequest;

        public HttpRequest(string url,
            Dictionary<string, string> postParams,
            Dictionary<string, string> headerParams,
            IRequest<T> iRequest)
        {
            this.url = url;
            this.iRequest = iRequest;

            unityWebRequest = UnityWebRequest.Post(this.url, postParams);
            foreach (var item in headerParams)
                unityWebRequest.SetRequestHeader(item.Key, item.Value);
            unityWebRequest.timeout = 10;
        }

        public IEnumerator Post()
        {
            yield return unityWebRequest.SendWebRequest();
            if (unityWebRequest.responseCode == 200)
            {
                //Debug.Log("Received: " + request.downloadHandler.text);
                var result = JsonUtility.FromJson<T>(unityWebRequest.downloadHandler.text);
                iRequest.OnRequestSuccess(result);
            }
            else
            {
                iRequest.OnRequestError(unityWebRequest.error);
            }
        }
    }
}
