using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : MonoBehaviour
{
    private FieldVisionController FOV;
    private StateMachineController stateMachineController;
    private NavMeshController navMeshController;
    private Color m_Color = new Color(108f / 255f, 0f / 255f, 10f / 255f, 1f);
    private float m_TimeStopPersuit = 3f;
    private float m_TimePersuit;
    private void Awake()
    {
    }
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        // navMeshController = GetComponent<NavMeshController>();
        // FOV = GetComponent<FieldVisionController>();
        // stateMachineController = GetComponent<StateMachineController>();

        // stateMachineController.setColorIndicator(m_Color);
        // Debug.Log("ATACK STATE");
        // stateMachineController.getIsAlerted = false;

    }
    private void OnEnable()
    {
        navMeshController = GetComponent<NavMeshController>();
        FOV = GetComponent<FieldVisionController>();
        stateMachineController = GetComponent<StateMachineController>();
        stateMachineController.setColorIndicator(m_Color);
        Debug.Log("ATACK STATE");
        stateMachineController.getIsAlerted = false;
        navMeshController = GetComponent<NavMeshController>();
        Transform target = GameObject.Find("Player").transform;
        navMeshController.setTarget(target);
        m_TimePersuit = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // navMeshController.PursueTarget();
        // m_TimePersuit += Time.deltaTime;
        // if (m_TimePersuit >= m_TimeStopPersuit)
        // {
        //     stateMachineController.ActivateState(stateMachineController.AlertState);
        // }
        // if (navMeshController != null)
        // {
            Debug.Log(navMeshController);
            navMeshController.PursueTarget();
            m_TimePersuit += Time.deltaTime;
            if (m_TimePersuit >= m_TimeStopPersuit)
            {
                Debug.Log("PARA ALERTA");
                stateMachineController.ActivateState(stateMachineController.AlertState);
                return;
            }
        // }
    }
}
