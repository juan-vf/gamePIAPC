using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private Vector3 m_movement;
    private bool m_Interact;

    public Vector3 MoveInput{
        get{return m_movement;}
    }
    public bool IsMoving{
        get{return !Mathf.Approximately(MoveInput.magnitude, 0);}
    }
    public bool IsInteracting{
        get{return m_Interact;}
    }

    private void Update()
    {
        m_movement.Set(
            Input.GetAxis("Horizontal"), 
            0f, 
            Input.GetAxis("Vertical")
        );
    }
    public void Interact(InputAction.CallbackContext callbackContext){
        if(callbackContext.performed){
            m_Interact = true;
            return;
        }
        m_Interact = false;
    }
}
