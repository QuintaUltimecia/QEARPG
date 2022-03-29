using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterFeaturesInUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private TextMeshProUGUI _healthBar;

    private Character _character;

    private void Awake()
    {
        _character = GetComponent<Character>();
    }

    private void Start()
    {
        GetCharacterFeaturesUI();
    }

    public void GetCharacterFeaturesUI()
    {
        try
        {
            _nameText.text = _character.Name;

            _healthSlider.value = _character.Health;
            _healthSlider.minValue = _character.minValue;
            _healthSlider.maxValue = _character.MaxHealth;

            _healthBar.text = $"{_character.Health}/{_character.MaxHealth}";
        }
        catch { print($"{gameObject.name} object missing UI references!"); }
    }
}
