using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressController : MonoBehaviour {

    Image foregroundImage;

	// Use this for initialization
	void Start () {
		foregroundImage = gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        if (foregroundImage != null)
            foregroundImage.fillAmount = GameController.Instance.Sleepness;
	}
}
