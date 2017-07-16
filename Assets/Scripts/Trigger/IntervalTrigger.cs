using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntervalTrigger : MonoBehaviour {
    public float interval = 1;
    private DateTime timerStart;
    public bool ShouldTrigger { get { return (DateTime.Now - timerStart).TotalSeconds > interval; } }

    public UnityEngine.Events.UnityEvent OnTimer;


	void OnEnable () {
        timerStart = DateTime.Now;
	}
	
	void Update () {
        if (ShouldTrigger && GameController.Instance.Playing)
            Trigger();
	}

    void Trigger()
    {
        timerStart = DateTime.Now;
        OnTimer.Invoke();
    }
}
