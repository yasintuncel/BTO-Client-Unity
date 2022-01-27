// created by yasintuncel
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace BattleTacticsOnline.Networking
{
    public static class ConstantFunctions
    {
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
