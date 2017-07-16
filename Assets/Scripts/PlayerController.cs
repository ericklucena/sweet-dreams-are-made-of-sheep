using System.Linq;﻿
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
            KeyboardControls();
            TouchControls();
        }
	}

    void TouchControls() {
        
		var bottomLeft = new Rect(0, 0, Screen.width / 2, Screen.height);
		var bottomRight = new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height);
		// Calculate other rectangles

		if (Input.touchCount > 0)
		{
            if (bottomLeft.Contains(Input.GetTouch(0).position)) {
				_behaviour.Move(-1);
                Debug.Log("Top left touched");
            } else if (bottomRight.Contains(Input.GetTouch(0).position)) {
				_behaviour.Move(1);            
            }

			// Detect other quadrants
		}
    }

    void KeyboardControls() 
    {
		float x = Input.GetAxis(InputMapper.HORIZONTAL);
		_behaviour.Move(x);
		GameController.Instance.RefreshTimePoints();
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
            List<ParticleSystem> particle = _behaviour.gameObject.GetComponentsInChildren<ParticleSystem>().ToList();
            particle.Where(p => p.CompareTag("Sheep")).ToList().ForEach(p => p.Play());

            AudioSource audio = collision.gameObject.GetComponent<AudioSource>();
            audio.Play();

			GameController.Instance.AddSheepPoint();
            Destroy(collision.gameObject);
            _AddLife();
		}
        else if (collision.gameObject.CompareTag("Enemy")){
			//Executa a partícula
			List<ParticleSystem> particle = _behaviour.gameObject.GetComponentsInChildren<ParticleSystem>().ToList();
			particle.Where(p => p.CompareTag("Enemy")).ToList().ForEach(p => p.Play());

			AudioSource audio = collision.gameObject.GetComponent<AudioSource>();
			audio.Play();

            GameController.Instance.RemoveSheepPoint();
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