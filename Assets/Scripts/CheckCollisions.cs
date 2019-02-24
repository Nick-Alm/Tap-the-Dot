using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCollisions : MonoBehaviour
{
    public GameObject dot, bar, successMessage;
    Collider m_Collider, m_Collider2;
	public Text text;

    void Start()
    {
        //Check that the first GameObject exists in the Inspector and fetch the Collider
        if (dot != null)
            m_Collider = dot.GetComponent<Collider>();

        //Check that the second GameObject exists in the Inspector and fetch the Collider
        if (bar != null)
            m_Collider2 = bar.GetComponent<Collider>();
		text = successMessage.GetComponent<Text>();
    }

    void Update()
    {
        //If the first GameObject's Bounds enters the second GameObject's Bounds, output the message
        if (m_Collider.bounds.Intersects(m_Collider2.bounds))
        {
            //Debug.Log("Bounds intersecting");
			//text.text = "Text changed!";
        }
    }
}