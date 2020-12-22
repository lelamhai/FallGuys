using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private JoyStick m_MoveJoyStick;
    [SerializeField] private float m_Speed = 0.5f;
    [SerializeField] private float m_JumpHeight = 7f;
    [SerializeField] private Rigidbody m_Rigidbody;
    private bool m_IsJump = true;
    

    private void Update()
    {
        if(m_MoveJoyStick.Direction != Vector3.zero)
        {
            transform.position += m_MoveJoyStick.Direction * m_Speed;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(m_IsJump)
            {
                m_Rigidbody.AddForce(Vector3.up * m_JumpHeight);
                m_IsJump = false;
            }    
        }
    }

    public void onButtonJump()
    {
        if (m_IsJump)
        {
            m_Rigidbody.AddForce(Vector3.up * m_JumpHeight);
            m_IsJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Plane"))
        {
            m_IsJump = true;
        }
    }
}
