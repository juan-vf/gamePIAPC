using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ModalInteract : MonoBehaviour
{
    private SpriteRenderer m_Background;
    private SpriteRenderer m_Icon;
    private TextMeshPro m_TextMeshPro;
    public static Transform m_Parent;
    private void Awake()
    {
        m_Parent = transform;
        Debug.Log(m_Parent);
        m_Background = transform.Find("Background").GetComponent<SpriteRenderer>();
        m_Icon = transform.Find("Icon").GetComponent<SpriteRenderer>();
        m_TextMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
    }
    public static void Create(Transform parent, Vector3 localPosition, string text) {
        Transform modalTransform = Instantiate(GamePFHelper.GetGamePFHelper.m_Modal, parent);
        modalTransform.localPosition = localPosition;
        modalTransform.GetComponent<ModalInteract>().SetUp(text);;

    }
    public void SetUp(string text)
    {
        m_TextMeshPro.SetText(text);
        m_TextMeshPro.fontSize = 2f;
        m_TextMeshPro.ForceMeshUpdate();
        Vector2 textSize = m_TextMeshPro.GetRenderedValues(false);
        // Debug.Log(textSize);

        Vector2 padding = new Vector2(2f, .5f);

        m_Background.size = textSize + padding;
        // m_Background.sca
        // Debug.Log(m_Background.size);

        Vector3 offset = new Vector2(-2, 0f);
        m_Background.transform.localPosition = new Vector3(m_Background.size.x * 0.5f, 0f) + offset;
    }

}
