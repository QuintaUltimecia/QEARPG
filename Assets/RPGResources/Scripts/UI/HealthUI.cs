using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private TextMeshProUGUI _healthBar;

    private Hero _hero;

    private void OnDisable()
    {
        _hero.ReturnHealth().UpdateHealthEvent -= delegate ()
        {
            UpdateHealthOnUI();
        };
    }

    public void InitHero(Hero value)
    {
        _hero = value;

        _hero.ReturnHealth().UpdateHealthEvent += delegate ()
        {
            UpdateHealthOnUI();
        };
    }

    public void UpdateHealthOnUI()
    {
        try
        {
            _healthSlider.minValue = 0;
            _healthSlider.maxValue = _hero.ReturnHealth().MaxHealth;
            _healthSlider.value = _hero.ReturnHealth().HealthAmount;

            _healthBar.text = $"{_hero.ReturnHealth().HealthAmount}/{_hero.ReturnHealth().MaxHealth}";
        }
        catch { print($"{gameObject.name} object missing UI references!"); }
    }
}
