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
    [SerializeField] private GameObject _attackPoint;
    [SerializeField] private LayerMask _layerMask;

    private int _expMax;

    [SerializeField] private UnityEvent _attackOn;
    [SerializeField] private float _attackRange;

    private GameObject _slots;
    private GameObject[] _inventorySlot = new GameObject[28];

    public void OnEnable()
    {
        Initialization("Player", CharacterClass.Warrior);
    }
    private void Awake()
    {
        _slots = GetComponent<CharacterFeaturesInUI>().GetCharacterPanelComponent.Slots;
        for (int i = 0; i < _inventorySlot.Length; i++) 
            _inventorySlot[i] = _slots.transform.GetChild(i).gameObject;
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

        Collider[] targetColliders = Physics.OverlapSphere(_attackPoint.transform.position, _attackRange, _layerMask);

        foreach (var collider in targetColliders)
        {
            collider.GetComponent<IGetDamage>().GetDamage(Damage);
        }
    }

    private void OnDrawGizmosSelected() => Gizmos.DrawWireSphere(_attackPoint.transform.position, _attackRange);
}
