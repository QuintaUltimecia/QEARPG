using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace QEARPG.UI
{
    public class Item : DragAndDrop
    {
        private List<ItemSO> _items = new List<ItemSO>();

        [SerializeField]
        private ItemSO _current;

        private Image _image;

        private void OnEnable()
        {
            _image = RectTransform.GetChild(0).GetComponent<Image>();
            _items = GameCache.Items;

            if (_current == null)
                SetCurrentItem(_items[Random.Range(0, _items.Count)]);
            else SetCurrentItem(_current);
        }

        public void SetCurrentItem(ItemSO value)
        {
            _current = value;

            _image.sprite = _current.Sprite;
        }

        public ItemSO Current { get => _current; }
    }
}

