using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    [Header("Links")]
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private CinemachineVirtualCamera _miniMapCamera;
    [SerializeField] private JoyStick _joyStick;

    [Header("Events")]
    [SerializeField] private UnityEvent _moveOn;
    [SerializeField] private UnityEvent _moveOff;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

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
        _rigidbody.MoveRotation(Quaternion.LookRotation(_joyStick.Position));
        _rigidbody.MovePosition(transform.position + (_joyStick.Position * _moveSpeed * Time.deltaTime));
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
