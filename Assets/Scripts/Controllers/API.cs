using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class API : MonoBehaviour {

    public const string endpoint = "http://35.185.26.14:3000/books";
    public const string searchEndpoint = "http://35.185.26.14:3000/search?keyword=";
    public static API instance;

    private List<BookInfo> books ;

    public static List<BookInfo> Books
    {
        get
        {
            return instance.books;
        }

        set
        {
            instance.books = value;
        }
    }

    public static BookInfo NextBook {
        get {
            if (Books.Count > 0)
            {
                BookInfo _book = Books[0];
                Books.Remove(Books[0]);
                return _book;
            }
            else
                return null;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public static void DownloadBooks(Action<List<BookInfo>> onDownload)
    {
        instance.StartCoroutine(instance.StartDownloadBooks(onDownload));
    }

    public static void GetBooks(Action<List<BookInfo>> onDownload)
    {
        if (Books != null)
        {
            if (Books.Count>0)
                onDownload(Books);
            else instance.StartCoroutine(instance.StartDownloadBooks(onDownload));
        }
        else
            instance.StartCoroutine(instance.StartDownloadBooks(onDownload));
    }

    public IEnumerator StartDownloadBooks(Action<List<BookInfo>> onDownload)
    {
        WWW www = new WWW(endpoint);
        yield return www;
        if (string.IsNullOrEmpty(www.error))
        {
            
            books = new List<BookInfo>();
            SimpleJSON.JSONNode node = SimpleJSON.JSONNode.Parse(www.text);

            //int i = 0;
            foreach (var item in node.Children)
            {
                BookInfo info = JsonUtility.FromJson<BookInfo>(item.ToString());
                books.Add( info);
                //i++;
                //if (i > 99) break;
            }
        }
        else
        {
            //Log error
            Debug.LogError(www.error);
        }

        onDownload(books);

        yield break;
    }

    public static Action onSearchResult = ()=> { };


    public static void Search(string query) {
        instance.StartCoroutine(instance.StartSearch(query.Replace(" ","")));
    }

    IEnumerator StartSearch(string query) {
        WWW www = new WWW(searchEndpoint+query);
        //Debug.LogError(searchEndpoint + query +"**");
        yield return www;
        //Debug.LogError(www.text);

        if (string.IsNullOrEmpty(www.error))
        {

            books = new List<BookInfo>();
            SimpleJSON.JSONNode node = SimpleJSON.JSONNode.Parse(www.text);
            NotificationArea.Text = "Search done, "+node.Count.ToString()+" results found";

            foreach (var item in node.Children)
            {
                BookInfo info = JsonUtility.FromJson<BookInfo>(item.ToString());
                books.Add(info);
            }

            if (onSearchResult != null) onSearchResult();
        }
        else
        {
            Debug.LogError(www.error);
        }
    }

}
