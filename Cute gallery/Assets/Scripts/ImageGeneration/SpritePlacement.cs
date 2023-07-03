using UnityEngine;

public class SpritePlacement : MonoBehaviour
{
    private int _transferredImageID;

    private void Start()
    {
        ImageTransfer sceneController = FindObjectOfType<ImageTransfer>();

        _transferredImageID = sceneController.GetID();

        StartCoroutine(ImageLoaderFromWeb.LoadImageFromWeb(gameObject, _transferredImageID));
    }
}
