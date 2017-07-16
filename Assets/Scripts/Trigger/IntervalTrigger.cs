using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntervalTrigger : MonoBehaviour {
    public float interval = 1;
    private float timerStart;
    public bool ShouldTrigger { get { return (Time.time - timerStart) > interval; } }

    public UnityEngine.Events.UnityEvent OnTimer;


	void OnEnable () {
        timerStart = Time.time;
	}
	
	void Update () {
        if (ShouldTrigger)
            Trigger();
	}

    void Trigger()
    {
        timerStart = Time.time;
        OnTimer.Invoke();
    }
}
