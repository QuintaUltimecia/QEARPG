using UnityEngine;

public class LootPanel : MonoBehaviour
{
    [SerializeField] private GameObject _slots;
    [SerializeField] private GameObject _lootWindow;
    [SerializeField] private GameObject _lootButton;
    [SerializeField] private GameObject _lootWindowExitButton;

    public GameObject Slots { get => _slots; }
    public GameObject LootWindow { get => _lootWindow; }
    public GameObject LootButton { get => _lootButton; }
    public GameObject LootWindowExitButton { get => _lootWindowExitButton; }
}
