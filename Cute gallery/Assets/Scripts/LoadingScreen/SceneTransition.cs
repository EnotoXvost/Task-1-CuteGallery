using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private Text _loadingPercentage;
    [SerializeField] private Slider _loadingProgressBar;

    private static SceneTransition Instance;
    private static bool shouldPlayOpeningAnimation = false;

    private Animator _componentAnimator;
    private AsyncOperation _loadingSceneOperation;

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
    }

    private void Start()
    {
        _componentAnimator = GetComponent<Animator>();

        if (shouldPlayOpeningAnimation)
        {
            _componentAnimator.SetTrigger("SceneEnd");
            Instance._loadingProgressBar.value = 0;

            shouldPlayOpeningAnimation = false;
        }
    }

    private void Update()
    {
        if (_loadingSceneOperation != null)
        {
            _loadingPercentage.text = Mathf.RoundToInt(_loadingSceneOperation.progress * 100) + "%";

            _loadingProgressBar.value = _loadingSceneOperation.progress; 
        }
    }
    public static void SwitchToScene(int sceneId)
    {
        Instance._componentAnimator.SetTrigger("SceneStart");

        Instance._loadingSceneOperation = SceneManager.LoadSceneAsync(sceneId);

        Instance._loadingSceneOperation.allowSceneActivation = false;
        Instance._loadingProgressBar.value = 0;
    }

    public void OnAnimationOver()
    {
        shouldPlayOpeningAnimation = true;

        _loadingSceneOperation.allowSceneActivation = true;
    }
}