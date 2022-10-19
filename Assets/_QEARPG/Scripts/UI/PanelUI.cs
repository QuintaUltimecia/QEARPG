using UnityEngine;

public class PanelUI : MonoBehaviour
{
    [SerializeField] 
    private bool _isActiveAtStart = true;

    private GameObject _gameObject;

    private void Awake() =>
        _gameObject = gameObject;

    private void Start() =>
        _gameObject.SetActive(_isActiveAtStart);
}
