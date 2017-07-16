using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchTg : MonoBehaviour
{
	public bool triggersOnAnytTag = false;
	public string TagToCheck;

	public UnityEngine.Events.UnityEvent OnTouch;

	private void OnCollisionEnter(Collision collision)
	{
		if (triggersOnAnytTag || collision.collider.CompareTag(TagToCheck))
		{
			OnTouch.Invoke();
		}
	}
}