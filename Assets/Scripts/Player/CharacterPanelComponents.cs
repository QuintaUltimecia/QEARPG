using UnityEngine;

public class CharacterPanelComponents : MonoBehaviour
{
    [SerializeField] private JoyStick _controller;
    [SerializeField] private GameObject _slots;

    public JoyStick Controller { get => _controller; }
    public GameObject Slots { get => _slots; }
}
