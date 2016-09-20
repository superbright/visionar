using UnityEngine;
using System.Collections;

public class OnInitSetup : MonoBehaviour {

	public bool isIpad;
	public float xOffset = 0;
	public float yOffset = 0;
	// Use this for initialization
	void Start () {

		if (isIpad) {
			Vector3 currentLoc = transform.position;
			currentLoc.x += xOffset;
			currentLoc.y += yOffset;
			this.transform.position = currentLoc;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
