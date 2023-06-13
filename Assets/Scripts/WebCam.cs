using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class WebCam : MonoBehaviour
{
    // 웹캠 변수
    public RawImage display;

    [SerializeField]
    public WebCamTexture camTexture;
    private int currentIndex = 0;
    public Texture2D snap;
    public Texture2D snapSlicedAndRotated;
    public Texture2D snapRotated;

    // 타이머 변수
    public Text timerText;
    int threeSecond = 3;
    public GameObject countingImage;

    // 캡처된 이미지 확인용 변수
    public Image captureImage;

    void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            Permission.RequestUserPermission(Permission.Camera);

        WebCamDevice[] devices = WebCamTexture.devices;
        for (int i = 0; i < devices.Length; i++)
        {
            if (devices[i].isFrontFacing)
            {
                currentIndex = i;
                break;
            }
        }

        captureImage.gameObject.SetActive(false);
    }

    public void WebCamPlayButton()
    {
        Debug.Log("WebCamPlayButtonClicked");
        WebCamDevice device = WebCamTexture.devices[currentIndex];
        camTexture = new WebCamTexture(device.name, Screen.width, Screen.height);
        camTexture.requestedFPS = 30;
        camTexture.requestedWidth = Screen.width;
        display.rectTransform.localRotation = Quaternion.Euler(0, 180, 90);
        display.texture = camTexture;
        camTexture.Play();
        display.gameObject.SetActive(true);
    }

    public void WebCamCapture()
    {
        snap = new Texture2D(camTexture.width, camTexture.height, TextureFormat.RGBA32, false);
        snap.SetPixels(camTexture.GetPixels());
        snap.Apply();

        //snapSlicedAndRotated = CropTexture2D(snap, 576, 0, 768, 1024);
        snapRotated = RotatedTexture2D(snap);


        captureImage.gameObject.SetActive(true);
        captureImage.sprite = Sprite.Create(snap, new Rect(0, 0, snap.width, snap.height), new Vector2(0.5f, 0.5f));
        display.gameObject.SetActive(false);
    }

    Texture2D RotatedTexture2D(Texture2D snap)
    {
        Color32[] pixels = snap.GetPixels32();
        Color32[] rotatedPixels = new Color32[snap.height * snap.width];
        int rotatedIndex = 0;
        for (int i = 0; i < snap.width; i++)
        {
            for (int j = snap.height - 1; j >= 0; j--)
            {
                rotatedPixels[rotatedIndex] = pixels[i + j * snap.width];
                rotatedIndex++;
            }
        }

        Texture2D rotatedTexture = new Texture2D(snap.height, snap.width);
        rotatedTexture.SetPixels32(rotatedPixels);
        rotatedTexture.Apply();
        return rotatedTexture;
    }

    /*
    Texture2D CropTexture2D(Texture2D originalTexture, int startX, int startY, int width, int height)
    {
        Color[] pixels = originalTexture.GetPixels(startX, startY, width, height);
        Texture2D croppedTexture = new Texture2D(width, height);
        croppedTexture.SetPixels(pixels);
        croppedTexture.Apply();
        return croppedTexture;
    }
    */


    public void WebCamCaptureButton()
    {
        display.gameObject.SetActive(true);
        captureImage.gameObject.SetActive(false);
        threeSecond = 3;
        countingImage.SetActive(true);
        StartCoroutine(CountingThreeSecond());
        Invoke("WebCamCapture", 3f);
    }

    IEnumerator CountingThreeSecond()
    {
        for (int i = 0; i < 3; i++)
        {
            timerText.text = threeSecond.ToString();
            yield return new WaitForSeconds(1f);
            threeSecond--;
        }
        timerText.fontSize = 20;
        timerText.text = "캡처!";
    }

    public void WebCamStopButton()
    {
        countingImage.SetActive(false);
        camTexture.Stop();
        threeSecond = 3;
        captureImage.gameObject.SetActive(false);
    }

}