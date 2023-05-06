using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody m_RB;
    private InputController m_InputController;
    private Vector3 velocity;
    private Camera cam;
    private static PlayerController s_Instance;
    private void Awake()
    {
        m_RB = GetComponent<Rigidbody>();
        m_InputController = GetComponent<InputController>();
        cam = Camera.main;
        s_Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        velocity = Vector3.zero;
        if (m_InputController.IsMoving)
        {
            movement();
            // Debug.Log("moving");
        }
        m_RB.velocity = velocity;
        m_RB.MovePosition(m_RB.position + velocity * Time.fixedDeltaTime);
    }
    /// <summary>
    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    /// </summary>
    private void LateUpdate()
    {
        rotation();
    }
    private void movement()
    {
        Vector3 dir = new Vector3(m_InputController.MoveInput.x, 0f, m_InputController.MoveInput.z);
        Vector3 dirRotated = cam.transform.rotation * dir;
        velocity = dirRotated * moveSpeed;
        velocity.y = 0f;
    }
    private void rotation()
    {
        Quaternion cameraRotation = cam.transform.rotation;
        m_RB.MoveRotation(Quaternion.Euler(0, cameraRotation.eulerAngles.y, 0));
    }
    public static PlayerController Instance
    {
        get
        {
            return s_Instance;
        }
    }
    public InputController GetInputController{
        get{ return m_InputController;}
    }
}
