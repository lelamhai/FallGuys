using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    [SerializeField] private GameObject m_PlaneBG;
    [SerializeField] private int m_InitCountPlane = 10;
    [SerializeField] private GameObject m_ContentPlane;
    private float m_Offset = 0.51f;
    private float m_BeiginWidth = 0;
    private float m_BeiginHeight = 0;
    void Start()
    {
        var pointStart = -(m_InitCountPlane * m_Offset)/2;
        m_BeiginWidth = pointStart;
        m_BeiginHeight = pointStart;

        for (int i = 0; i < m_InitCountPlane; i++)
        {
            for (int j = 0; j <= m_InitCountPlane; j++)
            {
                var planeBG = Instantiate(m_PlaneBG,transform.position, Quaternion.identity);
                planeBG.transform.position = new Vector3(m_BeiginWidth, 0, m_BeiginHeight);
                planeBG.transform.SetParent(m_ContentPlane.transform);
                m_BeiginWidth += m_Offset;
            }
            m_BeiginWidth = pointStart;
            m_BeiginHeight += m_Offset;
        }

        for (int i = 0; i < 2; i++)
        {
            var contentPlane = Instantiate(m_ContentPlane);
            contentPlane.transform.position = new Vector3(0, (-i -1) * 5, 0);
        }
    }
}
