using UnityEngine;
using QuintaEssenta.Library;
using System.Collections.Generic;

public class InventoryUI : BaseBehaviour
{
    [SerializeField] 
    private SlotUI _slotUIPrefab;

    [SerializeField]
    private int _slotCount = 6;

    private List<SlotUI> _slotPool = new List<SlotUI>();

    [GetComponent]
    private RectTransform _rectTransform;

    [Inject]
    private Hero _hero;

    protected override void Awake()
    {
        base.Awake();

        CreateInventory(_slotCount);
        _hero.InitInventoryUI(this);
    }

    private void CreateInventory(int slotCount)
    {
        for (int i = 0; i < slotCount; i++)
            _slotPool.Add(Instantiate(_slotUIPrefab, _rectTransform));
    }

    public void InsertAnItem(RectTransform rectTransformItem)
    {
        for (int i = 0; i < _slotCount; i++)
        {
            if (_slotPool[i].Fill(rectTransformItem))
                break;
        }
    }
}
