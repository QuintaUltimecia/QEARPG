using UnityEngine;

public class Hero : CombatCharacter
{
    private InventoryUI _inventoryUI;

    private void Start()
    {
        Health.ApplyDamage(0);
    }

    [ContextMenu(nameof(ApplyDamage))]
    private void ApplyDamage()
    {
        Health.ApplyDamage(10);
        Debug.Log($"Health: {Health.Amount}/{Health.MaxAmount}");
    }


    public void InitInventoryUI(InventoryUI value) => _inventoryUI = value;
    public InventoryUI InventoryUI 
    {
        get
        {
            if (_inventoryUI == null)
            {
                Debug.Log($"{nameof(_inventoryUI)} is null.");
                return null;
            }
            else return _inventoryUI;
        }
    }
}
