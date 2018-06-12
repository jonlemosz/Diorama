using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibraryController : MonoBehaviour {

    public Text bookView_title;
    public Text bookView_author;
    public Text bookView_topic;
    public Text bookView_note;
    public Text bookView_location;

    List<WallController> wallControllers;
    public static LibraryController instance;

    bool isDownloading = false;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    IEnumerator Start()
    {
        wallControllers = new List<WallController>(GetComponentsInChildren<WallController>());
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        RefillWalls();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RefillWalls();
        }
    }

    public void Next()
    {
        //Load books (next self collection)
        RefillWalls();
    }

   
    public static void RefillWalls()
    {
        if (instance.isDownloading) return;

        instance.isDownloading = true;
        Debug.Log("Geting books");
        API.GetBooks((books) =>
        {
            Debug.Log("Instantiating books");

            instance.isDownloading = false;
            for (int i = 0; i < instance.wallControllers.Count; i++)
            {
                instance.wallControllers[i].RefillShelves();
            }

            Debug.Log("Library done");

        });


        
    }

    public static void ShowBookData(BookInfo info) {
        instance.bookView_title.text = "Title: "+info.title;
        instance.bookView_author.text = "Author: " + info.autor;
        instance.bookView_topic.text = "Topic: " + info.topic;
        instance.bookView_note.text = "Note: " + info.note;
        instance.bookView_location.text = "Location: " + info.location;
    }

}
