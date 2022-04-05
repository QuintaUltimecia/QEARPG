using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterFeaturesInUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject _characterPanel;

    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private TextMeshProUGUI _healthBar;

    private Character _character;
    private CharacterPanelComponents _characterPanelComponents;
    private GameObject _canvas;

    private void Awake()
    {
        _canvas = FindObjectOfType<Canvas>().gameObject;
        _character = GetComponent<IGiveFeaturesInUI>().ReturnCharacter();

        try { _characterPanel = Instantiate(_characterPanel, _canvas.transform); } catch { print($"{gameObject.name} panel is null"); }
        if (_characterPanel != null)
        {
            _characterPanel.name = $"{gameObject.name}Panel";
            _characterPanelComponents = _characterPanel.GetComponent<CharacterPanelComponents>();
        }
    }

    private void Start()
    {
        GetCharacterFeaturesUI();
        Debug.Log($"{_character} : {_character.Health}");
    }

    public void GetCharacterFeaturesUI()
    {
        try
        {
            _nameText.text = _character.Name;

            _healthSlider.minValue = _character.minValue;
            _healthSlider.maxValue = _character.MaxHealth;
            _healthSlider.value = _character.Health;

            _healthBar.text = $"{_character.Health}/{_character.MaxHealth}";
        }
        catch { print($"{gameObject.name} object missing UI references!"); }
    }

    public CharacterPanelComponents GetCharacterPanelComponent { get => _characterPanelComponents; }
}
