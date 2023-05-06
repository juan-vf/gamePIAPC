using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePFHelper : MonoBehaviour
{
    private static GamePFHelper items;
    private static GamePFHelper sInstanciate;
    private void Awake()
    {
        sInstanciate = this;
    }
    public static GamePFHelper GetGamePFHelper
    {
        get
        {
            return sInstanciate;
        }
    }
    public Transform m_Modal;
}
