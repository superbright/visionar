using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MechanimController : MonoBehaviour {

	public Animator animator;
	AnimationClip clip;

	void Awake() {


	}
	// Use this for initialization
	void Start () {

		Debug.Log (animator.layerCount);
		for (int k = 0; k < animator.layerCount; k++) {
			Debug.Log (animator.GetLayerName (k));
		}
			
		//Debug.Log (animator.GetLayerName (0));
	
		// new event created
		AnimationEvent evt;
		evt = new AnimationEvent();

		// put some parameters on the AnimationEvent
		//  - call the function called PrintEvent()
		//  - the animation on this object lasts 2 seconds
		//    and the new animation created here is
		//    set up to happens 1.3s into the animation		
		evt.intParameter = 12345;
		evt.time = 1.0f;
		evt.functionName = "PrintEvent";

		clip = animator.runtimeAnimatorController.animationClips[0];

		clip.AddEvent(evt);

	}

	void OnGUI() {
		if (GUILayout.Button ("TEST")) {
			animator.SetLayerWeight (0, 0.0f);
			animator.SetLayerWeight (1, 1.0f);

		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
