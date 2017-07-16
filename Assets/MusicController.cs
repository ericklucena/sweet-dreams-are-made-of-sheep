using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour {
    public AudioMixer mixer;
    public AudioMixerSnapshot[] snaps;

    private int current;
	// Use this for initialization
	void Start () {
        current = 0;
	}
	
	// Update is called once per frame
	void Update () {

        float life = GameController.Instance.Sleepness;

        int index = 1;
        int lenght = snaps.Length - 1;
        for (; index <= lenght; index++)
        {
            if (((index - 1) * 1/ lenght) < life && life <= (index * 1/ lenght))
                break;
        }

        if (current != index && snaps.Length > index)
        {
            current = index;
            snaps[index].TransitionTo(0.1f);
        }
	}
}
