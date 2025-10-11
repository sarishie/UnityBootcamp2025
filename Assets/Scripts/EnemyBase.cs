using Unity.VisualScripting;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public float moveSpeed;
    public float currentHealth;
    public string enemyName;
    public float attackRange;
    public float safeDistance;
    public GameObject player;
    protected Vector2 playerPos;
    protected Vector2 enemyPos;
    protected Vector2 startPos;
    protected float playerDistance;

    protected enum EnemyState
    {
        Patrol,
        Attack,
        Chase
    }

    protected EnemyState currentState;

    protected virtual void Start()
    {
        currentState = EnemyState.Patrol;
        startPos = transform.position;
    }

    protected virtual void Update()
    {
        switch (currentState)
        {
            case EnemyState.Patrol:
                Patrol();
                CheckTransition();
                break;
            case EnemyState.Attack: 
                Attack();
                CheckTransition();
                break;
            case EnemyState.Chase:
                Chase();
                CheckTransition();
                break;
            default:
                CheckTransition();
                break;
        }
    }

    public abstract void Patrol();
    public abstract void Attack();

    public abstract void Chase();

    public virtual void CheckTransition()
    {
        Debug.Log("Enemy AI : Check Transisi");
    }


}
