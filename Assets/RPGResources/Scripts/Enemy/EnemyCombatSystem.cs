using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class EnemyCombatSystem : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private float aggressionRadius;
    [SerializeField] private float attackRadius;
    [SerializeField] private LayerMask layerMaskAttack;

    [SerializeField] private float walkSpeed;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private UnityEvent OnMove;
    [SerializeField] private UnityEvent OffMove;

    [SerializeField] private Transform _aggressionPoint;

    private float distanceToplayer;
    private bool isAttack;

    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(_aggressionPoint.position, aggressionRadius, layerMaskAttack);

        if (player == null) foreach (var hitCollider in hitColliders) player = hitCollider?.GetComponent<Player>();
        else
        {
            distanceToplayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToplayer < aggressionRadius && distanceToplayer > attackRadius)
            {
                WalkToPlayer();
                StopCoroutine(Attack());
            }
            else if (distanceToplayer < attackRadius)
            {
                OffMove?.Invoke();
                if (isAttack == false) StartCoroutine(Attack());
                isAttack = true;
            }
            else
            {
                player = null;
                OffMove?.Invoke();
            }
        }
    }

    private void WalkToPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);

        OnMove?.Invoke();
    }

    private IEnumerator Attack()
    {
        //player.GetComponent<Player>().GetDamage(_enemy.Damage);
        yield return new WaitForSeconds(2);
        isAttack = false;
    }

    private void OnDrawGizmosSelected() => Gizmos.DrawWireSphere(_aggressionPoint.position, aggressionRadius);
}
