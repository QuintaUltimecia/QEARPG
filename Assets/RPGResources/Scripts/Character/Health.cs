using UnityEngine;

public class Health
{
    private int _health;
    private int _healthMax;
    private float _healthRegen;

    public int HealthAmount { get => _health; private set => _health = Mathf.Max(0, value); }
    public int MaxHealth { get => _healthMax; }
    public float HealthRegen { get => _healthRegen; }

    public delegate void DeathEventHandler();
    public event DeathEventHandler DeathEvent;

    public delegate void DamageEventHandler();
    public event DamageEventHandler UpdateHealthEvent;

    public Health(int value)
    {
        _health = value;
        _healthMax = value;
        _healthRegen = _healthMax / 100;
    }

    public void ApplyDamage(int damage)
    {
        _health -= Mathf.Abs(damage);
        UpdateHealthEvent?.Invoke();

        if (_health == 0) DeathEvent?.Invoke();
    }
}
