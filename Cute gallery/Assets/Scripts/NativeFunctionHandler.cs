using UnityEngine;
using UnityEngine.SceneManagement;

public class NativeFunctionHandler : MonoBehaviour
{
    private int _sceneId;

    private static NativeFunctionHandler Instance;

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

    private void Start()
    {
        _sceneId = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("q");
            SwithScene();
        }
    }

    private void SwithScene()
    {
        _sceneId = SceneManager.GetActiveScene().buildIndex;

        if (_sceneId == 0) Application.Quit();
        else SceneManager.LoadScene(_sceneId - 1);
    }
}
