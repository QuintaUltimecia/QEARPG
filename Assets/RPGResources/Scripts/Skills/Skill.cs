using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public abstract class Skill : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] protected string _name;
    [SerializeField] protected float _fuel;
    [SerializeField] protected float _coolDown;
    [SerializeField] protected int _damage;
    [SerializeField] protected float _range;
    [SerializeField] protected string _description;
    [SerializeField] protected LayerMask _layerMask;

    private bool _isAvailable = true;
    protected Transform _attackPoint; //Get from the player

    public virtual IEnumerator AttackDelay()
    {
        SetDamage();
        BeforeAttack();

        yield return new WaitForSeconds(_coolDown);

        AfterAttack();
    }

    protected void SetDamage()
    {
        Collider[] targetColliders = Physics.OverlapSphere(_attackPoint.position, _range, _layerMask);

        foreach (var collider in targetColliders)
        {
            collider.GetComponent<ITakeDamage>().ReturnHealth().ApplyDamage(_damage);
        }
    }

    public virtual void BeforeAttack()
    {
        _isAvailable = false;
        GetComponent<Image>().color = Color.gray;
    }

    public virtual void AfterAttack()
    {
        _isAvailable = true;
        GetComponent<Image>().color = Color.white;
    }

    public void OnPointerClick(PointerEventData data)
    {
        if (_isAvailable == true) StartCoroutine(AttackDelay());
    }
}

