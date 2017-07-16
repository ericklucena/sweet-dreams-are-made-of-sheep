using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour {
    public AudioMixer mixer;
    public AudioMixerSnapshot[] snaps;
	// Use this for initialization
	void Start () {
        //snaps = new AudioMixerSnapshot[];
        //snaps = mixer.FindSnapshot("");
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

        float[] weigthts = new float[snaps.Length];
        for (int i = 0; i < snaps.Length; i ++){
            if (i == index)
                weigthts[i] = 6;
            else
                weigthts[i] = 0;
        }

        mixer.TransitionToSnapshots(snaps, weigthts, 0.1f);
	}
}
