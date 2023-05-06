using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VigilantSM : MonoBehaviour
{
    private VigilantBaseState m_ActualState;
    public VigilantMonitorState VMonitorSt = new VigilantMonitorState();
    public VigilantAlertState VAlertSt = new VigilantAlertState();

    private void Start()
    {
        m_ActualState = VMonitorSt;
        m_ActualState.Enter(this);
    }
    public void ActivateState(VigilantBaseState newState)
    {
        if (m_ActualState != null)
        {
            m_ActualState.Exit(this);
            return;
        }
        m_ActualState = newState;
        m_ActualState.Enter(this);
    }

    private void Update()
    {
        if(m_ActualState != null){
            m_ActualState.Update(this);
        };
    }
    private void OnCollisionEnter(Collision other)
    {
        m_ActualState.OnCollisionEnter(this, other);
    }
    public void ChangeState(VigilantBaseState newState){
        m_ActualState = newState;
        m_ActualState.Enter(this);
    }
    public VigilantBaseState getAlertS{
        get{return VAlertSt;}
    }
        public VigilantBaseState getMonitorS{
        get{return VMonitorSt;}
    }
}
