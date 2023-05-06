using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingState : MonoBehaviour
{
    public Transform[] m_WayToPatrol;
    public Color m_ColorIndicator = new Color(60, 240, 215);
    private int nextWayPoint = 0;
    private NavMeshController navMeshController;
    
    private FieldVisionController FOV;
    private StateMachineController stateMachineController;
    private Color m_Color = new Color(60f/255f, 255f/255f, 0f/255f, 1f);
    private void Awake()
    {
        FOV = GetComponent<FieldVisionController>();
        navMeshController = GetComponent<NavMeshController>();
        stateMachineController = GetComponent<StateMachineController>();
    }
    private void Start()
    {
        OnEnable();
    }
    private void Update()
    {

        if(FOV.InRange){
            stateMachineController.ActivateState(stateMachineController.AlertState);
            return;
        }
        if(navMeshController.IsArrived()){
            nextWayPoint = (nextWayPoint + 1) % m_WayToPatrol.Length;
            UpdatePoint();
        }
    }
    private void OnEnable()
    {
        Debug.Log("eSTADO pATRULLA");
        stateMachineController.setColorIndicator(m_Color);
        navMeshController.NavMeshGo();
        UpdatePoint();
    }
    private void UpdatePoint(){
        navMeshController.UpdateTargetDir(m_WayToPatrol[nextWayPoint].position);
    }
    public Color ColorIndicator{
        get{ return m_ColorIndicator;}
    }
    public void TargetInRange(){
        if(FOV.WatchingPlayer){
            stateMachineController.ActivateState(stateMachineController.PersecutionState);
            return;
        }
        if(FOV.InRange){
            Debug.Log("Esta en el rango");
            stateMachineController.ActivateState(stateMachineController.AlertState);
            return;
        }
    }
    // public Color GetColor(){
    //     return m_Color;
    // }
    // private void TargetSeen(){
    //     if(FOV.WatchingPlayer){
    //         stateMachineController.ActivateState(stateMachineController.PersecutionState);
    //         return;
    //     }
    // }
}
