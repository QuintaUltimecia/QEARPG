using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 4f;
    [SerializeField] private float _rotateSpeed = 4f;
    [SerializeField] private float _maxOffset = 1f;

    private CharacterController _characterController;
    private Vector3 _moveDirection;
    private Transform _transform;

    private Vector3 _inputPosition;
    private Touch _touch;

    public UnityEvent _dragEvent = new UnityEvent();
    public UnityEvent _endDragEvent = new UnityEvent();

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _transform = transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetTouch();

            _dragEvent?.Invoke();
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            _moveDirection = new Vector3(mousePosition.x - _inputPosition.x, 0.0f,
                mousePosition.y - _inputPosition.y);

            float normalizedMagnitude = _moveDirection.magnitude / 100f;
            normalizedMagnitude = Mathf.Clamp01(normalizedMagnitude);

            _moveDirection = _moveDirection.normalized * normalizedMagnitude;

            _characterController.Move(_moveDirection * _moveSpeed * Time.deltaTime);

            _transform.rotation = Quaternion.Slerp(_transform.rotation, Quaternion.LookRotation(_moveDirection),
                _rotateSpeed * Time.fixedDeltaTime);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _endDragEvent?.Invoke();
        }
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
}

