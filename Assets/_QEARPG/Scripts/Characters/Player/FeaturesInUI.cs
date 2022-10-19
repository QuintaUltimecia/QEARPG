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
            _healthSlider.maxValue = _hero.Health.MaxAmount;
            _healthSlider.value = _hero.Health.Amount;

            _healthBar.text = $"{_hero.Health.Amount}/{_hero.Health.MaxAmount}";
        }
        catch { print($"{gameObject.name} object missing UI references!"); }
    }
}
