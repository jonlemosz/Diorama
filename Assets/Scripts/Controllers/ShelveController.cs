using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelveController : MonoBehaviour {

    public float xOffset;
    public float yOffset;
    public float zOffset;
    public float bookWidth=0.25f;
    public float bookHeight=0.25f;
    public float bookDepth=0.25f;
    public float bookScale=1;
    Shelf shelf;
    public int booksCount= 6;
    List<BookController> bookWorldRefs = new List<BookController>();


    public Transform pivot;
    public bool refill = false;

	// Use this for initialization
	public void Fill () {

        foreach (var item in bookWorldRefs)
        {
            try
            {
                DestroyImmediate(item.gameObject);
            }
            catch (System.Exception e)
            {

                Debug.LogWarning(e.Message);
            } 
        }
        bookWorldRefs.Clear();
        shelf = new Shelf();

        for (int i = 0; i < booksCount; i++)
        {
            shelf.Books.Add(new Book());
            GameObject bookRef = Instantiate(Resources.Load<GameObject>("Book"), pivot.transform);
            bookWorldRefs.Add(bookRef.GetComponent<BookController>());
        }
        refill = false;
        UpdateShelve();
    }
	
	// Update is called once per frame
	void UpdateShelve () {

        //if (refill) Fill();

        for (int i = 0; i < bookWorldRefs.Count; i++)
        {
            if (bookWorldRefs[i] != null)
            {
                bookWorldRefs[i].transform.localPosition = (Vector3.left * xOffset * i) - (Vector3.left * xOffset * (((float)bookWorldRefs.Count - 1) / 2.0f)) + new Vector3(0, yOffset, zOffset);
                bookWorldRefs[i].BookScale = new Vector3(bookWidth, bookHeight, bookDepth) * bookScale;
            }
        }	
	}
}
