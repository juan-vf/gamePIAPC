using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    // public MeshRenderer m_Indicator;
    private ObjSMController objSMController;
    private ObjController objController;
    private Color m_Color;
    private Vector3 m_Slot;
    private void Awake()
    {
        objSMController = GetComponent<ObjSMController>();
        objController = GetComponent<ObjController>();
        // Debug.Log("INICIO STATES" + objSMController + objSMController);
    }
    private void Start()
    {
        // OnEnable();
    }
    private void OnEnable()
    {
        objSMController = GetComponent<ObjSMController>();
        objController = GetComponent<ObjController>();
    }
    public ObjSMController GetObjSM
    {
        set { objSMController = value; }
        get { return objSMController; }
    }
    public ObjController GetObjController
    {
        set { objController = value; }
        get { return objController; }
    }
    public Color GetColor
    {
        get { return m_Color; }
        set { m_Color = value; }
    }
    public Vector3 GetSlot
    {
        get { return m_Slot; }
        set { m_Slot = value; }
    }
}
