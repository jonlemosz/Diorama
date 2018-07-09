using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectDataController : MonoBehaviour {

    public static string userEmail= "jonatan.lemos.z@gmail.com";
    public string sceneToLoad ;

    private void Awake()
    {
        //UnityEngine.XR.XRSettings.enabled = false;
    }

    public void SetUserEmail(string email) {
        userEmail = email;
    }


    public void LoadNextScene()
    {
        StartCoroutine(SwitchToVR());
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
        //UnityEngine.XR.XRSettings.enabled = true;
    }

    IEnumerator SwitchToVR()
    {
        string[] viveDevices = new string[] { "OpenVR" };
        UnityEngine.XR.XRSettings.LoadDeviceByName(viveDevices);

        yield return null;

        UnityEngine.XR.XRSettings.enabled = true;
    }
}