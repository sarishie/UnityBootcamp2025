using UnityEngine;

public class RangeEnemy : EnemyBase
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
        attackRange = 6f;
        safeDistance = 3f;
        enemyPos = transform.position;
        playerPos = player.transform.position;
        playerDistance = Vector2.Distance(playerPos, enemyPos);

        if (playerDistance < 12f && playerDistance > attackRange)
        {
            currentState = EnemyState.Chase;

        }
        if (playerDistance < attackRange && playerDistance > safeDistance)
        {
            currentState = EnemyState.Attack;
        }
        if (playerDistance < safeDistance)
        {
            currentState = EnemyState.Chase;
        }
        if (playerDistance > attackRange + 7f)
        {
            currentState = EnemyState.Patrol;
        }
    }
}
