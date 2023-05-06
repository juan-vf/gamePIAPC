using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VigilantAlertState : VigilantBaseState
{
    private float m_StopAlert = 3f;
    private float m_AlertingTime;
    private  StateMachineController enemySMC;
    public override void Enter(VigilantSM vigilantSM){
        m_AlertingTime = 0f;
        Debug.Log("ALERTTTTT!!!!");
        enemySMC = GameObject.Find("Enemy").GetComponent<StateMachineController>();
        enemySMC.getIsAlerted = true;
    }
    public override void Update(VigilantSM vigilantSM){
        m_AlertingTime += Time.deltaTime;
        
        if(m_AlertingTime >= m_StopAlert){
            vigilantSM.ChangeState(vigilantSM.getMonitorS);
        }

    }
    public override void Exit(VigilantSM vigilantSM){}
        public override void OnCollisionEnter(VigilantSM vigilantSM, Collision collision)
    {
    }
}
