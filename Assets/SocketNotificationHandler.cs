using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SocketNotificationHandler : MonoBehaviour {

	public UnityEngine.UI.Button connecting;
	public UnityEngine.UI.Button startAnimation;
	public TMPro.TMP_Text statusText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setConnected() {
		connecting.GetComponent<Image>().color = Color.green;
		startAnimation.gameObject.SetActive (false);
		startAnimation.GetComponentInChildren<Text> ().text = "CONNECTED";
	}

	public void setError() {
		//connecting.Select ();
		//Debug.Log("connected!");
		connecting.GetComponent<Image>().color = Color.red;
		startAnimation.gameObject.SetActive (true);
		startAnimation.GetComponentInChildren<Text> ().text = "MANUL START";
	}

	public void startAnimationHandler() {
		connecting.GetComponent<Image>().color = Color.white;
	}
}
