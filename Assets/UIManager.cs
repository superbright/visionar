using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public GameObject mappanel;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnGUI()
	{

		if (GUI.Button (new Rect (10, 10, 300, 60), "AR SCENE")) {
			mappanel.SetActive (false);
			Application.LoadLevel (0);

		}
	}
	void OnLevelWasLoaded() {
		//mappanel.SetActive (true);
	}

	void OnEnable() {
		mappanel.SetActive (false);
		StartCoroutine (dumb ());
	}

	IEnumerator dumb() {
		yield return new WaitForSeconds(2.0f);
		mappanel.SetActive (true);
		Canvas.ForceUpdateCanvases();
	

		Debug.Log ("----------------------enable");
	}

	void OnDisable() {
		Debug.Log ("disable");
		mappanel.SetActive (false);
	}
}
	