using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterFeaturesInUI : MonoBehaviour
{
    private TextMeshProUGUI _nameText;
    private Slider _healthSlider;
    private TextMeshProUGUI _healthBar;

    private Character _character;
    private CharacterPanelComponents _characterPanelComponents;

    private void Start()
    {
        _character = GetComponent<IGiveFeaturesInUI>().ReturnCharacter();
        _characterPanelComponents = GetComponent<TransferPlayerComponents>().GetCharacterPanelComponent;

        GetUI();
        GetCharacterFeaturesUI();
    }

    private void GetUI()
    {
        _nameText = _characterPanelComponents.NameText;
        _healthBar = _characterPanelComponents.HealthBar;
        _healthSlider = _characterPanelComponents.HealthSlider;
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
}
