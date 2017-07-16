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
        //mixer.TransitionToSnapshots(snaps, new float[] { 0.1f }, 0.1f);
	}
}
