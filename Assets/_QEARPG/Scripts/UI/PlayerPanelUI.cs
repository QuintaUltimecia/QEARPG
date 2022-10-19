using UnityEngine;

public class PlayerPanelUI : MonoBehaviour
{
    [SerializeField] 
    private HealthUI _healthUI;

    public Hero Hero { get; private set; }

    private void Start()
    {
        transform.SetParent(FindObjectOfType<Canvas>().transform);
    }

    public void InitHero(Hero value)
    {
        Hero = value;
    }
}
