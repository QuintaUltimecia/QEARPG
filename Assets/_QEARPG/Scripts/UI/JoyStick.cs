using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IDragHandler, IEndDragHandler, IGiveInput
{
    [SerializeField]
    [Range(0, 100)]
    private float _offset;

    [SerializeField] 
    private GameObject _analogStick;

    [SerializeField] 
    private GameObject _borderStick;

    private Transform _stickTransform;
    private Transform _borderTransform;

    private float _maxRadius;
    private float _stickPositionNormalize;

    private Vector3 _inputPosition;
    private Touch _touch;

    private void Awake()
    {
        if (_analogStick == null) print("Analog stick needs to be installed.");
        if (_borderStick == null) print("Border stick needs to be installed.");

        _stickTransform = _analogStick.transform;
        _borderTransform = _borderStick.transform;
        _maxRadius = _borderStick.GetComponent<RectTransform>().sizeDelta.x / 2;
        _stickPositionNormalize = _borderStick.GetComponent<RectTransform>().sizeDelta.x / 100;
        _offset = _maxRadius / 100 * _offset;
    }

    private void GetTouch()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            for (int i = 0; i < Input.touchCount; ++i)
                if (Input.GetTouch(i).phase == TouchPhase.Moved)
                    _touch = Input.GetTouch(i);

            _inputPosition = _touch.position;
        }
        else
            _inputPosition = Input.mousePosition;
    }

    private float HorizontalConvertor(Vector3 newPosition = new Vector3())
    {
        newPosition = _stickTransform.position - _borderTransform.position;
        newPosition = new Vector3(x: newPosition.x, y: 0, z: 0);
        newPosition *= Time.deltaTime;

        return newPosition.x / _stickPositionNormalize;
    }

    private float VerticalConvertor(Vector3 newPosition = new Vector3())
    {
        newPosition = _stickTransform.position - _borderTransform.position;
        newPosition = new Vector3(x: 0, y: 0, z: newPosition.y);
        newPosition *= Time.deltaTime;

        return newPosition.z / _stickPositionNormalize;
    }

    private Vector3 StickPosition(Vector3 newPosition = new Vector3())
    {
        newPosition = _stickTransform.position - _borderTransform.position;
        newPosition = new Vector3(x: newPosition.x, y: 0, z: newPosition.y);

        return newPosition.normalized;
    }

    public void OnDrag(PointerEventData eventData)
    {
        GetTouch();

        Vector2 offset = _inputPosition - _borderTransform.position;
        _stickTransform.position = (Vector2)_borderTransform.position + Vector2.ClampMagnitude(offset, _maxRadius);

        Debug.Log($"Max radius: {_maxRadius}, min radius: {_offset}");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _stickTransform.localPosition = Vector3.zero;
    }

    public Vector3 Direction()
    {
        float distance = Vector3.Distance(_stickTransform.position, _borderTransform.position);

        if (distance > _offset)
            return StickPosition();
        else return Vector3.zero;
    }

    public float Horizontal { get => HorizontalConvertor(); }
    public float Vertical { get => VerticalConvertor(); }
    public Vector3 Position { get => StickPosition(); }
}
