using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book{

    private List<string> pages;
    private string title;

    public Book() {
        pages = new List<string>();
    }

    public List<string> Pages
    {
        get
        {
            return pages;
        }

        set
        {
            pages = value;
        }
    }

    public string Title
    {
        get
        {
            return title;
        }

        set
        {
            title = value;
        }
    }
}
