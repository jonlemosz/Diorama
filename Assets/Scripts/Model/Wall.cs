using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Wall
{
    private List<Shelf> shelves;

    public Wall()
    {
        shelves = new List<Shelf>();
    }

    public List<Shelf> Shelves
    {
        get
        {
            return shelves;
        }

        set
        {
            shelves = value;
        }
    }
}