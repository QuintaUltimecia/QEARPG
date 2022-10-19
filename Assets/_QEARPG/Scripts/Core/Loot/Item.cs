using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerClickHandler
{
    public InventoryUI InventoryUI { get; set; }

    private RectTransform _rectTransform;

    private void Awake() =>
        _rectTransform = GetComponent<RectTransform>();

    public void OnPointerClick(PointerEventData eventData)
    {
        InventoryUI.InsertAnItem(_rectTransform);

        Destroy(this);
    }
}
