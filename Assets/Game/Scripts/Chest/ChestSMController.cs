using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSMController : MonoBehaviour
{
    [SerializeField]
    private BaseCState m_InitialSate;
    [SerializeField]
    private BaseCState DefaultS;
    [SerializeField]
    private BaseCState FullS;
    private BaseCState m_ActualSate;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        m_ActualSate = m_InitialSate;
    }
    // Start is called before the first frame update
    void Start()
    {
        ActivateState(m_ActualSate);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void ActivateState(BaseCState newState){
        m_ActualSate.enabled = false;
        m_ActualSate = newState;
        m_ActualSate.enabled = true;
    }
    public BaseCState getFullS{get{return FullS;}}

}
