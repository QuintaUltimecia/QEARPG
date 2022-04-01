using UnityEngine;

public class CharacterFeatures : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private CharacterClass _class;

    [Header("Character Features")]
    [SerializeField] private float _health;
    [SerializeField] private float _energy;
    [SerializeField] private float _mana;
    [SerializeField] private float _healthRegen;
    [SerializeField] private float _energyRegen;
    [SerializeField] private float _manaRegen;
    [SerializeField] private float _damage;
    [SerializeField] private float _attackSpeed;

    [Header("Resists")]
    [SerializeField] private float _physicalResist;
    [SerializeField] private float _magicalResist;

    [Header("Chances")]
    [SerializeField] private float _critChance;
    [SerializeField] private float _stunChance;

    [Header("Properties")]
    [SerializeField] private int _strength;
    [SerializeField] private int _dexterity;
    [SerializeField] private int _intelligence;

    [Header("State")]
    [SerializeField] private bool _isDeath;
    [SerializeField] private bool _isImmortality;
    [SerializeField] private bool _isStunned;

    private float _maxHealth;
    private float _maxEnergy;
    private float _maxMana;

    public readonly float propertyMultiply = 0.5f;
    public readonly float regenMultiply = 0.01f;
    public readonly float damageMultiply = 0.1f;
    public readonly float attackSpeedMultiply = 0.01f;
    public readonly int minValue = 0;

    public enum CharacterClass
    {
        Warrior,
        Wizard,
        Rogue
    };

    public string Name { get => _name; internal set => _name = value; }
    public CharacterClass Class { get => _class; internal set => _class = value; }
    public float Health { get => _health; internal set => _health = Mathf.Max(minValue, value); }
    public float Energy { get => _energy; internal set => _energy = value; }
    public float Mana { get => _mana; internal set => _mana = value; }
    public float HealthRegen { get => _healthRegen; internal set => _healthRegen = value; }
    public float EnergyRegen { get => _energyRegen; internal set => _energyRegen = value; }
    public float ManaRegen { get => _manaRegen; internal set => _manaRegen = value; }
    public float Damage { get => _damage; internal set => _damage = value; }
    public float AttackSpeed { get => _attackSpeed; internal set => _attackSpeed = value; }

    public int Strength { get => _strength; internal set => _strength = value; }
    public int Dexterity { get => _dexterity; internal set => _dexterity = value; }
    public int Intelligence { get => _intelligence; internal set => _intelligence = value; }

    public bool IsDeath { get { return _isDeath; } internal set => _isDeath = value; }

    public float MaxHealth { get => _maxHealth; internal set => _maxHealth = value; }
    public float MaxEnergy { get => _maxEnergy; internal set => _maxEnergy = value; }
    public float MaxMana { get => _maxMana; internal set => _maxMana = value; }
}

public abstract class Character : CharacterFeatures, IGetDamage, IGiveFeaturesInUI
{
    public void Initialization(string i_name, CharacterClass i_class)
    {
        Name = i_name;
        Class = i_class;

        switch (Class)
        {
            case CharacterClass.Warrior:
                Strength = 200;
                Dexterity = 100;
                Intelligence = 50;
                break;
            case CharacterClass.Wizard:
                Strength = 50;
                Dexterity = 100;
                Intelligence = 200;
                break;
            case CharacterClass.Rogue:
                Strength = 75;
                Dexterity = 200;
                Intelligence = 75;
                break;
        }

        GetCharacterFeatures();
    }

    public void GetCharacterFeatures()
    {
        MaxHealth = Strength * propertyMultiply;
        MaxEnergy = Dexterity * propertyMultiply;
        MaxMana = Intelligence * propertyMultiply;

        Health = MaxHealth;
        Energy = MaxEnergy;
        Mana = MaxMana;

        HealthRegen = Strength * regenMultiply;
        EnergyRegen = Dexterity * regenMultiply;
        ManaRegen = Intelligence * regenMultiply;

        Damage = Strength * damageMultiply;
        AttackSpeed = Dexterity * attackSpeedMultiply;
    }

    public virtual void GetDamage(float damage)
    {
        Health -= Mathf.Abs(damage);
        if (Health == 0) IsDeath = true;
    }

    public Character ReturnCharacter() { return this; }
}
