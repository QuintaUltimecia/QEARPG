using UnityEngine;

public class TransferPlayerComponents : MonoBehaviour
{
    [Header("Instantiate components")]
    [SerializeField] private GameObject _characterPanel;

    [Header("Components from the player")]
    [SerializeField] private Transform _attackPoint;

    //Get components
    private Canvas _canvas;
    private CharacterPanelComponents _characterPanelComponents;

    private void OnEnable()
    {
        _canvas = FindObjectOfType<Canvas>();

        CharacterPanelComponents();
    }

    private void CharacterPanelComponents()
    {
        _characterPanel = Instantiate(_characterPanel, _canvas.transform);
        _characterPanel.name = $"{gameObject.name} Panel";
        _characterPanelComponents = _characterPanel.GetComponent<CharacterPanelComponents>();

        _characterPanelComponents.AttackPoint = _attackPoint;
    }

    public CharacterPanelComponents GetCharacterPanelComponent { get => _characterPanelComponents; }
}
