using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FeaturesInUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private TextMeshProUGUI _healthBar;

    private Hero _hero;

    private void Awake()
    {
        _hero = GetComponent<Hero>();
    }

    private void Start()
    {
        GetCharacterFeaturesUI();
    }

    public void GetCharacterFeaturesUI()
    {
        try
        {
            _nameText.text = _hero.Name;

            _healthSlider.minValue = 0;
            _healthSlider.maxValue = _hero.ReturnHealth().MaxHealth;
            _healthSlider.value = _hero.ReturnHealth().HealthAmount;

            _healthBar.text = $"{_hero.ReturnHealth().HealthAmount}/{_hero.ReturnHealth().MaxHealth}";
        }
        catch { print($"{gameObject.name} object missing UI references!"); }
    }
}