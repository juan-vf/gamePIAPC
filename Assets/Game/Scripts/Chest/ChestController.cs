using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] private Transform[] m_ItemSlots;
    private List<Transform> m_ItemsSaved = new List<Transform>();
    private int m_EmptySlot;
    private void Awake() {
    }
    // Start is called before the first frame update
    void Start()
    {
        m_EmptySlot = m_ItemSlots.Length;
        Debug.Log(m_EmptySlot);

    }

    // Update is called once per frame
    void Update()
    {
        // UpdateSlot();
    }
    public void UpdateSlot(Transform item)
    {
        // if (m_ItemSlots[m_EmptySlot] != null) { m_EmptySlot++;}
        // m_EmptySlot
        // if(m_EmptySlot > 0){
        //     m_EmptySlot--;
        //     Debug.Log(m_EmptySlot);
        //     return;
        // }else if(m_EmptySlot == 0){
        //     return;
        // }
        m_ItemsSaved.Add(item);
        Debug.Log(m_ItemsSaved.Count);
        Debug.Log(getEmptySlot);
    }
    public Vector3 getSlotPosition
    {
        get { return m_ItemSlots[m_EmptySlot - 1].position; }
    }
    public int getNumberSlots{
        get{return m_ItemSlots.Length;}
    }
        public int getEmptySlot{
        get{return m_EmptySlot;}
    }
    public int getCountSaveds{
        get{return m_ItemsSaved.Count;}
    }
}
