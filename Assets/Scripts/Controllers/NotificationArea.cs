using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationArea : MonoBehaviour {

    static NotificationArea instance;

    public Text text;

    public static string Text {
        get { return instance.text.text; }
        set { instance.text.text = value; }
    }

    void Awake()
    {
        instance = this;
    }

}


