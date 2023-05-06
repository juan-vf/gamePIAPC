using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSMController : MonoBehaviour
{
    public Color m_Color;
    public MeshRenderer m_Indicator;
    public State m_InitialState;
    public State m_TakenState;
    public State m_RecollectedState;
    private State m_ActualState;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        m_ActualState = m_InitialState;
        // ChangeState(m_InitialState);
    }
    // Start is called before the first frame update
    void Start()
    {
        ChangeState(m_InitialState);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeState(State newState)
    {
        if (m_ActualState == null) { return; }
        // Debug.Log(m_ActualState.name + m_ActualState.GetObjController, m_ActualState.GetObjSM);
        m_ActualState.enabled = false;
        m_ActualState = newState;
        m_ActualState.enabled = true;
        // Debug.Log(m_ActualState.name + m_ActualState.GetObjController, m_ActualState.GetObjSM);
    }
    public State getTakenS
    {
        get { return m_TakenState;}
    }
    public State getRecollectedS
    {
        get { return m_RecollectedState;}
    }
    public void setColorMesh()
    {
        m_Indicator.material.color = m_ActualState.GetColor;
        return;
    }
}
