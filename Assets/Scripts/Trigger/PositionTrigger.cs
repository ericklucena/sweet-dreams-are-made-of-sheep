using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.CompareTag("Obstacle")
           || collision.gameObject.CompareTag("Sheep")
           || collision.gameObject.CompareTag("Enemy"))
		{
			float xposition = 0;

			if (collision.transform.position.x > 0)
				xposition = 2;
			else if (collision.transform.position.x < 0)
                xposition = -2;

            collision.transform.position = new Vector3(xposition, collision.transform.position.y, 0);
		}
    }
}
