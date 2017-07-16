using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour 
{
    private Rigidbody2D m_Rigidbody2D;
	public Transform StartPoint;
	public Transform EndPoint;

	// Use this for initialization
	void Start ()
    {
        StartPoint = GetComponent<Transform>();
        EndPoint = GetComponent<Transform>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

		float xvelocity = 0;

		if (m_Rigidbody2D.position.x > 0)
			xvelocity = -0.05f;
		else if (m_Rigidbody2D.position.x < 0)
			xvelocity = 0.05f;
        
        m_Rigidbody2D.velocity = new Vector2(xvelocity, (-GameController.Instance.Speed));
        //StartPoint.position = transform.position;
        //EndPoint.position = new Vector3(-4, -10, 0);
	}
	
	// Update is called once per frame
    void Update () 
    {

		if (m_Rigidbody2D.velocity.y < 0.1)
			m_Rigidbody2D.velocity = new Vector2(0, 1);

        /*if (transform.position != EndPoint.position && (m_Rigidbody2D.position.x < 0 || 0 < m_Rigidbody2D.position.x))
		{
			float step = GameController.Instance.Speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, EndPoint.position, step);
		}*/

        float xvelocity = 0;

        if (m_Rigidbody2D.position.x > 0)
            xvelocity = -0.05f;
        else if (m_Rigidbody2D.position.x < 0)
            xvelocity = 0.05f;

        m_Rigidbody2D.velocity = new Vector2(xvelocity, m_Rigidbody2D.velocity.y * (-GameController.Instance.Speed));
	}
}