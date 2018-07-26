using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour {

    public float radious;
    public LayerMask lMask;

    [SerializeField]
    private Transform trackedObject;
    public bool isLeft = false;

    public Transform TrackedObject
    {
        get
        {
            return trackedObject;
        }

        set
        {
            if (value == null)
                trackedObject.GetComponentInChildren<BookController>().grabbed = false;
            else value.GetComponentInChildren<BookController>().grabbed = true;

            trackedObject = value;
        }
    }

    public bool useTestingGrip = false;
    public bool testingGripValue = false;

    // Update is called once per frame
    void Update () {


        bool grip = isLeft ? MyInput.ControllerL.GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger) : 
                             MyInput.ControllerR.GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger);
        if (useTestingGrip) grip = testingGripValue;
        /*bool trigger = isLeft ? MyInput.ControllerL.GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger) :
                             MyInput.ControllerR.GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger);*/

        //Debug.Log("Grip "+grip);

        if (grip)
        {
            if (!TrackedObject) CastSphere();
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
            if (TrackedObject)
            {
                TrackedObject.parent = null;
                TrackedObject.GetComponent<Rigidbody>().isKinematic = false;
                TrackedObject = null;

            }
        }
    }

    void CastSphere() {

        Collider[] visibleObjects = Physics.OverlapSphere(transform.position, radious, lMask);
        Debug.LogError("Visible objects: " + visibleObjects.Length);
        if (visibleObjects.Length > 0)
        {
            TrackedObject = visibleObjects[0].transform;
            TrackedObject.parent = transform;
            TrackedObject.GetComponent<Rigidbody>().isKinematic = true;
            LibraryController.ShowBookData(TrackedObject.GetComponentInChildren<BookController>().info);
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radious);
    }
}
