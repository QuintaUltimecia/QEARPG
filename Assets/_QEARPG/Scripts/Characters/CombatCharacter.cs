using UnityEngine;

public abstract class CombatCharacter : Character, ITakeDamage
{
    [SerializeField] public Health Health { get; } = new Health();
}
