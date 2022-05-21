using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerClickHandler
{
    public Slot[] Slot { get; set; }

    public void OnPointerClick(PointerEventData eventData)
    {
        for (int i = 0; i < Slot.Length; i++)
            if (Slot[i].IsFull is false) transform.SetParent(Slot[i].transform);

        Destroy(this);
    }
}
