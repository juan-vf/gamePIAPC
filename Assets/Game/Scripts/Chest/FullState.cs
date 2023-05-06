using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullState : BaseCState
{
    [SerializeField]private GameObject m_KeyPF;
    private GameObject m_Key;

    //EN ESTE ESTADO AL INICIAR DEBE ABRIR EL COFRE Y DROPEAR LA LLAVE O ITEM PARA ABRIR LA PUERTA
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Full state");
    }
    private void OnEnable()
    {
       GameObject m_Key =  Instantiate(m_KeyPF, m_KeyPF.transform);
        m_Key.transform.parent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
