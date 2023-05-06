using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseState : State
{
    private Color m_StateColor = new Color(222f / 255f, 191f / 255f, 101f / 255f, 1f);
    private void Start()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player") { return; };
        // Debug.Log(other.name);
        InputController input = other.gameObject.GetComponent<InputController>();

        if (input != null && input.IsInteracting)
        {
            GetObjSM.ChangeState(GetObjSM.getTakenS);
            return;
        }
    }
    private void OnEnable()
    {
        transform.gameObject.layer = LayerMask.NameToLayer("Default"); 
        GetColor = m_StateColor;
        GetObjSM.setColorMesh();
        Debug.Log("LooseState OnEnable");
    }
}
