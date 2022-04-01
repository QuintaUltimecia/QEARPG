using UnityEngine;

public class CharacterAnimatorController : MonoBehaviour
{
    private Animator _animator;

    private const string _walkAnimation = "isWalk";
    private const string _readyFightAnimation = "isReadyFight";
    private const string _deathAnimation = "isDeath";

    private const string _attackAnimationName = "melee attack";

    private void Awake() => _animator = GetComponent<Animator>();

    public void WalkAnimation(bool isActive) => _animator.SetBool(_walkAnimation, isActive);
    public void ReadyFightAnimation(bool isActive) => _animator.SetBool(_readyFightAnimation, isActive);
    public void AttackAnimation() => _animator.GetComponent<Animation>().Stop(_attackAnimationName);
    public void DeathAnimation(bool isActive) => _animator.SetBool(_deathAnimation, isActive);
}
