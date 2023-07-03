using UnityEngine.Networking;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

internal class ImageLoaderFromWeb
{
    const string URL = "http://data.ikppbb.com/test-task-unity-data/pics/";
    const string JPG = ".jpg";

    public static IEnumerator LoadImageFromWeb(GameObject go, int ID)
    {
        string url = URL + ID + JPG;
        UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url);

        yield return webRequest.SendWebRequest();

        if (webRequest.isDone == false)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            Texture texture = ((DownloadHandlerTexture)webRequest.downloadHandler).texture;
            go.GetComponent<Image>().sprite = Sprite.Create((Texture2D)texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
    }
}
