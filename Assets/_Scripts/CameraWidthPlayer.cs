using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWidthPlayer : MonoBehaviour
{
    [SerializeField] private Transform m_Player;
    [SerializeField] private Vector3 m_Offset = Vector3.zero;
    [SerializeField] private float m_Speed = 0.125f;
    private void LateUpdate()
    {
        Vector3 taget = m_Player.transform.position + m_Offset;
        Vector3 smoothdPosition = Vector3.Lerp(transform.position, taget, m_Speed);
        transform.position = smoothdPosition;
        transform.LookAt(m_Player);
    }
}
