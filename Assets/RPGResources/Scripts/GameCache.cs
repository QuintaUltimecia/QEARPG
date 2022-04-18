using UnityEngine;

public class GameCache : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;

    public static Canvas Canvas;
    public static string SlotName;

    private void OnEnable()
    {
        Canvas = _canvas;
    }
}
