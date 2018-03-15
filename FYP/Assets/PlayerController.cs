using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float PlayerHeight = 1.0f;

	// Use this for initialization
	void Start () {
        transform.position.Set(transform.position.x,PlayerHeight, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
