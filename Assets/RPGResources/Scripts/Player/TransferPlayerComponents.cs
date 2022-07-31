using UnityEngine;

public class TransferPlayerComponents : MonoBehaviour
{
    [Header("Components from the player")]
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private RectTransform _playerPanel;

    private PlayerPanelUI _playerPanelUI;

    private RectTransform _canvas;

    private void Awake()
    {
        _canvas = FindObjectOfType<Canvas>().GetComponent<RectTransform>();
        _playerPanelUI = _playerPanel.GetComponent<PlayerPanelUI>();
    }

    private void Start()
    {
        _playerPanel.SetParent(_canvas);
        _playerPanel.offsetMax = Vector2.zero;
        _playerPanel.offsetMin = Vector2.zero;
    }

    public void InitHero(Hero value)
    {
        _playerPanelUI.InitHero(value);
    }
}
