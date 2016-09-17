using UnityEngine;
using System.Collections;

public class PathSplines : MonoBehaviour {

	public Transform[] trans;
	
	LTSpline cr;
	private GameObject avatar1;
	public GameObject wall;

	public int ypos;

	void OnEnable(){
		if(trans.Length > 0)
			cr = new LTSpline( new Vector3[] {trans[0].position, trans[1].position, trans[2].position, trans[3].position, trans[4].position} );
	}

	void Start () {

		if(trans.Length > 0) {
			avatar1 = GameObject.Find("Avatar1");
			// Tween automatically
			LeanTween.move(avatar1, cr, 2.5f).setOrientToPath(true).setRepeat(1).setOnComplete( ()=>{
				Vector3[] next = new Vector3[] {trans[4].position, trans[3].position, trans[2].position, trans[1].position, trans[0].position};
				LeanTween.moveSpline( avatar1, next, 2.5f); // move it back to the start without an LTSpline
			}).setEase(LeanTweenType.easeOutQuad);
		}
	}
	
	private float iter;
	void Update () {
		
	}

	void OnGUI() {

		if (GUI.Button (new Rect(10,ypos,300,100), "ANIMATE")) {
			// Tween automatically
		
			LeanTween.moveY (wall, -10f, 0.4f).setRepeat (1).setOnComplete (() => {
				LeanTween.moveY (wall, 40f, 0.4f);

			}).setEase (LeanTweenType.easeOutQuad);

			if (trans.Length > 0) {
				// Tween automatically
				LeanTween.move (avatar1, cr, 2.5f).setOrientToPath (true).setRepeat (1).setOnComplete (() => {
					Vector3[] next = new Vector3[] {
						trans [4].position,
						trans [3].position,
						trans [2].position,
						trans [1].position,
						trans [0].position
					};
					LeanTween.moveSpline (avatar1, next, 2.5f); // move it back to the start without an LTSpline
				}).setEase (LeanTweenType.easeOutQuad);
			}
				
		}

	}

	void OnDrawGizmos(){
		// Debug.Log("drwaing");
		if(cr==null)
			OnEnable();
		Gizmos.color = Color.red;
		if(cr!=null)
			cr.gizmoDraw(); // To Visualize the path, use this method
	}
		
}
