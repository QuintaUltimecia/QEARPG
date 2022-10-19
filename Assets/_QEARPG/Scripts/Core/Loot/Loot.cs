using UnityEngine;
using UnityEngine.UI;

namespace QEARPG
{
    public class Loot : MonoBehaviour
    {
        [SerializeField]
        private GameObject _lootPanel;

        private GameObject _cachedLootPanel;
        private GameObject _slots;
        private GameObject _lootWindow;
        private GameObject _lootButton;
        private GameObject _lootWindowExitButton;
        private GameObject[] _lootSlot = new GameObject[29];

        private InventoryUI _inventoryUI;

        public void Interaction()
        {
            int randomItemCount = Random.Range(1, 28);

            for (int i = 0; i < randomItemCount; i++)
            {
                _lootSlot[i] = _slots.transform.GetChild(i).gameObject;
                GameObject newItem = Instantiate(ItemCache.Items[Random.Range(0, ItemCache.Items.Length)], _lootSlot[i].transform);
                newItem.GetComponent<DragAndDrop>().InventoryUI = _inventoryUI;
                newItem.GetComponent<DragAndDrop>().InitDragable(false);
            }

            _lootButton.SetActive(false);
            _lootWindow.SetActive(true);
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Hero hero))
            {
                _inventoryUI = hero.InventoryUI;
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

        public void OnTriggerExit(Collider other) { if (other.GetComponent<Hero>()) Destroy(_cachedLootPanel); }
    }

}