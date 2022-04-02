using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private float _maxRadius;

    private GameObject _analogStick;
    private GameObject _borderStick;

    private Vector3 _inputPosition;
    private Touch _touch;

    private void Start()
    {
        _analogStick = transform.Find("Stick").gameObject;
        _borderStick = transform.Find("StickBorder").gameObject;

        _maxRadius = GetComponent<RectTransform>().sizeDelta.x / 2;
    }

    public void OnDrag(PointerEventData eventData)
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

        Vector3 offset = _inputPosition - _borderStick.transform.position;

        offset = new Vector3(offset.x, offset.y, 0);

        _analogStick.transform.position = _borderStick.transform.position + Vector3.ClampMagnitude(offset, _maxRadius);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _analogStick.transform.localPosition = Vector3.zero;
    }

    public Vector3 Position
    {
        get
        {
            return PositionConvertor().normalized;
        }
    }

    public Vector3 Rotation
    {
        get
        {
            return RotationConvertor().normalized;
        }
    }

    private Vector3 PositionConvertor(Vector3 newPosition = new Vector3())
    {
        newPosition = _analogStick.transform.position - _borderStick.transform.position;
        newPosition = new Vector3(x: newPosition.x, y: 0, z: newPosition.y);

        return newPosition;
    }

    private Vector3 RotationConvertor(Vector3 newPosition = new Vector3())
    {
        newPosition = _analogStick.transform.position - _borderStick.transform.position;
        newPosition = new Vector3(x: 0, y: newPosition.y, z: 0);

        return newPosition;
    }
}
