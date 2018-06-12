using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chamber  {

    private List<Wall> walls;

    public Chamber() {
        Walls = new List<Wall>();
    }

    public List<Wall> Walls
    {
        get
        {
            return walls;
        }

        set
        {
            walls = value;
        }
    }
}
