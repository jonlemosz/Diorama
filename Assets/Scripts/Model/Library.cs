using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library{

    private static Library instance;
    private Chamber chamber;

    public Library()
    {
        Chamber = new Chamber();
    }

    public static Library Instance
    {
        get
        {
            if (instance == null) instance = new Library();
            return instance;
        }
    }

    public Chamber Chamber
    {
        get
        {
            return chamber;
        }

        set
        {
            chamber = value;
        }
    }
}
