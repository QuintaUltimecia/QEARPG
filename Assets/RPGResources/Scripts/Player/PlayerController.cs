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
    [SerializeField] private Transform _cameras;
    [SerializeField] private JoyStick _joyStick;

    [Header("Events")]
    [SerializeField] private UnityEvent _moveOn;
    [SerializeField] private UnityEvent _moveOff;

    private Rigidbody _rigidbody;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _cameras.SetParent(GameCache.CamerasPlayers);
        _cameras.gameObject.name = $"Cameras {gameObject.name}";

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
}
