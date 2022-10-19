using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace QEARPG.Craft
{
    public class CraftSystem : MonoBehaviour
    {
        [SerializeField]
        private List<CraftSlot> _craftSlots = new List<CraftSlot>();

        [SerializeField]
        private CraftedSlot _craftedSlot;

        private List<RecipeItemSO> _recipes = new List<RecipeItemSO>();

        private void Awake() =>
            _recipes = GameCache.Recipes;

        private void OnEnable()
        {
            for (int i = 0; i < _craftSlots.Count; i++)
            {
                _craftSlots[i].OnFill += delegate ()
                {
                    CheckSlots();
                };

                _craftSlots[i].OnEmpty += delegate ()
                {
                    CheckSlots();
                };

                _craftedSlot.OnEmpty += delegate ()
                {
                    Crafted();
                };
            }
        }

        private void OnDisable()
        {
            for (int i = 0; i < _craftSlots.Count; i++)
            {
                _craftSlots[i].OnFill -= delegate ()
                {
                    CheckSlots();
                };

                _craftSlots[i].OnEmpty -= delegate ()
                {
                    CheckSlots();
                };

                _craftedSlot.OnEmpty -= delegate ()
                {
                    Crafted();
                };
            }
        }

        private void CheckSlots()
        {
            var item = CheckRecipe();

            if (item != null)
            {
                UI.Item newItem = Instantiate(GameCache.ItemUIPrefab, _craftedSlot.transform);
                newItem.SetCurrentItem(item.Craftable);
            }
            else
            {
                if (_craftedSlot.ReturnChild<UI.Item>() != null)
                    Destroy(_craftedSlot.ReturnChild<UI.Item>().gameObject);
            }
        }

        private void Crafted()
        {
            for (int i = 0; i < _craftSlots.Count; i++)
            {
                if (_craftSlots[i].ReturnChild<UI.Item>() != null)
                    Destroy(_craftSlots[i].ReturnChild<UI.Item>().gameObject);
            }
        }

        private RecipeItemSO CheckRecipe()
        {
            ItemSO[] items = new ItemSO[9];

            for (int i = 0; i < items.Length; i++)
            {
                var item = _craftSlots[i].ReturnChild<UI.Item>();
                items[i] = item == null ? null : item.Current;
            }

            for (int i = 0; i < _recipes.Count; i++)
            {
                if (Enumerable.SequenceEqual(items, _recipes[i].RecipeItem) == true)
                    return _recipes[i];
            }

            return null;
        }
    }
}
