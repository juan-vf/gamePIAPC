using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VigilantMonitorState : VigilantBaseState
{
    private FieldVisionController FOV;
    private VigilantController vigilantController;
    public Quaternion orig;
    public Quaternion dir;
    public override void Enter(VigilantSM vigilantSM)
    {
        FOV = vigilantSM.GetComponent<FieldVisionController>();
        vigilantController = vigilantSM.GetComponent<VigilantController>();
        Debug.Log("MONITOR STATE");
        vigilantController.transform.rotation = vigilantController.GetL;
    }
    public override void Update(VigilantSM vigilantSM)
    {
        if (FOV.WatchingPlayer)
        {
            vigilantSM.ChangeState(vigilantSM.getAlertS);
            return;
        }

        if(vigilantController.transform.rotation == vigilantController.GetL){
            Debug.Log("Inicial desde L");
            orig = vigilantController.GetL;
            dir = vigilantController.GetR;
        }
        if(vigilantController.transform.rotation == vigilantController.GetR){
            Debug.Log("Inicial desde R");
            orig = vigilantController.GetR;
            dir = vigilantController.GetL;
        }
        vigilantController.MonitorRotation(orig, dir);
    }
    public override void Exit(VigilantSM vigilantSM) { }
    public override void OnCollisionEnter(VigilantSM vigilantSM, Collision collision)
    {}
}
