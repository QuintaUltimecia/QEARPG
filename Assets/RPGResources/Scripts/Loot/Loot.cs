using UnityEngine;
using UnityEngine.UI;

public class Loot : MonoBehaviour
{
    [SerializeField] private GameObject _lootPanel;

    private GameObject _cachedLootPanel;
    private GameObject _slots;
    private GameObject _lootWindow;
    private GameObject _lootButton;
    private GameObject _lootWindowExitButton;
    private GameObject[] _lootSlot = new GameObject[29];

    private Player _player;

    public void Interaction()
    {
        int randomItemCount = Random.Range(1, 28);

        for (int i = 0; i < randomItemCount; i++)
        {
            _lootSlot[i] = _slots.transform.GetChild(i).gameObject;
            Instantiate(ItemCache.Items[Random.Range(0, ItemCache.Items.Length)], _lootSlot[i].transform);
        }

        _lootButton.SetActive(false);
        _lootWindow.SetActive(true);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _player = player;
            _cachedLootPanel = Instantiate(_lootPanel, GameCache.Canvas.transform);

            LootPanel lootPanel = _cachedLootPanel.GetComponent<LootPanel>();
            _slots = lootPanel.Slots;
            _lootWindow = lootPanel.LootWindow;
            _lootButton = lootPanel.LootButton;
            _lootWindowExitButton = lootPanel.LootWindowExitButton;

            _lootButton.GetComponent<Button>().onClick.AddListener(Interaction);
            _lootWindowExitButton.GetComponent<Button>().onClick.AddListener(Destroy);
        }
    }

    private void Destroy()
    {
        Destroy(_cachedLootPanel);
        Destroy(gameObject);
    }

    public void OnTriggerExit(Collider other) { if (other.GetComponent<Player>()) Destroy(_cachedLootPanel); }
}
