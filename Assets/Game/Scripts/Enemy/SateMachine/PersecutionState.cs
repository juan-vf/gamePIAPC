using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersecutionState : MonoBehaviour
{
    public float m_TimeForStopPersuit = 3f;
    private float m_TimeNoSeeTarget = 0f;
    private FieldVisionController FOV;
    private StateMachineController stateMachineController;
    private NavMeshController navMeshController;
    private Color m_Color = new Color(255f / 255f, 0f / 255f, 0f / 255f, 1f);
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        FOV = GetComponent<FieldVisionController>();
        stateMachineController = GetComponent<StateMachineController>();
        navMeshController = GetComponent<NavMeshController>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (FOV.InRange && FOV.WatchingPlayer)
        {
            navMeshController.PursueTarget();
            m_TimeNoSeeTarget = 0f;
            return;
        }

        m_TimeNoSeeTarget += Time.deltaTime;

        if (m_TimeNoSeeTarget >= m_TimeForStopPersuit)
        {
            stateMachineController.ActivateState(stateMachineController.AlertState);
            return;
        }

    }
    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    private void OnEnable()
    {
        m_TimeNoSeeTarget = 0f;
        stateMachineController.setColorIndicator(m_Color);
        Debug.Log("Estado persecucion");
    }
}
