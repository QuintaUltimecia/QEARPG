using UnityEngine;

public class Health
{
    private int _amount;
    private int _maxAmount;
    private float _regen;

    public int Amount { get => _amount; private set => _amount = Mathf.Max(0, value); }
    public int MaxAmount { get => _maxAmount; }
    public float Regen { get => _regen; }

    public delegate void DeathEventHandler();
    public event DeathEventHandler DeathEvent;

    public delegate void DamageEventHandler();
    public event DamageEventHandler UpdateHealthEvent;

    public Health()
    {
        _amount = 100;
        _maxAmount = 100;
        _regen = _maxAmount / 100;
    }

    public void ApplyDamage(int damage)
    {
        _amount -= Mathf.Abs(damage);
        UpdateHealthEvent?.Invoke();

        if (_amount == 0) DeathEvent?.Invoke();
    }
}
