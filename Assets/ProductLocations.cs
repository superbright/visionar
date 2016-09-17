using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class XadPath {
	public string fromAddress;
	public string toAddress;

	public XadPath(string f, string t) {
		fromAddress = f;
		toAddress = t;
	}
}


public class ProductLocations : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
