using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInstance : MonoBehaviour
{
    public Transform scrollViewMain;
    public GameObject clothProduct;

    public void InstantiateCloth() //using btn StartBtn in InitPanel
    {
        for (int i = 0; i < 10; i++)
        {
            //size setting is GridLay Out Group
            GameObject instance = Instantiate(clothProduct, scrollViewMain);
        }
    }
}



