using UnityEngine;
using UnityEngine.SceneManagement;

public class ImageTransfer : MonoBehaviour
{
    private int _transferredImageID;

    public static ImageTransfer Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }

    public void SetID(int ID)
    {
        _transferredImageID = ID;
    }

    public int GetID()
    {
        return _transferredImageID;
    }
}
