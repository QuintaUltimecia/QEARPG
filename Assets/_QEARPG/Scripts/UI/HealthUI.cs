using UnityEngine.UI;
using QuintaEssenta.Library;

public class HealthUI : BaseBehaviour
{
    [GetComponent] 
    private Image _image;

    [Inject]
    private Hero _hero;

    private void OnDisable()
    {
        _hero.Health.UpdateHealthEvent -= delegate ()
        {
            UpdateHealthOnUI();
        };
    }

    private void OnEnable()
    {
        _hero.Health.UpdateHealthEvent += delegate ()
        {
            UpdateHealthOnUI();
        };
    }

    public void UpdateHealthOnUI()
    {
        try
        {
            float amount = _hero.Health.Amount;
            float maxAmount = _hero.Health.MaxAmount;

            float value = amount / maxAmount;

            _image.fillAmount = value;
        }
        catch { print($"{gameObject.name} object missing UI references!"); }
    }
}
