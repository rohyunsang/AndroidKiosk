using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//

public class PanelManager : MonoBehaviour
{
    public GameObject LoginPanel;
    public GameObject VirtualFittingPanel;
    public GameObject VirtualFittingResultPanel;
    public GameObject MaxmizeImagePanel;
    public GameObject SettingPanel;
    public GameObject ShoppingBasketPanel;
    public GameObject PhotoResultPanel;
    public GameObject InitPanel;

    public GameObject PurchasePanel;
    
    
    //use up down panel cuz always on shoppingbasketPanel
    private Vector3 ShoppingBasketPanelOriginPosition; 

    public void UpShoppingBasketPanel(){
        ShoppingBasketPanelOriginPosition = ShoppingBasketPanel.transform.position;
        ShoppingBasketPanel.transform.position = new Vector3(0,5600,0);
    }
    public void DownShoppingBasketPanel(){
        ShoppingBasketPanel.transform.position = ShoppingBasketPanelOriginPosition;
    }

    public void OnVirtualFittingPanel()
    {
        VirtualFittingPanel = GameObject.Find("VirtualFittingPanel");
        VirtualFittingPanel.SetActive(true);
    }
    public void OnMaxmizeImagePanel()
    {
        MaxmizeImagePanel.SetActive(true);
    }

    public void OnSettingPanel()
    {
        SettingPanel.SetActive(true);
    }
    public void OnShoppingBasketPanel()
    {
        ShoppingBasketPanel.SetActive(true);
    }
    public void OnLoginPanel()
    {
        LoginPanel.SetActive(true);
    }

    public void OnInitPanel(){
        InitPanel.SetActive(true);
    }

    public void OnPurchasePanel(){
        PurchasePanel.SetActive(true);
        OffPurchasePanel(); // 일단 구매기능이 없으니 구매를 건너뜀.
    }
    public void OffPurchasePanel(){  //waiting 3second
        Invoke("PanelInitialize",3f);
    }
    void PanelInitialize(){ // used Invoked fuction
        PurchasePanel.SetActive(false);
        ShoppingBasketPanel.SetActive(false);
        InitPanel.SetActive(true);
        // 장바구니 초기화

    }

    public void OffInitPanel(){
        InitPanel.SetActive(false);
    }

    public void OnPhotoResultPanel()
    {
        PhotoResultPanel.SetActive(true);
    }
    public void OffPhotoResultPanel()
    {
        PhotoResultPanel.SetActive(true);
    }

    public void OffLoginPanel()
    {
        LoginPanel.SetActive(false);
    }
    public void OffVIrtualFittingPanel()
    {
        VirtualFittingPanel.SetActive(false);
    }
    public void OffMaxmizImagePanel()
    {
        MaxmizeImagePanel.SetActive(false);
    }
    /*
    public void OffIntroAdvertisingPanel(){
        IntroAdvertisingPanel.SetActive(false);
    }
    */
    public void OffVIrtualFittingResultPanel()
    {
        VirtualFittingResultPanel.SetActive(false);
    }

    public void OffSettingPanel()
    {
        SettingPanel.SetActive(false);
    }
    public void OffShoppingBasketPanel()
    {
        ShoppingBasketPanel.SetActive(false);
    }
}
