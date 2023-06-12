// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.Networking;

// public class ImageDownload : MonoBehaviour
// {
//     public string apiURL = "http://220.149.231.136:8051/api/clothes";
//     public RawImage rawImage; // RawImage 컴포넌트에 텍스처를 할당하기 위한 변수

//     void Start()
//     {
//         StartCoroutine(APIDownload(apiURL));
//     }

//     IEnumerator APIDownload(string apiURL)
//     {
//         UnityWebRequest www = UnityWebRequest.Get(apiURL);
//         yield return www.SendWebRequest();

//         if (www.result == UnityWebRequest.Result.Success)
//         {
//             byte[] imageBytes = www.downloadHandler.data; // 다운로드한 이미지 데이터
//             Texture2D texture = new Texture2D(2, 2);
//             texture.LoadImage(imageBytes); // 이미지 데이터를 텍스처에 로드

//             // RawImage 컴포넌트에 텍스처를 할당
//             rawImage.texture = texture;
//         }
//         else
//         {
//             Debug.Log("Image download failed: " + www.error);
//         }
//     }
// }