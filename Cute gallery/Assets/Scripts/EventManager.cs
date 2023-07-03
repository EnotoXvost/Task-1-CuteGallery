using UnityEngine.Events;

internal class EventManager
{
    public static UnityEvent OnImageButtonClicked = new UnityEvent();

    public static void ImageButtonClickEvent() => OnImageButtonClicked?.Invoke();
}
