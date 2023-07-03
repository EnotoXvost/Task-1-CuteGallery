using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    internal class ScenesChanger : MonoBehaviour
    {
        private static ScenesChanger Instance;

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

            EventManager.OnImageButtonClicked.AddListener(ChangeToSceneViewer);
        }
        private void ChangeToSceneViewer() => SceneManager.LoadScene(2);
       
        public void ChangeToGallery() => SceneTransition.SwitchToScene(1);
    }
}
