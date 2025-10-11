using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RandomEnemy : EnemyBase
{
    int RandomNumber;
    int moveTime;
    bool isRandomRunning = false;
    bool isRandomTurn;
    bool temporaryStart = false;



    public override void Attack()
    {
        Debug.Log("Enemy AI : Enemy Attacked");

    }

    public override void Patrol()
    {
        Debug.Log("Enemy AI : Enemy Patrol");
        transform.position = startPos;
    }

    public override void Chase()
    {
        Debug.Log("Enemy AI : Enemy Chase");
        transform.position = playerPos;
    }

    public override void CheckTransition()
    {
        base.CheckTransition();
        

        enemyPos = transform.position;
        playerPos = player.transform.position;
        playerDistance = Vector2.Distance(playerPos, enemyPos);
       
        if (isRandomTurn)
        {
            isRandomTurn = false;
            isRandomRunning = true;
            if (isRandomRunning)
            {
                StartCoroutine(runningRandomSwitchState());
            }
        }

        if (!isRandomTurn && !temporaryStart)
        {
            isRandomTurn = true;
            temporaryStart = true;
        }
        
        
    }

    public IEnumerator runningRandomSwitchState()
    {
        isRandomRunning = false;
        RandomNumber = Random.Range(0, 10);
        moveTime = RandomNumber;
        yield return new WaitForSeconds(moveTime);
        if (currentState == EnemyState.Chase && !isRandomTurn)
        {
            currentState = EnemyState.Patrol;
            isRandomTurn = true;
        }
        if (currentState == EnemyState.Patrol && !isRandomTurn)
        {
            currentState = EnemyState.Chase;
            isRandomTurn = true;
        }

    }
}
