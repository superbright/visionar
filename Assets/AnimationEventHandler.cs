using UnityEngine;
using System.Collections;

public class AnimationEventHandler : MonoBehaviour {

	public GameObject[] eventhandlers;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Trigger(int id) {

		Debug.Log ("trigger this clothing " + id);
		foreach (GameObject obj in eventhandlers) {
			obj.SendMessage ("Trigger", id);
		}
	}
}
