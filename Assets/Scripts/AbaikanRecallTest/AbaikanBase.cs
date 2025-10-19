using UnityEngine;

public abstract class AbaikanBase : MonoBehaviour
{


    [Header("Movement Stats")]
    public float moveSpeed = 5f;
    public float zoneChaseRange = 10f;
    public float zoneOutOfRange = 15f;
    public float zoneAttackRange = 5f;
    private float playerDistance;


    [Header("References")]
    private GameObject playerGO;
    private GameObject enemyGO;

    protected enum EnemyState
    {
        Patrol,
        Chase,
        Attack
    }

    protected EnemyState enemyState;

    protected virtual void Start()
    {
        enemyState = EnemyState.Patrol;
        playerGO = GameObject.FindGameObjectWithTag("Player");
        enemyGO = GetComponent<GameObject>();
    }

    protected virtual void Update()
    {
        switch (enemyState)
        {
            case EnemyState.Patrol:
                Patrol();
                StateTransition();
                break;
            case EnemyState.Chase:
                Chase();
                StateTransition();
                break;
            case EnemyState.Attack:
                Attack();
                StateTransition();
                break;
        }
    }

    protected abstract void Patrol();

    protected abstract void Chase();

    protected abstract void Attack();

    protected virtual void StateTransition()
    {
        playerDistance = Vector2.Distance(playerGO.transform.position, enemyGO.transform.position);

        if (playerDistance > zoneOutOfRange || playerDistance > zoneChaseRange && playerDistance > zoneAttackRange)
        {
            enemyState = EnemyState.Patrol;
        }

        if (playerDistance < zoneOutOfRange && playerDistance < zoneChaseRange && playerDistance > zoneAttackRange)
        {
            enemyState = EnemyState.Chase;
        }

        if (playerDistance < zoneOutOfRange && playerDistance < zoneChaseRange && playerDistance < zoneAttackRange)
        {
            enemyState = EnemyState.Attack;
        }
    }
}
