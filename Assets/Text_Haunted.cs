using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Haunted : MonoBehaviour {
	private Text text;
	// Use this for initialization
	void Start () {
		text =GetComponent<Text>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		text.text = GameManager.instance.haunted.ToString();
	}
}
