using UnityEngine;

public abstract class CombatCharacter : Character, ITakeDamage
{
    private Health _health;

    public void InitCharacter(int value)
    {
        _health = new Health(value);
    }

    public Health ReturnHealth() { return _health; }
}
