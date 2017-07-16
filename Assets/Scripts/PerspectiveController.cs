using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveController : MonoBehaviour {

	private Rigidbody2D m_Rigidbody2D;

    public float Delta;

	// Use this for initialization
	void Awake () {
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if (GameController.Instance.Running)
        {
			Vector3 vector = new Vector3(Delta, 0, 0);
			transform.Translate(vector);
        }

   	}
}
