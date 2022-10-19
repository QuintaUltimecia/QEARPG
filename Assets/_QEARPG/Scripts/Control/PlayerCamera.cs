using UnityEngine;
using QuintaEssenta.Library;

public class PlayerCamera : BaseBehaviour
{
    [SerializeField] 
    private Transform _target;

    [SerializeField] 
    private float _offset;

    [SerializeField] 
    private float _duration;

    [GetComponent]
    private Transform _transform;

    private void Update() =>
        Move();

    private void Move()
    {
        Vector3 direction = new Vector3(
            x: _target.position.x,
            y: _offset,
            z: _target.position.z - _offset);

        _transform.position = Vector3.Slerp(
            a: _transform.position,
            b: direction,
            t: _duration * Time.deltaTime);
    }
}
