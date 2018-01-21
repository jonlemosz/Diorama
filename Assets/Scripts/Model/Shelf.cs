using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf{

    private List<Book> books;

    public Shelf()
    {
        books = new List<Book>();
    }

    public List<Book> Books
    {
        get
        {
            return books;
        }

        set
        {
            books = value;
        }
    }
}
