using UnityEngine;

public class SimpleEnemy : EnemyBase
{
    protected override void Attack()
    {
        Debug.Log("Enemy AI : Enemy Attacked");
    }

    protected override void Patrol()
    {
        Debug.Log("Enemy AI : Enemy Patrol");
    }

    protected override void Chase()
    {
        Debug.Log("Enemy AI : Enemy Chase");
    }

    protected override void CheckTransition()
    {
        base.CheckTransition();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentState = EnemyState.Patrol;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            currentState = EnemyState.Attack;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentState = EnemyState.Chase;
        }
        Debug.Log("Enemy AI : Perubahan Enemy State");
    }
}
