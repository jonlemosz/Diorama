using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryController : MonoBehaviour {


    List<WallController> wallControllers;

    // Use this for initialization
    void Start()
    {
        wallControllers = new List<WallController>(GetComponentsInChildren<WallController>());
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RefillWalls();
        }
    }

    void RefillWalls()
    {
        for (int i = 0; i < wallControllers.Count; i++)
        {
            wallControllers[i].RefillShelves();
        }
    }
}
