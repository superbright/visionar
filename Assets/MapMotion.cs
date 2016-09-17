using UnityEngine;
using System.Collections;

public class MapMotion : MonoBehaviour {

	public GameObject b1;
	public Vector3 destination;
	Vector3 origin;
	// Use this for initialization
	void Start () {
		origin = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void animateforward() {
		LeanTween.moveLocal (b1, destination, 2f);
	}

	public void animateback() {
		LeanTween.moveLocal (b1, origin, 2f);
	}
}
