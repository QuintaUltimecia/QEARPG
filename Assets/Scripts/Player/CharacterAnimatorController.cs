using UnityEngine;

public class CharacterAnimatorController : MonoBehaviour
{
    private Animator _animator;

    private const string walkAnimation = "isWalk";
    private const string readyFightAnimation = "isReadyFight";
    private const string attackAnimation = "isAttack";
    private const string deathAnimation = "isDeath";

    private void Awake() => _animator = GetComponent<Animator>();

    public void WalkAnimation(bool isActive) => _animator.SetBool(walkAnimation, isActive);
    public void ReadyFightAnimation(bool isActive) => _animator.SetBool(readyFightAnimation, isActive);
    public void AttackAnimation(bool isActive) => _animator.SetBool(attackAnimation, isActive);
    public void DeathAnimation(bool isActive) => _animator.SetBool(deathAnimation, isActive);
}
