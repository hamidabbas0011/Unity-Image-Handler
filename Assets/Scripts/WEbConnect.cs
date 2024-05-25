using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class WEbConnect : MonoBehaviour
{
    public static WEbConnect Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DownloadImage(string url, System.Action<Texture2D> callback)
    {
        StartCoroutine(DownloadImageCoroutine(url, callback));
    }

    private IEnumerator DownloadImageCoroutine(string url, System.Action<Texture2D> callback)
    {
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(url))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Image download failed: " + request.error);
                callback(null);
            }
            else
            {
                Texture2D downloadedTexture = DownloadHandlerTexture.GetContent(request);
                callback(downloadedTexture);
            }
        }
    }
}
