using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int LifeLimit;
    private PlayerBehaviour _behaviour;
    private int life;

	private void Awake()
	{
        if (LifeLimit == 0)
            LifeLimit = 10;
        
        _behaviour = GetComponent<PlayerBehaviour>();
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float x = Input.GetAxis(InputMapper.HORIZONTAL);
        _behaviour.Move(x);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sheep"))
		{
			Destroy(collision.gameObject);
			_AddLife();
		}
    }

    private void _AddLife(){
        if (life < LifeLimit)
            life++;
    }
}