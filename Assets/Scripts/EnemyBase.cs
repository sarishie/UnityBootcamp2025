using Unity.VisualScripting;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public float moveSpeed;
    public float currentHealth;
    public string enemyName;

    public abstract void Patrol();
    public abstract void Attack();

    public abstract void Chase();

    public virtual void CheckTransition()
    {
        Debug.Log("Enemy AI : Check Transisi");
    }

    protected enum EnemyState
    {
        Patrol,
        Attack,
        Chase
    }

    protected EnemyState currentState;

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


}
