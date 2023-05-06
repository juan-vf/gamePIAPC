using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AlertState : MonoBehaviour
{
    [Range(0, 30)]
    public float m_TimeToRotateToTarget = 10f;
    // private float m_DistNotSeeTarget = 2f;
    private float m_TimeStopSearch = 3f;
    private float m_TimeSearching;
    private float m_SearchTime = 0f;
    private FieldVisionController FOV;
    private StateMachineController stateMachineController;
    private NavMeshController navMeshController;
    private Color m_Color = new Color(255f / 255f, 221f / 255f, 10f / 255f, 1f);
    private void Awake()
    {
        FOV = GetComponent<FieldVisionController>();
        stateMachineController = GetComponent<StateMachineController>();
        navMeshController = GetComponent<NavMeshController>();
    }
    void Start()
    {
        OnEnable();
    }
    void Update()
    {
        TargetSeen();
        LookForTarget();
        m_TimeSearching += Time.deltaTime;
        if (m_TimeSearching >= m_TimeStopSearch)
        {
            m_TimeSearching = 0f;
            stateMachineController.ActivateState(stateMachineController.PatrollingState);
        }
    }
    private void TargetSeen()
    {
        if (FOV.WatchingPlayer)
        {
            navMeshController.setTarget(FOV.Hit.transform);
            stateMachineController.ActivateState(stateMachineController.PersecutionState);
            return;
        }
    }
    private void LookForTarget()
    {
        // if (!FOV.InRange)
        // {
        //     m_TimeSearching += Time.deltaTime;
        // if(m_TimeSearching >= m_TimeStopSearch){

        // stateMachineController.ActivateState(stateMachineController.PatrollingState);
        // return;
        // }
        // Debug.Log("Buggggggggggggggggg");
        // }
        // if(m_TimeStopSearch <= m_SearchTime){stateMachineController.ActivateState(stateMachineController.PatrollingState);}

        // Vector3 distance = new Vector3(0,0,m_DistNotSeeTarget);
        Vector3 dirToTarget = (FOV.getTarget.position - transform.position).normalized;
        // Debug.Log(FOV.Hit.transform);
        // Vector3 dirToTarget = (FOV.Hit.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(dirToTarget);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, m_SearchTime / m_TimeToRotateToTarget);
        // Debug.Log("Time Elapsed: "+m_SearchTime+"Time: "+Time.deltaTime);
        m_SearchTime = Time.deltaTime;
        // Quaternion rotation = Quaternion.FromToRotation(transform.position, targetRotation);
        // Vector3 rotateToTarget = rotation * transform.position.normalized;

        // float angle = Vector3.Angle(transform.position, targetRotation);
        // Vector3 rotationToTarget = Vector3.Cross(transform.position, targetRotation);
        // Quaternion rotation = Quaternion.AngleAxis(angle, rotationToTarget);
        // transform.rotation = lookRotation;
    }
    private void OnEnable()
    {
        stateMachineController.setColorIndicator(m_Color);
        navMeshController.NavMeshStop();
        m_TimeSearching = 0f;
        m_SearchTime = 0f;
        Debug.Log("Estado alertaXX" + m_TimeSearching);
    }
}
