using System;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public float moveSpeed;
    public float currentHealth;
    public string enemyName;
    public float attackRange;
    public float safeDistance;
    protected GameObject player;
    protected Vector2 playerPos;
    protected Vector2 enemyPos;
    protected Vector2 startPos;
    protected float playerDistance;

    [Header("References")]
    private EnemyHealth enemyHealth;
    public event Action<EnemyBase> OnDeath;

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
        player = GameObject.FindGameObjectWithTag("Player");
        enemyHealth = GetComponent<EnemyHealth>();
        enemyHealth.OnDeath += Die;
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

    protected abstract void Patrol();
    protected abstract void Attack();

    protected abstract void Chase();

    protected virtual void CheckTransition()
    {
        Debug.Log("Enemy AI : Check Transisi");
    }

    protected virtual void Die()
    {
        OnDeath?.Invoke(this);

        Debug.Log(this + "Enemy Died");
        Destroy(gameObject);
    }


}
