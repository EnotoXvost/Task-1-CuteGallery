using UnityEngine;

public class ScreenOrientation : MonoBehaviour
{
    private enum Orientation
    {
        Any,
        Portrait,
        PortraitFixed,
        Landscape,
        LandscapeFixed
    }

    [SerializeField] private Orientation _orientation;

    private void Start()
    {
        switch (_orientation)
        {
            case Orientation.Any:
                Screen.orientation = UnityEngine.ScreenOrientation.AutoRotation;

                Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = true;
                Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = true;
                break;

            case Orientation.Portrait:
                Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
                Screen.orientation = UnityEngine.ScreenOrientation.AutoRotation;

                Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = true;
                Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = false;
                break;

            case Orientation.PortraitFixed:
                Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
                break;

            case Orientation.Landscape:
                Screen.orientation = UnityEngine.ScreenOrientation.LandscapeLeft;
                Screen.orientation = UnityEngine.ScreenOrientation.AutoRotation;

                Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = false;
                Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = true;
                break;

            case Orientation.LandscapeFixed:
                Screen.orientation = UnityEngine.ScreenOrientation.LandscapeLeft;
                break;
        }

        Destroy(gameObject);
    }
}
