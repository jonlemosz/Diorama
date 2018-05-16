//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInfo {
    public string title;
    public string autor;
    public string topic;
    public string note;
    public string location;
}

public class BookController : MonoBehaviour {

    RectTransform titleCanvasRect;
    [SerializeField]Vector3 bookScale;
    public Transform mesh;
    public Canvas canvas;
    public Color color = new Color(1,1,1,1);

    public BookInfo info;

    private void Init()
    {
        Color[] colors = new Color[] { Color.white, Color.yellow, Color.red, Color.magenta, Color.gray, Color.green, Color.cyan, Color.blue };
        color = colors[Random.Range(0, colors.Length - 1)];

        info = new BookInfo();
        info.title = RandomString(10, 20);
        info.autor = RandomString(10, 20);
        info.topic = RandomString(15, 20);
        info.note = RandomString(50, 100);
        info.note = RandomString(30, 50);

        GetComponentInChildren<UnityEngine.UI.Text>().text = info.title;
    }

    private string RandomString(int min, int max)
    {
        char[] chars = "qwertyuiopasdfghjklzxcvbnm   ".ToCharArray();
        string title = "";
        int titleLenght = Random.Range(min, max);
        for (int i = 0; i < titleLenght; i++)
        {
            title += chars[Random.Range(0, chars.Length-1)].ToString();
        }
        return title;
    }

    public Vector3 BookScale
    {
        get
        {
            return bookScale;
        }

        set
        {
            bookScale = value;
            UpdateBook();
        }
    }

    // Update is called once per frame
    void UpdateBook () {
        titleCanvasRect = canvas.GetComponentInChildren<RectTransform>();
        titleCanvasRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1000 * BookScale.x);
        titleCanvasRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1000 * BookScale.y);
        canvas.transform.localPosition = new Vector3(0,00,-BookScale.z/2.0f);
        mesh.localScale = BookScale;
        mesh.GetComponentInChildren<Renderer>().material.color = color;
        GetComponent<BoxCollider>().size = bookScale;
        GetComponent<Rigidbody>().isKinematic = false;

        Init();
    }
}
