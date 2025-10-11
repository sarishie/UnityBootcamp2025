using UnityEngine;

public class SimpleEnemy : EnemyBase
{
    public override void Attack()
    {
        Debug.Log("Enemy AI : Enemy Attacked");
    }

    public override void Patrol()
    {
        Debug.Log("Enemy AI : Enemy Patrol");
    }

    public override void Chase()
    {
        Debug.Log("Enemy AI : Enemy Chase");
    }

    public override void CheckTransition()
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
