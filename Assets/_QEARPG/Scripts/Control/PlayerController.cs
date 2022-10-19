using UnityEngine;
using QuintaEssenta.Library;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : BaseBehaviour
{
    [SerializeField] 
    private float _moveSpeed = 4f;

    [SerializeField] 
    private float _rotateSpeed = 4f;

    [GetComponent]
    private CharacterController _characterController;

    [GetComponent]
    private Transform _transform;

    private IGiveInput _giveInput;

    private Vector3 _moveDirection;

    public delegate void MoveHandler<T>(T obj);
    public event MoveHandler<bool> OnMoveEvent;

    private void Update()
    {
        ProcessInput(_giveInput.Direction());
    }

    private void Rotate()
    {
        _transform.rotation = Quaternion.Slerp(_transform.rotation, Quaternion.LookRotation(_moveDirection),
            _rotateSpeed * Time.fixedDeltaTime);
    }

    private void Move()
    {
        _characterController.Move(_moveDirection * _moveSpeed * Time.deltaTime);

        if (_moveDirection != Vector3.zero)
            OnMoveEvent(true);
        else OnMoveEvent(false);
    }

    private void ProcessInput(Vector3 moveDirection)
    {
        _moveDirection = moveDirection;

        Move();

        if (_moveDirection != Vector3.zero)
            Rotate();
    }

    public void InitGiveInput(IGiveInput giveInput) =>
        _giveInput = giveInput;
}

