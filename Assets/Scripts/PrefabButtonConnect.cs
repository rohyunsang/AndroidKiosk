using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabButtonConnect : MonoBehaviour
{
    public WebCam webCam;
    public PanelManager panelManager;
    public GameObject virtualPanel;
    public GameObject webCamObject;

    // Start is called before the first frame update
    void Start()
    {
        webCam = GameObject.Find("WebCamManager").GetComponent<WebCam>();
        virtualPanel = GameObject.Find("PanelManager").GetComponent<PanelManager>().VirtualFittingPanel;
        // 이미지 업로드하기 버튼에 자기 부모한테서 이미지 url 가져와서 해야된다. 
        // 그러면 자기 부모한테서 가져오지말고, 여기에 할당해놓고 해야겠다.
    }
        

    public void OnPrefabButton(){
        virtualPanel.SetActive(true);
        webCam.WebCamPlayButton();
        GameObject.Find("ImageUploadBtn").GetComponent<PhotoUpload>().imgUrl = transform.GetComponent<ImageURL>().imgUrl;
    } 
}
