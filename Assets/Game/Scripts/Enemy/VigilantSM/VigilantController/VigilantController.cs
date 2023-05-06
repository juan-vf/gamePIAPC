using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VigilantController : MonoBehaviour
{
    public Vector3 m_LeftSide;
    public Vector3 m_RightSide;
    public float m_TimeToRotate;
    public float m_TimeElapsed = 0f;
    private Quaternion InitialRotation;
    private Quaternion m_LeftR;
    private Quaternion m_RightR;
    void Start()
    {

        m_LeftSide = transform.position + new Vector3(-5f, 0, 7f);
        m_RightSide = transform.position + new Vector3(5f, 0, 7f);
        InitialRotation = transform.rotation;
        Vector3 directionL = (m_LeftSide - transform.position).normalized;
        Quaternion rotationL = Quaternion.LookRotation(directionL);
        m_LeftR = rotationL;
        Vector3 directionR = (m_RightSide - transform.position).normalized;
        Quaternion rotationR = Quaternion.LookRotation(directionR);
        m_RightR = rotationR;
    }
    void Update()
    {}
    public void MonitorRotation(Quaternion origin, Quaternion dir)
    {
        m_TimeElapsed += Time.deltaTime;
        transform.rotation = Quaternion.Lerp(origin, dir, m_TimeElapsed / m_TimeToRotate);
        if (transform.rotation == dir) {m_TimeElapsed = 0f;}
    }

    // IEnumerator LerpRotation(Quaternion origin, Quaternion dir, float timeLerp)
    // {
    //     Debug.Log("Rutina");
    //     m_TimeElapsed = 0f;
    //     while (m_TimeElapsed < timeLerp)
    //     {
    //         transform.rotation = Quaternion.Lerp(origin, dir, m_TimeElapsed / timeLerp);
    //         m_TimeElapsed += Time.deltaTime;
    //         yield return null;
    //     }
    //     transform.rotation = dir;
    // }
    // public bool LeftEndRotate
    // {
    //     get { return transform.rotation == Quaternion.LookRotation((m_LeftSide - transform.position).normalized); }
    // }
    // public bool RightEndRotate
    // {
    //     get { return transform.rotation == Quaternion.LookRotation((m_RightSide - transform.position).normalized); }
    // }
    // public Quaternion GetInitRotation
    // {
    //     get { return InitialRotation; }
    // }
    public Quaternion GetL
    {
        get { return m_LeftR; }
    }
    public Quaternion GetR
    {
        get { return m_RightR; }
    }
}
