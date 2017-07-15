using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private PlayerBehaviour _behaviour;

	private void Awake()
	{
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
}
