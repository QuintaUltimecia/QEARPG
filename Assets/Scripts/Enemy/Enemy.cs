using UnityEngine;
using UnityEngine.Events;

public class Enemy : Character, ITargetPosition
{
    [Header("Leveling")]
    [SerializeField] private int level;

    //[Header("Links")]
    [SerializeField] UnityEvent _deathOn;

    private void Start()
    {
        Initialization("Enemy", CharacterClass.Warrior);
    }

    public override void GetDamage(float damage)
    {
        base.GetDamage(damage);
        if (IsDeath == true)
        {
            Destroy(this);
            Destroy(GetComponent<EnemyCombatSystem>());
            _deathOn?.Invoke();
        }
    }

    public void Interaction(CharacterController characterController = null)
    {
        Vector3 targetWalkPosition = new Vector3(transform.position.x, transform.position.y + 3.8f, transform.position.z);
        characterController.SetTargetWalk(characterController.TargetMove.activeSelf, transform, targetWalkPosition);
        characterController.GetComponent<Player>().enemy = this;
    }
}

