using UnityEngine;

public class PlayerPanelUI : MonoBehaviour
{
    [SerializeField] HealthUI _healthUI;

    public Hero Hero { get; private set; }

    public void InitHero(Hero value)
    {
        Hero = value;

        _healthUI.InitHero(Hero);
    }
}
