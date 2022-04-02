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

    private void Awake()
    {
        AddCameras();

        _moveOn.AddListener(MoveOn);
        _moveOff.AddListener(MoveOff);
    }

    private void Update()
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
        Vector3 direction = _joyStick.Position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;

        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
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
