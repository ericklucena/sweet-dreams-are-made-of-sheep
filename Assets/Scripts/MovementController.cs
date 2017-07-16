using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour 
{
    private Rigidbody2D m_Rigidbody2D;

	// Use this for initialization
	void Start ()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, (-GameController.Instance.Speed));
	}
	
	// Update is called once per frame
    void Update () 
    {

		if (m_Rigidbody2D.velocity.y < 0.1)
			m_Rigidbody2D.velocity = new Vector2(0, 1);
        
        m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, m_Rigidbody2D.velocity.y * (-GameController.Instance.Speed));
	}
}