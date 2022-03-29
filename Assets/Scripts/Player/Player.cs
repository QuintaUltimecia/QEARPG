using UnityEngine;
using UnityEngine.Events;

public class Player : Character
{
    [Header("Leveling")]
    [SerializeField] private int exp;
    [SerializeField] private int level;
    [SerializeField] private int passiveSkillPoints;
    [SerializeField] private int activeSkillPoints;

    [Header("Links")]
    [SerializeField] private GameObject _targetAttack;
    [SerializeField] private LayerMask _layerMask;

    public Enemy enemy;

    private int _expMax;

    [SerializeField] private UnityEvent _attackOn;

    public void Start()
    {
        Initialization("Player", CharacterClass.Warrior);
    }

    public void GetExp(int value)
    {
        exp += value;
        _expMax = 100;
    }

    public void Death()
    {
        Destroy(this);
    }

    public void Attack()
    {
        _attackOn.Invoke();
        if (enemy != null)
            enemy.GetComponent<IGetDamage>().GetDamage(Damage);
    }
}
