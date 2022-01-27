// created by yasintuncel
using BattleTacticsOnline.Networking.Http.Infrastructure;
using BattleTacticsOnline.Networking.Http.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace BattleTacticsOnline.Networking
{
    public static class ConstantFunctions
    {
        static IEnumerator Post<T>(HttpModel<T> model)
        {
            UnityWebRequest unityWebRequest = UnityWebRequest.Post(model.url, model.postParams);
            foreach (var item in model.headerParams)
                unityWebRequest.SetRequestHeader(item.Key, item.Value);
            unityWebRequest.timeout = 10;

            yield return unityWebRequest.SendWebRequest();
            if (unityWebRequest.responseCode == 200)
            {
                //Debug.Log("Received: " + request.downloadHandler.text);
                var result = JsonUtility.FromJson<T>(unityWebRequest.downloadHandler.text);
                model.iRequest.OnRequestSuccess(result);
            }
            else
            {
                model.iRequest.OnRequestError(unityWebRequest.error);
            }
        }

        public static async Task<Sprite> GetRemoteTexture(string url)
        {
            UnityWebRequest req = UnityWebRequestTexture.GetTexture(url);

            UnityWebRequestAsyncOperation op = req.SendWebRequest();

            while (op.isDone == false) await Task.Delay(100);

            if (req.result != UnityWebRequest.Result.Success)
            {
                return null;
            }

            Texture2D texture = DownloadHandlerTexture.GetContent(req);
            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(.5f, .5f));
        }
    }
}
