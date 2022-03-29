using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections;

public class SkillsManagement : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string _name;
    [SerializeField] private float _fuel;
    [SerializeField] private float _coolDown;
    [SerializeField] private float _damageMultiplier;
    [SerializeField] private string _description;

    [SerializeField] private Player _player;

    private bool _isAvailable = true;

    public void OnPointerClick(PointerEventData data)
    {
        if (_isAvailable == true) StartCoroutine(AttackDelay());
    }

    private IEnumerator AttackDelay()
    {
        _player.Attack();
        _isAvailable = false;
        GetComponent<Image>().color = Color.gray;
        yield return new WaitForSeconds(_coolDown);
        _isAvailable = true;
        GetComponent<Image>().color = Color.white;
    }
}

