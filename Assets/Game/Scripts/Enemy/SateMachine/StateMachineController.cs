using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineController : MonoBehaviour
{
    public Color m_Color;
    public MeshRenderer m_Indicator;
    public MonoBehaviour m_InitialState;
    private PatrollingState patrollingState;
    private AlertState alertState;
    private PersecutionState persecutionState;
    private AttackState attackState;
    private MonoBehaviour m_ActualState;
    private bool m_IsAlerted = false;
    private void Awake()
    {
        patrollingState = GetComponent<PatrollingState>();
        alertState = GetComponent<AlertState>();
        persecutionState = GetComponent<PersecutionState>();
        attackState = GetComponent<AttackState>();
        m_ActualState = m_InitialState;
        m_Color = m_Indicator.material.color;
    }
    private void Start()
    {
        ActivateState(m_InitialState);
    }
    private void Update()
    {
        if (m_IsAlerted)
        {
            Debug.Log("Alertadoooooooooo");
            ActivateState(AttackState);
        }
        // else { return;}
    }
    public void ActivateState(MonoBehaviour newState)
    {
        if (m_ActualState == null) { return; }
        m_ActualState.enabled = false;
        m_ActualState = newState;
        m_ActualState.enabled = true;
    }
    public void DeactivateState()
    {

    }
    public MonoBehaviour InitialState
    {
        get { return m_InitialState; }
    }
    public PatrollingState PatrollingState
    {
        get { return patrollingState; }
    }
    public MonoBehaviour AlertState
    {
        get { return alertState; }
    }
    public MonoBehaviour PersecutionState
    {
        get { return persecutionState; }
    }
    public MonoBehaviour AttackState
    {
        get { return attackState; }
    }
    public void setColorIndicator(Color newColor)
    {
        m_Indicator.material.color = newColor;
        m_Color = newColor;
    }
    public bool getIsAlerted
    {
        set { m_IsAlerted = value; }
        get { return m_IsAlerted; }
    }
}
