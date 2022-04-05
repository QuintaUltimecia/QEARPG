using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class DragAndDrop : MonoBehaviour, IEndDragHandler, IDragHandler, IBeginDragHandler
{
    private RectTransform _canvasRect;
    private GraphicRaycaster _raycaster;
    private EventSystem _eventSystem;
    private PointerEventData pointerEventData;

    private Transform lastTransform;

    private void Start()
    {
        _canvasRect = GameCache.Canvas.GetComponent<RectTransform>();
        _raycaster = _canvasRect.GetComponent<GraphicRaycaster>();
        _eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }

    private void GraphicRaycasting()
    {
        pointerEventData = new PointerEventData(_eventSystem);
        pointerEventData.position = transform.position;

        List<RaycastResult> results = new List<RaycastResult>();

        _raycaster.Raycast(pointerEventData, results);

        if (results[0].gameObject.GetComponent<Slot>()?.IsFull == false) transform.SetParent(results[0].gameObject.transform);
        else transform.SetParent(lastTransform);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        lastTransform = transform.parent;
        transform.SetParent(_canvasRect.transform);
        GetComponent<Image>().raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GraphicRaycasting();
        GetComponent<Image>().raycastTarget = true;
    }
}
