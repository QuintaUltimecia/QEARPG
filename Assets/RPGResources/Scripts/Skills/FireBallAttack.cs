using UnityEngine;
using DG.Tweening;
using System.Collections;

public class FireBallAttack : Skill
{
    [SerializeField] private GameObject _fireBall;

    private float _duration = 1f;
    private Vector3 _startAttackPoint;

    public override IEnumerator AttackDelay()
    {
        BeforeAttack();

        _startAttackPoint = _attackPoint.localPosition;
        Vector3 direction = _attackPoint.position + _attackPoint.forward * 10f;
        GameObject newFireBall = Instantiate(_fireBall, _attackPoint);
        _attackPoint.DOMove(direction, _duration, false).OnComplete(() => Destroy(newFireBall)).OnPlay(() => SetDamage());

        yield return new WaitForSeconds(_coolDown);

        AfterAttack();
    }

    public override void AfterAttack()
    {
        base.AfterAttack();
        _attackPoint.localPosition = _startAttackPoint;
    }
}
