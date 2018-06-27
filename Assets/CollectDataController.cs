using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectDataController : MonoBehaviour {

    public static string userEmail= "gustavotero7@gmail.com";
    public string sceneToLoad ;

    private void Awake()
    {
        UnityEngine.XR.XRSettings.enabled = false;

    }

    public void SetUserEmail(string email) {
        userEmail = email;
    }


    public void LoadNextScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
        UnityEngine.XR.XRSettings.enabled = true;
    }

}
