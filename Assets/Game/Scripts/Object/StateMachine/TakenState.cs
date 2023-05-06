using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakenState : State
{
    public Transform hand;
    private Color m_StateColor = new Color(65f / 255f, 16f / 255f, 170f / 255f, 1f);
    private bool m_Is;
    private bool m_ActionExecuted = false;
    private bool m_exit = false;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
    }
    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(GetObjController, GetObjSM);
        GetObjController.UpdatePosition(hand.position);
    }
    // private void OnCollisionStay(Collider other)
    // {
    // if (other.tag == "Chest")
    // {
    // Debug.Log(other.name);
    // InputController input = other.gameObject.GetComponent<InputController>();
    // if (input != null && input.IsInteracting)
    // {
    //     Vector3 SlotEmpty = other.gameObject.GetComponent<ChestController>().getSlotPosition;
    //     GetObjController.UpdatePosition(SlotEmpty);
    //     GetObjSM.ChangeState(GetObjSM.getRecollectedS);
    //     return;
    // }
    // }
    // int chestLayer = LayerMask.NameToLayer("Chest");
    // Debug.Log(other.gameObject.layer);

    // if (other.gameObject.layer == chestLayer)
    // {
    //     Debug.Log(other.name + "Aca esta en la capa Chest");
    //     InputController input = other.gameObject.GetComponent<InputController>();
    //     if (input != null && input.IsInteracting)
    //     {
    //         Vector3 SlotEmpty = other.gameObject.GetComponent<ChestController>().getSlotPosition;
    //         GetObjController.UpdatePosition(SlotEmpty);
    //         GetObjSM.ChangeState(GetObjSM.getRecollectedS);
    //         return;
    //     }
    // }
    // }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Chest")) { return; }
        if (PlayerController.Instance.GetInputController.IsInteracting && !m_ActionExecuted)
        {
            m_ActionExecuted = true;
            other.gameObject.GetComponent<ChestController>().UpdateSlot(this.transform);
            Vector3 SlotEmpty = other.gameObject.GetComponent<ChestController>().getSlotPosition;
            GetSlot = SlotEmpty;
            GetObjController.UpdatePosition(GetSlot);
            m_exit = true;
            // GetObjSM.ChangeState(GetObjSM.getRecollectedS);
            return;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        m_ActionExecuted = false;
        if(m_exit){GetObjSM.ChangeState(GetObjSM.getRecollectedS);}
    }
    // private void OnCollisionEnter(Collision other)
    // {
    //     Debug.Log(other.gameObject.name);
    // }
    private void OnEnable()
    {
        // transform.gameObject.layer = LayerMask.NameToLayer("Chest");
        GetObjSM = GetComponent<ObjSMController>();
        GetObjController = GetComponent<ObjController>();
        // Debug.Log( GetObjSM , GetObjController);
        GetColor = m_StateColor;
        GetObjSM.setColorMesh();
        // Debug.Log("TakenState OnEnable");
    }
}
