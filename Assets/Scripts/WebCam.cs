using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.WebCam;

//using System.IO; // used only debug

public class WebCam : MonoBehaviour
{
    // webcam variables 
    public RawImage display;

    [SerializeField]
    public WebCamTexture camTexture;
    private int currentIndex = 0;
    public Texture2D snap;
    public Texture2D snapSliced;

    // timer variables
    public Text timerText;
    int threeSecond = 3;
    public GameObject countingImage;

    // photo capture checking Image varable
    public Image captureImage;

    // use debug
    // private int captureCounter = 0;

    void Start()
    {
        //webCam = GameObject.Find("WebCamManager").GetComponent<WebCam>();

        WebCamDevice[] devices = WebCamTexture.devices;
        for (int i = 0; i < devices.Length; i++)
        {
            Debug.Log(devices.Length + " " + devices[i].name);
        }

        //webcam run 
        if (camTexture != null)
        {
            display.texture = null;
            camTexture.Stop();
            camTexture = null;
        }
        captureImage.gameObject.SetActive(false);
    }

    public void WebCamPlayButton()
    {
        Debug.Log("WebCamPlayButtonClicked");
        WebCamDevice device = WebCamTexture.devices[currentIndex];
        camTexture = new WebCamTexture(device.name, 1920, 1080, 30);
        display.texture = camTexture;
        camTexture.Play();
    }
    public void WebCamCapture()
    {
        snap = new Texture2D(camTexture.width, camTexture.height, TextureFormat.RGBA64, false);
        Debug.Log(camTexture.width);
        Debug.Log(camTexture.height);
        snap.SetPixels(camTexture.GetPixels());
        snap.Apply();

        snapSliced = CropTexture2D(snap,576, 0, 768, 1024);

        // use debug
        // Save the snapSliced texture as a PNG file
        byte[] bytes = snapSliced.EncodeToPNG();
        string filePath = Application.dataPath + "/snapsliced.png";
        System.IO.File.WriteAllBytes(filePath, bytes);

        // Resize the snap texture to the desired size
        captureImage.gameObject.SetActive(true);
        captureImage.sprite = Sprite.Create(snapSliced, new Rect(0, 0, snapSliced.width, snapSliced.height), new Vector2(0.5f, 0.5f));
        display.gameObject.SetActive(false);
    }
    Texture2D CropTexture2D(Texture2D originalTexture, int startX, int startY, int width, int height)
    {
        Color[] pixels = originalTexture.GetPixels(startX, startY, width, height);
        Texture2D croppedTexture = new Texture2D(width, height);
        croppedTexture.SetPixels(pixels);
        croppedTexture.Apply();
        return croppedTexture;
    }

    public void WebCamCaptureButton() // using button  
    {
        display.gameObject.SetActive(true);
        captureImage.gameObject.SetActive(false);
        threeSecond = 3;  // 타이머 3초로 만들기 
        countingImage.SetActive(true);
        StartCoroutine(CountingThreeSecond());
        Invoke("WebCamCapture", 3f);

    }

    IEnumerator CountingThreeSecond()
    {  // 3 second waiting fuc
        for (int i = 0; i < 3; i++)
        {
            timerText.text = threeSecond.ToString();
            yield return new WaitForSeconds(1f);
            threeSecond--;
        }
        timerText.fontSize = 20;
        timerText.text = "Capture!";
    }

    public void WebCamStopButton()
    {   // panel close button fuc 
        countingImage.SetActive(false);
        camTexture.Stop();
        threeSecond = 3;  // timer set 3 second
        captureImage.gameObject.SetActive(false);
    }
}
