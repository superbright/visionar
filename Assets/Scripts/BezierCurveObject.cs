﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Scene {
	public Vector3[] VectorCoords;
}

public class BezierCurveObject : MonoBehaviour {

	public Scene[] scenes;
	public LTBezierPath cr;

	public GameObject destionationObject;
	public GameObject outofsceneobject;

	public Vector3 screenscale;
	public Vector3 screenrotation1;
	public Vector3 screenrotation2;
	public Vector3 screenrotation3;

	Renderer[] rendererComponents ;

	void Start() {
		 rendererComponents = GetComponentsInChildren<Renderer>(true);
		// Disable rendering:
		foreach (Renderer component in rendererComponents)
		{
			component.enabled = false;
		}
	}

	public void move (int trigerInt ) {

		if (destionationObject == null)
			return;

		foreach (Renderer component in rendererComponents)
		{
			component.enabled = true;
		}

		IgalsTracking ARTrack = GetComponentInChildren<IgalsTracking>();
		ARTrack.isAnimating = true;

		scenes [0].VectorCoords [0] = gameObject.transform.position;
		scenes [0].VectorCoords [3] = destionationObject.transform.position;

		cr = new LTBezierPath (scenes [0].VectorCoords);
		if (screenscale != Vector3.zero) {
			LeanTween.scale (gameObject, screenscale, 0.5f).setDelay(0.2f);
		}

		if (screenrotation1 != Vector3.zero) {
			LeanTween.rotateLocal (gameObject, screenrotation1, 0.6f).setEase (LeanTweenType.easeInBack).setDelay(0.2f);
		}
		else
		{
			LeanTween.rotateLocal (gameObject, new Vector3 (0, 25, 0), 0.6f).setEase (LeanTweenType.easeInBack).setDelay(0.2f);
		}
			
		LeanTween.move(gameObject, cr.pts, 0.9f).setEase(LeanTweenType.easeInQuad).setDelay(0.2f).setOrientToPath(false).setOnComplete
		(
			()=>{
							StartCoroutine(CallMoveRoutine());
			}
		);
	}


	public void moveStraight (int trigerInt ) {
		Debug.Log (gameObject.name);
		foreach (Renderer component in rendererComponents)
		{
			component.enabled = true;
		}

		if (destionationObject == null)
			return;

		IgalsTracking ARTrack = GetComponentInChildren<IgalsTracking>();
		ARTrack.isAnimating = true;

		scenes [0].VectorCoords [0] = gameObject.transform.position;
		scenes [0].VectorCoords [3] = destionationObject.transform.position;
		float destY = destionationObject.transform.position.y;
		float destX = destionationObject.transform.position.x;
		float destZ = destionationObject.transform.position.z;

		LeanTween.moveY(gameObject,destY/1.5f,1.2f).setEase(LeanTweenType.easeOutQuad).setDelay(0f).setOnComplete
		(
			()=>{
				LeanTween.moveX(gameObject,destX,0.7f).setEase(LeanTweenType.easeOutQuad).setOnComplete(
					()=>{
						move(0);
					}
				);
			}
		);
	}

	public void RevealDataPart1(float delay) {

		//LeanTween.rot
		if (screenrotation2 != Vector3.zero) {
			LeanTween.rotateLocal(gameObject,screenrotation2,0.6f).setEase(LeanTweenType.easeInQuad).setDelay(delay); //screenrotation2
			//rotate to screenrotation to
		} else {
			LeanTween.rotateLocal(gameObject,Vector3.zero,0.6f).setEase(LeanTweenType.easeInQuad).setDelay(delay); //screenrotation2
		}
	}

	public void RevealDataPart2(float delay) {
		if (screenrotation3 != Vector3.zero) {
			LeanTween.rotateLocal(gameObject,screenrotation3,0.6f).setEase(LeanTweenType.easeInQuad).setDelay(delay); //screenrotation2
			//rotate to screenrotation to
		}else{					  
		//LeanTween.rot
			LeanTween.rotateLocal(gameObject,Vector3.zero,0.6f).setEase(LeanTweenType.easeInQuad).setDelay(delay);  //screenrotation3
		}
	}

	public void SceneOut() {
		scenes [1].VectorCoords [0] = gameObject.transform.position;
		scenes [1].VectorCoords [3] = outofsceneobject.transform.position;

		cr = new LTBezierPath (scenes [1].VectorCoords);
		if (screenscale != Vector3.zero) {
			LeanTween.scale (gameObject, screenscale, 0.5f);
		}

		LeanTween.move(gameObject, cr.pts, 1.2f).setEase(LeanTweenType.easeInQuad).setDelay(2.0f).setOrientToPath(false).setOnComplete(
			()=>{
				
			}

		);

	}

	public IEnumerator CallMoveRoutine(){
		yield return new WaitForSeconds(2.0f);
		RevealDataPart1(1.0f);
		yield return new WaitForSeconds(3.0f);
		RevealDataPart2 (1.5f);
		yield return new WaitForSeconds(4.0f);
		SceneOut ();
	}
}
