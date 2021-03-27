using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductButtonBehaviour : MonoBehaviour
{
    [Header("References to shop & product manager")]
     ProductManager productManager;
     ShopManager shopManager;

    private void Start()
    {
        productManager = ProductManager.instance;
        shopManager = ShopManager.instance;
    }


    /// <summary>
    /// This function handles the click on items button 
    /// </summary>
    public void OnSelect()
    {

    }
}
