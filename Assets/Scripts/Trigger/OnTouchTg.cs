using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchTg : MonoBehaviour
{
	public bool triggersOnAnytTag = false;
	public string TagToCheck;

	public UnityEngine.Events.UnityEvent OnTouch;

    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (triggersOnAnytTag || collision.CompareTag(TagToCheck))
		{
			OnTouch.Invoke();
		}
    }
}