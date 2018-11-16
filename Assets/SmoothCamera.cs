using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour {
public GameObject player;

private Vector3 offset = new Vector3(0,0.67f,-2.2f);

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 cola = player.transform.TransformPoint(offset);
		transform.position=Vector3.Lerp(transform.position,cola,8*Time.deltaTime);
		transform.rotation=Quaternion.Lerp(transform.rotation,player.transform.rotation,7*Time.deltaTime);
	}
}
