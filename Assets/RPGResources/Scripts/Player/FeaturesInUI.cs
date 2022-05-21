using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FeaturesInUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private TextMeshProUGUI _healthBar;

    private Character _character;

    private void OnEnable()
    {
        _character = GetComponent<IGiveFeaturesInUI>().ReturnCharacter();

        GetCharacterFeaturesUI();
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
