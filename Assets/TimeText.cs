using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeText : MonoBehaviour {
	TextMeshProUGUI text;
	Animator anim;
	// Use this for initialization
	void Start () {
		text = GetComponent<TextMeshProUGUI>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = GameManager.instance.time.ToString();
		anim.SetInteger("Time",GameManager.instance.time);
	}
}
