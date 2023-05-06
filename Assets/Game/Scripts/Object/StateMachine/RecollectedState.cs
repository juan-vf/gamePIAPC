using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecollectedState : State
{
    private Color m_StateColor = new Color(255f / 255f, 99f / 255f, 99f / 255f, 1f);
    private void Awake()
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
    private void OnEnable()
    {
        Debug.Log("Estado Recollectado en: " + GetSlot);   
        GetObjSM = GetComponent<ObjSMController>();
        GetObjController = GetComponent<ObjController>();
        GetColor = m_StateColor;
        GetObjSM.setColorMesh();
        // GetObjController.UpdatePosition(GetSlot);
    }
}
