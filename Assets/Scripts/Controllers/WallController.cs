using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {

    List<ShelveController> shelveControllers;

	// Use this for initialization
	void Start () {
        shelveControllers = new List<ShelveController>(GetComponentsInChildren<ShelveController>());
	}

    public void RefillShelves()
    {
        for (int i = 0; i < shelveControllers.Count; i++)
        {
            shelveControllers[i].Fill();
        }
    }
}
