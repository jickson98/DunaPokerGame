using UnityEngine;
using System.Collections;

public class movee : MonoBehaviour {



	// Use this for initialization
	void Start () {
							
	}
	
	// Update is called once per frame
	void Update () {
	
			transform.Translate (0,-0.05f,0);

		if (transform.localPosition.y < - 2765.0f) {
			transform.localPosition = new Vector3 (0, -412.0f, 0);
		}
	
	}
}
