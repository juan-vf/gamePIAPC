using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DefaultState : BaseCState
{
    public TextMeshPro myText;
    public Vector3 offsetText = new Vector3(0, 5, 0);
    private Text saveText;
    private ChestController chestController;
    private ChestSMController chestSMController;
    private void Awake()
    {
        chestController = GetComponent<ChestController>();
        chestSMController = GetComponent<ChestSMController>();
    }
    void Start()
    {
        Debug.Log("DEFAULT STATE");
    }

    // Update is called once per frame
    void Update()
    {
        if (chestController.getCountSaveds == chestController.getEmptySlot)
        {
            Debug.Log("FULLLLLLLL");
            chestSMController.ActivateState(chestSMController.getFullS);
            return;
        }
    }
    private void OnCollisionStay(Collision other)
    {
        // if (other.transform.tag != "Player") { return; }

        // InputController input = other.gameObject.GetComponent<InputController>();

        // if (input != null && input.IsInteracting)
        // {
            // Debug.Log(input.IsInteracting);
            // Debug.Log(PlayerController.Instance.GetInputController.IsInteracting);
            // ModalInteract.Create(transform, new Vector3(0f, 2f), "Hello player, Recollect the Items 😉");
            // chestController.UpdateSlot();
            // return;
        // }
    }
}
