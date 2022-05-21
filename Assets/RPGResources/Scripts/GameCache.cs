using UnityEngine;

public class GameCache : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;

    [SerializeField] private Transform _canvasesPlayers;
    [SerializeField] private Transform _camerasPlayers;

    public static Canvas Canvas;

    public static Transform CanvasesPlayers;
    public static Transform CamerasPlayers;

    public static string SlotName;

    private void OnEnable()
    {
        Canvas = _canvas;

        CanvasesPlayers = _canvasesPlayers;
        CamerasPlayers = _camerasPlayers;
    }
}
