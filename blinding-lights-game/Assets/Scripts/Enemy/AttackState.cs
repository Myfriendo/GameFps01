using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    public override void Enter()
    {
    }

    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            if (moveTimer > Random.Range(3, 7))
            {   
                enemy.Agent.SetDestination(enemy.transform.position+ (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
        }
        else
        {
            losePlayerTimer += Time.deltaTime;
            if (losePlayerTimer > 8)
            {
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }

    public override void Exit()
    {
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
