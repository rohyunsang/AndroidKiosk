using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class APIPostTest : MonoBehaviour
{
    public Texture2D imageTexture;
    private string _name = "노윤상 티셔츠";
    private string price = "10000";
    private string brand = "노브랜드";
    private string category = "티셔츠";
    private string color = "검정색";
    private string size = "XL";
    private string stock = "20";

    void Start()
    {

        StartCoroutine(ClothesPost());
    }

    IEnumerator ClothesPost()
    {
        string imagePath = @"file:///C:\Users\lionh\Documents\GitHub\UnityKiosk\Assets\Images\KakaoTalk_20230531_133515500.jpg";
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imagePath);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(www);
            byte[] imageBytes = texture.EncodeToJPG();

            // Create a new form
            WWWForm form = new WWWForm();

            // Convert the Texture2D to byte array

            // Add the image as binary data to the form
            form.AddBinaryData("image", imageBytes, "image.jpg", "image/jpeg");

            // Add other form fields
            form.AddField("name", _name);
            form.AddField("price", price);
            form.AddField("brand", brand);
            form.AddField("category", category);
            form.AddField("color", color);
            form.AddField("size", size);
            form.AddField("stock", stock);

            // Create a UnityWebRequest object to send the form data
            UnityWebRequest uploadRequest = UnityWebRequest.Post("http://220.149.231.136:8051/api/clothes", form);

            // Send the request and wait for a response
            yield return uploadRequest.SendWebRequest();

            if (uploadRequest.result == UnityWebRequest.Result.Success)
            {
                // Request successful
                Debug.Log("Image upload complete!");

                // Print the response text
                Debug.Log(uploadRequest.downloadHandler.text);
            }
            else
            {
                // Request failed
                Debug.Log("Image upload failed: " + uploadRequest.error);
            }
        }
        else
        {
            // Texture loading failed
            Debug.Log("Texture loading failed: " + www.error);
        }
    }
}