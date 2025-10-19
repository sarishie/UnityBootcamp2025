using UnityEngine;

public class AbaikanEnemy : AbaikanBase
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void Chase()
    {
        Debug.Log("Enemy AI : Chase");
    }

    protected override void Attack()
    {
        Debug.Log("Enemy AI : Attack");
    }

    protected override void Patrol()
    {
        Debug.Log("Enemy AI : Patrol");
    }

    protected override void StateTransition()
    {
        base.StateTransition();
    }

    
}
