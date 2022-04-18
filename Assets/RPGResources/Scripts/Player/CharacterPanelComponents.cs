using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterPanelComponents : MonoBehaviour
{
    [SerializeField] private JoyStick _controller;
    [SerializeField] private GameObject _slots;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private TextMeshProUGUI _healthBar;

    public JoyStick Controller { get => _controller; }
    public GameObject Slots { get => _slots; }
    public TextMeshProUGUI NameText { get => _nameText; }
    public Slider HealthSlider { get => _healthSlider; }
    public TextMeshProUGUI HealthBar { get => _healthBar; }

    public Transform AttackPoint { get; set; }
}
