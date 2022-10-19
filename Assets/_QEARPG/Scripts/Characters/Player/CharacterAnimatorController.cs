using UnityEngine;
using QuintaEssenta.Library;

public class CharacterAnimatorController : BaseBehaviour
{
    [GetComponent]
    private Animator _animator;
    
    [Inject]
    private PlayerController _playerController;

    private const string _walkAnimation = "isWalk";
    private const string _readyFightAnimation = "isReadyFight";
    private const string _deathAnimation = "isDeath";

    private const string _attackAnimationName = "melee attack";

    private void OnEnable()
    {
        _playerController.OnMoveEvent += delegate (bool value)
        {
            WalkAnimation(value);
        };
    }

    private void OnDisable()
    {
        _playerController.OnMoveEvent -= delegate (bool value)
        {
            WalkAnimation(value);
        };
    }

    public void WalkAnimation(bool isActive) => _animator.SetBool(_walkAnimation, isActive);
    public void ReadyFightAnimation(bool isActive) => _animator.SetBool(_readyFightAnimation, isActive);
    public void AttackAnimation() => _animator.GetComponent<Animation>().Stop(_attackAnimationName);
    public void DeathAnimation(bool isActive) => _animator.SetBool(_deathAnimation, isActive);
}
