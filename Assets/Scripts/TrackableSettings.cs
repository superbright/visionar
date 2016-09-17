/*===============================================================================
Copyright (c) 2015-2016 PTC Inc. All Rights Reserved.
 
Copyright (c) 2015 Qualcomm Connected Experiences, Inc. All Rights Reserved.
 
Vuforia is a trademark of PTC Inc., registered in the United States and other 
countries.
===============================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Vuforia;

public class TrackableSettings : MonoBehaviour
{
    #region PROTECTED_MEMBERS
   [SerializeField] protected bool mExtTrackingEnabled = false;
	[SerializeField] protected bool mPersistActivated = false;
    #endregion //PROTECTED_MEMBERS


    #region PUBLIC_METHODS
    public bool IsExtendedTrackingEnabled()
    {
        return mExtTrackingEnabled;
    }


	void Start() {
		VuforiaBehaviour.Instance.RegisterVuforiaStartedCallback ( OnVuforiaStarted );
	}

	void Update()
	{
//		if (!mPersistActivated) 
//		{
//			ObjectTracker tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
//			tracker.PersistExtendedTracking ( true ); 
//			mPersistActivated = true;
//		}
	}

	private void OnVuforiaStarted() {

		var tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
		bool tsuccess = tracker.PersistExtendedTracking ( true); // or false, to disable it
		if (tsuccess)
		{
			Debug.Log("PersistentExtendedTrackingEnabled");
		}
		SwitchExtendedTracking (true);
	}

	void OnGUI() {

		if(GUI.Button(new Rect(10,300,100,50),"RESET")) {
			var tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
			bool tsuccess = tracker.PersistExtendedTracking ( true); // or false, to disable it
			if (tsuccess)
			{
				Debug.Log("PersistentExtendedTrackingEnabled");
			}
			tracker.ResetExtendedTracking();
		}

		if(GUI.Button(new Rect(10,350,100,50),"Start Extended T")) {
			SwitchExtendedTracking (true);
		}

		if(GUI.Button(new Rect(10,400,100,50),"Stop Extended T")) {
			SwitchExtendedTracking (false);
		}

		if(GUI.Button(new Rect(10,450,100,50),"PET")) {
			var tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
			bool tsuccess = tracker.PersistExtendedTracking ( true); // or false, to disable it
			if (tsuccess)
			{
				Debug.Log("PersistentExtendedTrackingEnabled");
			}
		}
		if(GUI.Button(new Rect(10,500,100,50),"PET OFF")) {
			var tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
			bool tsuccess = tracker.PersistExtendedTracking ( false); // or false, to disable it
			if (tsuccess)
			{
				Debug.Log("PersistentExtendedTrackingDisabled");
			}
		}
		if(GUI.Button(new Rect(10,550,100,50),"STOP")) {
			var tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
			tracker.Stop ();
		}
		if(GUI.Button(new Rect(10,600,100,50),"START")) {
			var tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
			tracker.Start ();
		}
	}

    /// <summary>
    /// Enabled/disabled Extended Tracking mode.
    /// </summary>
    /// <param name="ON"></param>
    public virtual void SwitchExtendedTracking(bool extTrackingEnabled)
    {
        StateManager stateManager = TrackerManager.Instance.GetStateManager();

        // We iterate over all TrackableBehaviours to start or stop extended tracking for the targets they represent.
        bool success = true;
        foreach (var tb in stateManager.GetTrackableBehaviours())
        {
			
            if (tb is ImageTargetBehaviour)
            {
                ImageTargetBehaviour itb = tb as ImageTargetBehaviour;
				if (extTrackingEnabled)
                {
                    if (!itb.ImageTarget.StartExtendedTracking())
                    {
                        success = false;
                        Debug.LogError("Failed to start Extended Tracking on Target " + itb.TrackableName);
                    }

					Debug.Log (tb.TrackableName + " " + "extended enabled");
                }
                else
                {
                    itb.ImageTarget.StopExtendedTracking();
					Debug.Log (tb.TrackableName + " " + "extended stopped");
                }
            }
          
        }
        mExtTrackingEnabled = success && extTrackingEnabled;

				
    }

    public string GetActiveDatasetName()
    {
        ObjectTracker tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
        List<DataSet> activeDataSets = tracker.GetActiveDataSets().ToList();
        if (activeDataSets.Count > 0)
        {
            string datasetPath = activeDataSets.ElementAt(0).Path;
            string datasetName = datasetPath.Substring(datasetPath.LastIndexOf("/") + 1);
            return datasetName.TrimEnd(".xml".ToCharArray());
        }
        else
        {
            return string.Empty;
        }
    }

    public void ActivateDataSet(string datasetName)
    {
        // ObjectTracker tracks ImageTargets contained in a DataSet and provides methods for creating and (de)activating datasets.
        ObjectTracker objectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
        IEnumerable<DataSet> datasets = objectTracker.GetDataSets();

        IEnumerable<DataSet> activeDataSets = objectTracker.GetActiveDataSets();
        List<DataSet> activeDataSetsToBeRemoved = activeDataSets.ToList();

        // 1. Loop through all the active datasets and deactivate them.
        foreach (DataSet ads in activeDataSetsToBeRemoved)
        {
            objectTracker.DeactivateDataSet(ads);
        }

        // Swapping of the datasets should NOT be done while the ObjectTracker is running.
        // 2. So, Stop the tracker first.
        objectTracker.Stop();

        // 3. Then, look up the new dataset and if one exists, activate it.
        foreach (DataSet ds in datasets)
        {
            if (ds.Path.Contains(datasetName))
            {
                objectTracker.ActivateDataSet(ds);
            }
        }

        // 4. Finally, restart the object tracker.
        objectTracker.Start();
    }
    #endregion //PUBLIC_METHODS
}
