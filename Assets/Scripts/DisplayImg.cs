using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayImg : MonoBehaviour
{
    public string imageUrl; // Set this in the Inspector
    public RawImage displayImage; // Set this in the Inspector
    public Texture2D defaultImage; //Default image to load if no image is found
    private void Start()
    {
        if (displayImage == null)
        {
            Debug.LogError("Display Image is not assigned.");
            
            return;
        }

        WEbConnect.Instance.DownloadImage(imageUrl, OnImageDownloaded);
    }

    private void OnImageDownloaded(Texture2D texture)
    {
        if (texture == null)
        {
            Debug.LogWarning("Failed to download image. Displaying Default image");
            displayImage.texture = defaultImage;
            return;
        }

        displayImage.texture = texture;
    }
}
