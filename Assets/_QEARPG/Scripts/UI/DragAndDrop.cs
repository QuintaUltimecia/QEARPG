using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using QuintaEssenta.Library;

public class DragAndDrop : BaseBehaviour, IEndDragHandler, IDragHandler, IBeginDragHandler, IPointerClickHandler
{
    [GetComponent]
    protected RectTransform _rectTransform;

    private Canvas _canvas;

    private GraphicRaycaster _raycaster;
    private EventSystem _eventSystem;
    private PointerEventData _pointerEventData;

    private SlotUI _lastSlot;

    private bool IsDragable = true;

    public delegate void BeginDragHandler();
    public event BeginDragHandler OnBeginDragEvent;

    public InventoryUI InventoryUI { get; set; }

    protected override void Awake()
    {
        base.Awake();

        if (_lastSlot == null)
            _lastSlot = _rectTransform.parent.GetComponent<SlotUI>();
    }

    private void Start()
    {
        _canvas = FindObjectOfType<Canvas>();
        _raycaster = _canvas.GetComponent<GraphicRaycaster>();
        _eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();

        _pointerEventData = new PointerEventData(_eventSystem);
    }

    private T GetGraphicRaycastItem<T>()
    {
        _pointerEventData.position = _rectTransform.position;

        List<RaycastResult> results = new List<RaycastResult>();

        _raycaster.Raycast(_pointerEventData, results);

        var item = results.Count == 0 
            ? default 
            : results[0].gameObject.GetComponent<T>();

        return item;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (IsDragable == false)
            return;

        _rectTransform.SetParent(_canvas.transform);
        GetComponent<Image>().raycastTarget = false;

        OnBeginDragEvent?.Invoke();
        _lastSlot.ToEmpty();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (IsDragable == false)
            return;

        _rectTransform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (IsDragable == false)
            return;

        SlotUI nextSlot = GetGraphicRaycastItem<SlotUI>();

        if (nextSlot != null)
        {
            if (nextSlot.Fill(_rectTransform) == false)
            {
                _lastSlot.Fill(_rectTransform);
            }
            else _lastSlot = nextSlot;
        }
        else _lastSlot.Fill(_rectTransform);

        GetComponent<Image>().raycastTarget = true;
        _rectTransform.anchoredPosition = Vector3.zero;
    }

    public void InitDragable(bool value) =>
        IsDragable = value;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (IsDragable == false)
        {
            if (InventoryUI == null)
                new System.Exception($"{nameof(InventoryUI)} is null!");

            if (_rectTransform == null)
                new System.Exception($"{nameof(_rectTransform)} is null!");

            InventoryUI.InsertAnItem(_rectTransform);
            IsDragable = true;
        }
    }

    public RectTransform RectTransform { get => _rectTransform; }
}
