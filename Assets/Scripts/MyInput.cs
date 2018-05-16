using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInput : MonoBehaviour {

    public SteamVR_TrackedObject trackedObjectL;
    public SteamVR_TrackedObject trackedObjectR;
    public Transform head;

    static MyInput instance;

    public static SteamVR_Controller.Device ControllerR
    {
        get { return SteamVR_Controller.Input((int)instance.trackedObjectR.index); }
    }

    public static SteamVR_Controller.Device ControllerL
    {
        get { return SteamVR_Controller.Input((int)instance.trackedObjectL.index); }
    }

    public static SteamVR_Controller.Device Controller (int id)
    {
        return SteamVR_Controller.Input(id);
    }

    public static Transform Head
    {
        get
        {
            return instance.head;
        }
    }

    void Awake() {
        instance = this;
    }
}
