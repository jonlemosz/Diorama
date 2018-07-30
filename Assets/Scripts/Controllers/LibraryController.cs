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
    public static BookInfo openBook;

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
        API.onSearchResult += RefillWalls;
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
        //Debug.Log("Geting books");
        API.GetBooks((books) =>
        {
            Debug.Log("Instantiating books");

            // Shuffle books
            Shuffle(books);

            instance.isDownloading = false;
            for (int i = 0; i < instance.wallControllers.Count; i++)
            {
                instance.wallControllers[i].RefillShelves();
            }

            Debug.Log("Library done");

        });
    }

    public static void ShowBookData(BookInfo info) {
        openBook = info;
        instance.bookView_title.text = "Title: "+info.title;
        instance.bookView_author.text = "Author: " + info.author;
        instance.bookView_topic.text = "Topic: " + info.topic;
        instance.bookView_note.text = "Note: " + info.note;
        instance.bookView_location.text = "Location: " + info.location;
    }

    public static void Shuffle(List<BookInfo> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            BookInfo value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
