using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class APIGetTest : MonoBehaviour
{
    public string apiURL = "http://220.149.231.136:8051/api/clothes";

    void Start(){
        StartCoroutine("APIDownload");
    }
    IEnumerator APIDownload()
    {
        UnityWebRequest www = UnityWebRequest.Get(apiURL);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            string response = www.downloadHandler.text;
            Debug.Log(response);
            // Assign the downloaded texture to the RawImage component
        }
        else
        {
            Debug.Log("Image download failed: " + www.error);
        }
    }
}
