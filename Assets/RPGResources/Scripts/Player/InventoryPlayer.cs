using UnityEngine;

public class InventoryPlayer : MonoBehaviour
{
    [SerializeField] private Transform _slots;

    private Slot[] _slot;

    private void OnEnable()
    {
        _slot = new Slot[_slots.childCount];
        for (int i = 0; i < _slots.childCount; i++)
            _slot[i] = _slots.GetChild(i).GetComponent<Slot>();
    }

    public Slot[] Slot { get => _slot; }
}
