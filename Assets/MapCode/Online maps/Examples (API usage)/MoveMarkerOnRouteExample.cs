/*     INFINITY CODE 2013-2016      */
/*   http://www.infinity-code.com   */

using System.Collections.Generic;
using UnityEngine;

namespace InfinityCode.OnlineMapsExamples
{
    /// <summary>
    /// Example of simulation movement marker on the route.
    /// </summary>
    [AddComponentMenu("Infinity Code/Online Maps/Examples (API Usage)/MoveMarkerOnRouteExample")]
    public class MoveMarkerOnRouteExample : MonoBehaviour
    {

		public string homeAddress = "537 W 27th St New York, NY";
        /// <summary>
        /// Start location name
        /// </summary>
        public string fromPlace = "Los Angeles";

        /// <summary>
        /// End location name
        /// </summary>
        public string toPlace = "Hollywood";

        /// <summary>
        /// Speed of movement (km/h).
        /// </summary>
        public float speed = 60;

        /// <summary>
        /// Move map to marker position
        /// </summary>
        public bool lookToMarker = false;

        /// <summary>
        /// Orient marker on next point.
        /// </summary>
        public bool orientMarkerOnNextPoint = false;

        /// <summary>
        /// Reference to marker
        /// </summary>
        private OnlineMapsMarker marker;

        /// <summary>
        /// Array of route points
        /// </summary>
        private List<Vector2> points;

        /// <summary>
        /// Current point index
        /// </summary>
        private int pointIndex = -1;

        /// <summary>
        /// Current step progress
        /// </summary>
        private float progress;


		private OnlineMapsMarker searchMarker;


		public void findpath(int id) {
			
			fromPlace = AppState.ProductAddress [(AppState.PRODUCTS)id].fromAddress;
			toPlace = AppState.ProductAddress [(AppState.PRODUCTS)id].toAddress;
			OnlineMapsFindDirection.Find(fromPlace, toPlace).OnComplete += OnComplete;
		}

        private void Start()
        {
			// Gets Location Service Component.
//			OnlineMapsLocationService ls = OnlineMapsLocationService.instance;
//
//			if (ls == null)
//			{
//				Debug.LogError(
//					"Location Service not found.\nAdd Location Service Component (Component / Infinity Code / Online Maps / Plugins / Location Service).");
//				return;
//			}
//
//
//			ls.OnCompassChanged += OnCompassChanged;
			Debug.Log("find address " + homeAddress);
			OnlineMapsFindLocation.Find (homeAddress).OnComplete += OnFindLocationComlete;
			
            // Looking for a route between locations.
           // OnlineMapsFindDirection.Find(fromPlace, toPlace).OnComplete += OnComplete;
        }

	
		private void OnFindLocationComlete(string result) {

			Debug.Log ("complete home location search " + result);
			//OnlineMapsMarker marker = OnlineMapsFindLocationResult
			Vector2 position = OnlineMapsFindLocation.GetCoordinatesFromResult(result);
			Debug.Log (position);

			if (position == Vector2.zero) return;

			if (searchMarker == null) 
			{
				Debug.Log ("OK");
				searchMarker = OnlineMaps.instance.AddMarker (position, "XAD");
			} else
			{
				searchMarker.position = position;
				searchMarker.label = "XAD";
			}

			//if (api.zoom < 13) api.zoom = 13;

			OnlineMaps.instance.position = position;
			OnlineMaps.instance.Redraw();

		}

		/// <summary>
		/// This method is called when the compass value is changed.
		/// </summary>
		/// <param name="f">New compass value (0-1)</param>
		private void OnCompassChanged(float f)
		{
			// Rotate the camera.
			OnlineMapsTileSetControl.instance.cameraRotation.y = f * 360;
		}

        private void OnComplete(string response)
        {
			OnlineMaps.instance.RemoveMarkerAt(0);
			OnlineMaps.instance.RemoveAllDrawingElements ();
			
			OnlineMapsFindDirection.Find(fromPlace, toPlace).OnComplete -= OnComplete;

            List<OnlineMapsDirectionStep> steps = OnlineMapsDirectionStep.TryParse(response);
            if (steps == null)
            {
                Debug.Log("Something wrong");
                Debug.Log(response);
                return;
            }

            // Create a new marker in first point.
            marker = OnlineMaps.instance.AddMarker(steps[0].start, "XAD");

            // Gets points of route.
            points = OnlineMapsDirectionStep.GetPoints(steps);

            // Draw the route.
            OnlineMapsDrawingLine route = new OnlineMapsDrawingLine(points, Color.red, 1);
            OnlineMaps.instance.AddDrawingElement(route);

			OnlineMaps.instance.position = marker.position;
			OnlineMaps.instance.Redraw();

            pointIndex = 0;
        }

        private void Update()
        {
		//	Debug.Log (Input.acceleration.x + "  " + Input.acceleration.y + " " + Input.acceleration.z);
			//Debug.Log (Input.gyro. + "  " + Input.acceleration.y + " " + Input.acceleration.z);

			OnlineMapsTileSetControl.instance.cameraRotation.y = Input.acceleration.x;
				
            if (pointIndex == -1) return;

            // Start point
            Vector3 p1 = points[pointIndex];

            // End point
            Vector3 p2 = points[pointIndex + 1];

            // Total step distance
            float stepDistance = OnlineMapsUtils.DistanceBetweenPoints(p1, p2).magnitude;

            // Total step time
			float totalTime =  stepDistance / speed * 3600;

            // Current step progress
            progress += Time.deltaTime / totalTime;

            if (progress < 1)
            {
	
                marker.position = Vector2.Lerp(p1, p2, 0.002f);

                // Orient marker
                if (orientMarkerOnNextPoint) marker.rotation = 1.25f - OnlineMapsUtils.Angle2D((Vector2)p1, (Vector2)p2) / 360f;
            }
            else
            {
                marker.position = p2;
                pointIndex++;
                progress = 0;
                if (pointIndex >= points.Count - 1)
                {
                    Debug.Log("Finish");
                    pointIndex = -1;
                }
                else
                {
                    // Orient marker
					if (orientMarkerOnNextPoint) marker.rotation = 1.25f - OnlineMapsUtils.Angle2D((Vector2)p2, (Vector2)points[pointIndex + 1]) / 60f;
                }
            }

            if (lookToMarker) OnlineMaps.instance.position = marker.position;
            OnlineMaps.instance.Redraw();
        }
    }
}