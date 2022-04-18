using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    [Range(0, 12)]
    [SerializeField] private float _moveSpeed;
    [Range(0, 12)]
    [SerializeField] private float _rotationSpeed;

    [Header("Links")]
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private CinemachineVirtualCamera _miniMapCamera;

    [Header("Events")]
    [SerializeField] private UnityEvent _moveOn;
    [SerializeField] private UnityEvent _moveOff;

    private Rigidbody _rigidbody;
    private JoyStick _joyStick;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _joyStick = GetComponent<TransferPlayerComponents>().GetCharacterPanelComponent.Controller;

        AddCameras();

        _moveOn.AddListener(MoveOn);
        _moveOff.AddListener(MoveOff);
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        if (_joyStick.Position.x != 0 || _joyStick.Position.y != 0)
        {
            Move();
            _moveOn?.Invoke();
        }
        else
        {
            _moveOff?.Invoke();
        }
    }

    private void Move()
    {
        Quaternion direction = Quaternion.LookRotation(_joyStick.Position - _rigidbody.velocity);
        Quaternion rotation = Quaternion.Lerp(_rigidbody.rotation, direction, _rotationSpeed * Time.fixedDeltaTime);
        _rigidbody.MoveRotation(rotation);
        Vector3 position = transform.position + _joyStick.Position * _moveSpeed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(position);
    }

    private void MoveOn()
    {
    }

    public void MoveOff()
    {
    }

    private void AddCameras()
    {
        _camera = Instantiate(_camera);
        _camera.Follow = transform;
        _miniMapCamera = Instantiate(_miniMapCamera);
        _miniMapCamera.Follow = transform;
    }
}
