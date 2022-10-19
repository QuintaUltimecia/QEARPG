using UnityEngine;
using DG.Tweening;

public class AnimationUI : MonoBehaviour
{
    [SerializeField] private float _offset = 200;
    [SerializeField] private float _duration = 1f;
    [SerializeField] private Direction _direction;
    [SerializeField] private Ease _ease = Ease.Linear;

    private RectTransform _rectTransform;

    private Vector3 _startPosition;
    private Vector3 _nextPosition;

    private enum Direction
    {
        Left,
        Right,
        Up,
        Down,
        Center,
        RotateLeft,
        RotateRight,
    }

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();

        if (_direction == Direction.Center)
            _startPosition = Vector3.one;
        else if (_direction == Direction.RotateLeft || _direction == Direction.RotateRight)
            _startPosition = Vector3.zero;
        else
            _startPosition = _rectTransform.localPosition;

        switch (_direction)
        {
            case Direction.Left:
                _nextPosition = new Vector3(_startPosition.x - _offset, _startPosition.y, _startPosition.z);
                break;
            case Direction.Right:
                _nextPosition = new Vector3(_startPosition.x + _offset, _startPosition.y, _startPosition.z);
                break;
            case Direction.Up:
                _nextPosition = new Vector3(_startPosition.x, _startPosition.y + _offset, _startPosition.z);
                break;
            case Direction.Down:
                _nextPosition = new Vector3(_startPosition.x, _startPosition.y - _offset, _startPosition.z);
                break;
            case Direction.Center:
                _nextPosition = Vector3.zero;
                break;
            case Direction.RotateLeft:
                _nextPosition = new Vector3(0, 0, _offset);
                break;
            case Direction.RotateRight:
                _nextPosition = new Vector3(0, 0, -_offset);
                break;
            default:
                break;
        }
    }

    private void OnEnable()
    {
        switch (_direction)
        {
            case Direction.Center:
                _rectTransform.localScale = _nextPosition;
                _rectTransform.DOScale(_startPosition, _duration).SetEase(_ease);
                break;
            case Direction.RotateLeft:
                _rectTransform.eulerAngles = _nextPosition;
                _rectTransform.DORotate(_startPosition, _duration).SetEase(_ease);
                break;
            case Direction.RotateRight:
                _rectTransform.eulerAngles = _nextPosition;
                _rectTransform.DORotate(_startPosition, _duration).SetEase(_ease);
                break;
            default:
                _rectTransform.localPosition = _nextPosition;
                _rectTransform.DOLocalMove(_startPosition, _duration).SetEase(_ease);
                break;
        }
    }
}
