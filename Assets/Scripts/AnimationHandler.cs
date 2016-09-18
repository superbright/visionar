using UnityEngine;
using System.Collections.Generic;
using System.Collections;

/// <summary>
/// Handle Animation for a list of objects
/// </summary>
public class AnimationHandler : MonoBehaviour
{
	[Header("Clothing for models")]
	[SerializeField] public BezierCurveObject[] objectsModel1;


	int currentScene = 0; // we have total of 16 scenes
	int currentModel = 0;
	int totalScenes = 16;

	public Animator LeftMarkerAnimator;
	public Animator RightMarkerAnimator;
	public Animator MapAnimator;
	public Animator CenterAnimations;

	public UnityEngine.UI.Text sceneid;

	bool ready = true;

	public GameObject map2d;
	public MapMotion mapmotion;

		
	int IndtoScene1;
	int Scene1toInd;
	int IndtoScene2;
	int Scene2toInd;

	Dictionary<AppState.ANIMATIONSTATES,BezierCurveObject[]> animationObjects;

	public GameObject positionobject;


	void Start ()
	{	
	    
		 IndtoScene1 = Animator.StringToHash ("Ind-Scene1");
		 Scene1toInd = Animator.StringToHash ("Scene1-Ind");

		IndtoScene2 = Animator.StringToHash ("Ind-Scene2");
		Scene2toInd = Animator.StringToHash ("Scene2-Ind");

		ready = true;
		sceneid.text = "home";



	}


	void OnGUI ()
	{
		if (ready) {
			if (GUI.Button (new Rect (10, 70, 300, 60), "BEGIN ANIMATION")) {
				StartCoroutine (AnimationSequence ());
			}

		}

		if (GUI.Button (new Rect (10, 10, 300, 60), "FINAL MAP SCENE")) {
			Application.LoadLevel(1);
			//mapmotion.animateforward ();
//			for (int k = 0; k < animatingObjects.Length; k++) {
//				animatingObjects[k].move(0);
//			}
		}

//		if (GUI.Button (new Rect (10, 130, 300, 60), "ANIM")) {
//			for (int k = 0; k < 3; k++) {
//				objectsModel1[k].move (Scene1toInd);
//			}
//		}

		if (GUI.Button (new Rect (10, 130, 300, 60), "SCENE1")) {
			for (int k = 0; k < 3; k++) {
				objectsModel1[k].move (Scene1toInd);
			}
			objectsModel1[10].move (Scene1toInd);
		}
		if (GUI.Button (new Rect (10, 190, 300, 60), "SCENE2")) {
			for (int k = 3; k < 5; k++) {
				objectsModel1[k].move (Scene1toInd);
			}
			objectsModel1[11].move (Scene1toInd);
		}
		if (GUI.Button (new Rect (10, 250, 300, 60), "SCENE3")) {
			for (int k = 5; k < 8; k++) {
				objectsModel1[k].move (Scene1toInd);
			}
		}
		if (GUI.Button (new Rect (10, 310, 300, 60), "SCENE4")) {
			for (int k = 8; k < 10; k++) {
				objectsModel1[k].move (Scene1toInd);
			}
			objectsModel1[12].move (Scene1toInd);
			objectsModel1[13].move (Scene1toInd);
		}



//		if (GUI.Button (new Rect (10, 190, 300, 60), "Move POS Y +5")) {
//			Vector3 pos = positionobject.transform.position;
//			LeanTween.move (positionobject, new Vector3 (pos.x, pos.y + 5, pos.z), 0.4f);
//			Debug.Log (new Vector3 (pos.x, pos.y + 5, pos.z));
//		}
//		if (GUI.Button (new Rect (10, 250, 300, 60), "Move POS Y -5")) {
//			Vector3 pos = positionobject.transform.position;
//			LeanTween.move (positionobject, new Vector3 (pos.x, pos.y - 5, pos.z), 0.4f);
//			Debug.Log (new Vector3 (pos.x, pos.y - 5, pos.z));
//		}
//		if (GUI.Button (new Rect (10, 310, 300, 60), "Move POS X -5")) {
//			Vector3 pos = positionobject.transform.position;
//			LeanTween.move (positionobject, new Vector3 (pos.x - 5, pos.y, pos.z), 0.4f);
//			Debug.Log (new Vector3 (pos.x-5, pos.y, pos.z));
//		}
//		if (GUI.Button (new Rect (10, 310, 300, 60), "Move POS X +5")) {
//			Vector3 pos = positionobject.transform.position;
//			LeanTween.move (positionobject, new Vector3 (pos.x +5, pos.y, pos.z), 0.4f);
//			Debug.Log (new Vector3 (pos.x+5, pos.y, pos.z));
//		}
//		if (GUI.Button (new Rect (10, 370, 300, 60), "Move POS Z -5")) {
//			Vector3 pos = positionobject.transform.position;
//			LeanTween.move (positionobject, new Vector3 (pos.x, pos.y, pos.z - 5), 0.4f);
//			Debug.Log (new Vector3 (pos.x, pos.y, pos.z-5));
//		}
//		if (GUI.Button (new Rect (10, 430, 300, 60), "Move POS Z +5")) {
//			Vector3 pos = positionobject.transform.position;
//			LeanTween.move (positionobject, new Vector3 (pos.x, pos.y, pos.z + 5), 0.4f);
//			Debug.Log (new Vector3 (pos.x, pos.y, pos.z + 5));
//		}

	}

	public void letthisfuckerstart() {
		StartCoroutine (AnimationSequence ());
	}

	public void Trigger(int id) {
		if (id > 16)
			return;
		objectsModel1[id-1].move (Scene1toInd);

	}

	/// <summary>
	/// Gets the triggername from our enum
	/// </summary>
	/// <returns>The triggername.</returns>
	/// <param name="scene">Scene.</param>
	public string getTriggername(int scene) {
		string triggername = ((AppState.ANIMATIONSTATES)scene).ToString();
		return triggername.Replace ('_', '-');
	}

	public IEnumerator AnimationSequence() {
		ready = false;
		sceneid.text = "scene1";

		
		string trigger = getTriggername (currentScene);

		LeftMarkerAnimator.SetTrigger (trigger);
		RightMarkerAnimator.SetTrigger (trigger);
		MapAnimator.SetTrigger (trigger);
		CenterAnimations.SetTrigger (trigger);
		yield return new WaitForSeconds(10.0f);
		currentScene++;

		if (currentScene % 4 == 0) {
			currentModel++;
		}

		StartCoroutine (AnimationSequence ());

	}


	public IEnumerator AnimSequence() {

		ready = false;
		sceneid.text = "scene1";

		LeftMarkerAnimator.SetTrigger ("IDLEtoScene1");
		RightMarkerAnimator.SetTrigger ("IDLEtoScene1");
		yield return new WaitForSeconds(10.0f);

		sceneid.text = "scene2";
		LeftMarkerAnimator.SetTrigger ("Scene1toScene2");
		RightMarkerAnimator.SetTrigger ("Scene1toScene2");
		yield return new WaitForSeconds(10.0f);

		sceneid.text = "scene3";
		LeftMarkerAnimator.SetTrigger ("Scene2toScene3");
		RightMarkerAnimator.SetTrigger ("Scene2toScene3");
		yield return new WaitForSeconds(5.0f);
		for (int k = 0; k < objectsModel1.Length; k++) {
			objectsModel1[k].move (Scene1toInd);
		}
		yield return new WaitForSeconds(4.0f);


		sceneid.text = "scene4";
		LeftMarkerAnimator.SetTrigger ("Scene3toScene4");
		RightMarkerAnimator.SetTrigger ("Scene3toScene4");
		yield return new WaitForSeconds(3.0f);


		for (int k = 0; k < objectsModel1.Length; k++) {
			objectsModel1 [k].RevealDataPart1 (k * 0.2f);
		}

		map2d.SetActive (true);
		mapmotion.animateforward ();

		yield return new WaitForSeconds(8.0f);
		map2d.SetActive (false);

		for (int k = 0; k < objectsModel1.Length; k++) {
			objectsModel1[k].SceneOut();
		}

		yield return new WaitForSeconds(2.0f);

		sceneid.text = "home";
		LeftMarkerAnimator.SetTrigger ("Scene4toIdle");
		RightMarkerAnimator.SetTrigger ("Scene4toIdle");

		ready = true;
	}


	void OnComplete (object completedObject)
	{
		GameObject obj = (GameObject)completedObject;
		Debug.Log (obj);
		Debug.Log (obj.name);

	}

}
	