using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Cinemachine;

public class CharacterController : MonoBehaviour
{
    [Header("Move Parameters")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private LayerMask _targetLayerMask;

    [Header("Links")]
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private CinemachineVirtualCamera _miniMapCamera;
    [SerializeField] private GameObject _targetMove;

    [Header("Events")]
    [SerializeField] private UnityEvent _moveOn;
    [SerializeField] private UnityEvent _moveOff;

    private Vector3 _targetPoint;
    private const float _targetDistanceMax = 0.8f;
    private const float _targetDistance = 1f;

    private void Awake()
    {
        AddCameras();

        _moveOn.AddListener(MoveOn);
        _moveOff.AddListener(MoveOff);
    }

    private void Update() { if (Input.GetMouseButtonUp(0)) RaycastRealization(); }

    private void RaycastRealization()
    {
        if (EventSystem.current.IsPointerOverGameObject() || IsPointerOverUIObject())
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100f, _targetLayerMask)) SetTargetMove(hitInfo);
    }

    private void SetTargetMove(RaycastHit target)
    {
        _targetPoint = new Vector3(target.point.x, transform.position.y, target.point.z);

        if (Vector3.Distance(transform.position, _targetPoint) <= _targetDistanceMax) _moveOff?.Invoke();
        else _moveOn?.Invoke();

        target.transform.GetComponent<ITargetPosition>()?.Interaction(this);
    }

    private IEnumerator Move(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > _targetDistance)
        {
            Vector3 direction = targetPosition - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;

            transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);

            yield return null;
            if (targetPosition != _targetPoint) yield break;
        }
        _moveOff?.Invoke();
    }

    private void MoveOn()
    {
        SetTargetWalk(true, transform.parent, _targetPoint);
        StartCoroutine(Move(_targetPoint));
    }

    public void MoveOff()
    {
        _targetPoint = Vector3.zero;
        SetTargetWalk(false, transform, _targetPoint);
    }

    public void SetTargetWalk(bool isActive, Transform parent, Vector3 position)
    {
        _targetMove.SetActive(isActive);
        _targetMove.transform.parent = parent;
        _targetMove.transform.position = position;
    }

    private void AddCameras()
    {
        _camera = Instantiate(Resources.Load<GameObject>("Player/Cameras")).transform.GetChild(0).transform.GetComponent<CinemachineVirtualCamera>();
        _camera.Follow = transform;
        _miniMapCamera = _camera.transform.parent.GetChild(1).GetComponent<CinemachineVirtualCamera>();
        _miniMapCamera.Follow = transform;
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    public float MoveSpeed { get { return _moveSpeed; } }
    public GameObject TargetMove { get => _targetMove; }
}
