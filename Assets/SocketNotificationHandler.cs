using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SocketNotificationHandler : MonoBehaviour {

	public UnityEngine.UI.Button connecting;
	public UnityEngine.UI.Button startAnimation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setConnected() {
		//connecting.Select ();
		Debug.Log("connected!");
		connecting.GetComponent<Image>().color = Color.green;
		startAnimation.gameObject.SetActive (false);
	}

	public void setError() {
		//connecting.Select ();
		Debug.Log("connected!");
		connecting.GetComponent<Image>().color = Color.red;
		startAnimation.gameObject.SetActive (true);
	}

	public void startAnimationHandler() {

	}
}
