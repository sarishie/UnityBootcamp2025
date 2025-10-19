using System.Collections;
using UnityEngine;

public class MeleeEnemy : EnemyBase
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
        attackRange = 2f;
        safeDistance = 9f;
        enemyPos = transform.position;
        playerPos = player.transform.position;
        playerDistance = Vector2.Distance(playerPos, enemyPos);

        if (playerDistance < 7f && playerDistance > attackRange)
        {
            currentState = EnemyState.Chase;
            
        } 
        if (playerDistance < attackRange)
        {
            currentState = EnemyState.Attack;
        }
        if (playerDistance > safeDistance)
        {
            currentState = EnemyState.Patrol;
        }
    }
}
