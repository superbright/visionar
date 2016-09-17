using UnityEngine;
using System.Collections;

public class AnimatorEventHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// the function to be called as an event
	public void PrintEvent(int i) {
		print("PrintEvent: " + i + " called at: " + Time.time);
	}
}
