using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ImageButtonGenerator : MonoBehaviour
{
    private Button _imageButton;

    public Action OnButtonClicked;

    private void Awake()
    {
        _imageButton = GetComponent<Button>();
        _imageButton.onClick.AddListener(SpriteTransferOnClick);
    }

    private void SpriteTransferOnClick()
    {
        ImageTransfer sceneController = FindObjectOfType<ImageTransfer>();

        sceneController.SetID(int.Parse(gameObject.name));

        EventManager.ImageButtonClickEvent();
    }
}
