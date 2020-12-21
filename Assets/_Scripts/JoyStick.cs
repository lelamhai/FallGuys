using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoyStick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private Image m_ImageBG;
    [SerializeField] private Image m_ImageJoyStick;

    private Vector3 m_Direction;
    public Vector3 Direction
    {
        get
        {
            return m_Direction;
        }
    }
    
    private void Start()
    {
        m_ImageJoyStick = transform.GetChild(0).GetComponent<Image>();
        m_Direction = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = Vector2.zero;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(m_ImageBG.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / m_ImageBG.rectTransform.sizeDelta.x);
            pos.y = (pos.y / m_ImageBG.rectTransform.sizeDelta.y);

            float x = 0;
            float y = 0;
            if(m_ImageBG.rectTransform.pivot.x == 1)
            {
                x = pos.x * 2 + 1;
            } else
            {
                x = pos.x * 2 - 1;
            }

            if (m_ImageBG.rectTransform.pivot.y == 1)
            {
                y = pos.y * 2 + 1;
            }
            else
            {
                y = pos.y * 2 - 1;
            }
            m_Direction = new Vector3(x, 0, y);

            m_Direction = (m_Direction.magnitude > 1) ? m_Direction.normalized : m_Direction;

            m_ImageJoyStick.rectTransform.anchoredPosition = new Vector2(m_Direction.x * (m_ImageBG.rectTransform.sizeDelta.x /3 ),
                m_Direction.z * (m_ImageBG.rectTransform.sizeDelta.y/3));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        m_Direction = Vector3.zero;
        m_ImageJoyStick.rectTransform.anchoredPosition = Vector3.zero;
    }

   
}
