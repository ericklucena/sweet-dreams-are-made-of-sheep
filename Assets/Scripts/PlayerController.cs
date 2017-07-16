﻿using System.Collections;
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
        if (GameController.Instance.Running)
        {
			float x = Input.GetAxis(InputMapper.HORIZONTAL);
			_behaviour.Move(x);
			GameController.Instance.RefreshTimePoints();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.CompareTag("Obstacle"))
		{
            GameController.Instance.StopGame();
            GameController.Instance.RestartAfterDeath();
		}
        else if (collision.gameObject.CompareTag("Sheep"))
		{
            //Executa a partícula
            ParticleSystem particle = _behaviour.gameObject.GetComponent<ParticleSystem>();
            particle.Play();

			GameController.Instance.AddSheepPoint();
            Destroy(collision.gameObject);
            _AddLife();
		}
        else if (collision.gameObject.CompareTag("Enemy")){
            Destroy(collision.gameObject);
            _SubtractLife();
        }
    }

    private void _AddLife(){
        if (life < LifeLimit)
            life++;
    }

	private void _SubtractLife()
	{
		if (life > 0)
			life--;

        if (life <= 0)
            GameController.Instance.RestartAfterDeath();
	}
}