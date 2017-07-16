﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    enum EPosition
    {
        left,
        center,
        right
    }

    private Rigidbody2D m_Rigidbody2D;
    private Transform m_transform;

    private float _speed;
    private bool _moving;
    private EPosition _position;

    private Vector3 center;
    private Vector3 left;
    private Vector3 right;


    private void Awake()
    {
        // Setting up references.
        m_Rigidbody2D = GetComponents<Rigidbody2D>()[0];
        m_transform = GetComponents<Transform>()[0];

        center = m_transform.position;
        right = left = center;
        left.x -= 3.5f;
        right.x += 3.5f;
        _speed = 20.0f;

        _position = EPosition.center;
    }

    public void Move(float move)
    {
        // Move the character
        //m_Rigidbody2D.velocity = new Vector2(move * _velocity, m_Rigidbody2D.velocity.y);
        if (!_moving)
        {
            if (move < -0.0)
            {
                if (_position == EPosition.right)
                {
                    MoveTo(_position = EPosition.center);
                }
                else if (_position == EPosition.center)
                {
                    MoveTo(_position = EPosition.left);
                }
            }
            else if (move > 0.0)
            {
                if (_position == EPosition.left)
                {
                    MoveTo(_position = EPosition.center);
                }
                else if (_position == EPosition.center)
                {
                    MoveTo(_position = EPosition.right);
                }
            }
        }
    }

    void MoveTo(EPosition position)
    {
        Vector3? vector = null;
        
        switch (position) 
        {
            case EPosition.center:
                vector = center;
                break;
            case EPosition.left:
                vector = left;
				break;
			case EPosition.right:
                vector = right;
				break;
        }

        if (vector != null) {
            IEnumerator coroutine = MoveTo(m_transform, vector.Value);
			StartCoroutine(coroutine);
        }
    }

	IEnumerator MoveTo(Transform objectToMove, Vector3 b)
	{
        _moving = true;
        Vector3 a = objectToMove.position;
        float step = (_speed / (a - b).magnitude) * Time.fixedDeltaTime;
		float t = 0;
		while (t <= 1.0f)
		{
			t += step; // Goes from 0 to 1, incrementing by step each time
			objectToMove.position = Vector3.Lerp(a, b, t); // Move objectToMove closer to b
			yield return new WaitForFixedUpdate();         // Leave the routine and return here in the next frame
		}
		objectToMove.position = b;
        _moving = false;
	}
}
