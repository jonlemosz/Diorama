using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour {

    public float radious;
    public LayerMask lMask;

    public Transform trackedObject;
    public bool isLeft = false;

	// Update is called once per frame
	void Update () {


        bool grip = isLeft ? MyInput.ControllerL.GetPress(Valve.VR.EVRButtonId.k_EButton_Grip) : 
                             MyInput.ControllerR.GetPress(Valve.VR.EVRButtonId.k_EButton_Grip);

        /*bool trigger = isLeft ? MyInput.ControllerL.GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger) :
                             MyInput.ControllerR.GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger);*/

        Debug.Log("Grip "+grip);

        if (grip)
        {
            if (!trackedObject) CastSphere();
            else {
                /*if (trigger)
                {
                    try
                    {
                        LibraryController.ShowBookData(trackedObject.GetComponentInChildren<BookController>().info);
                    }
                    catch (System.Exception e)
                    { }
                }*/
            }
        }
        else {
            if (trackedObject)
            {
                trackedObject.parent = null;
                trackedObject.GetComponent<Rigidbody>().isKinematic = false;
                trackedObject = null;

            }
        }
    }

    void CastSphere() {

        Collider[] visibleObjects = Physics.OverlapSphere(transform.position, radious, lMask);
        Debug.LogError("Visible objects: " + visibleObjects.Length);
        if (visibleObjects.Length > 0)
        {
            trackedObject = visibleObjects[0].transform;
            trackedObject.parent = transform;
            trackedObject.GetComponent<Rigidbody>().isKinematic = true;
            LibraryController.ShowBookData(trackedObject.GetComponentInChildren<BookController>().info);
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radious);
    }
}
