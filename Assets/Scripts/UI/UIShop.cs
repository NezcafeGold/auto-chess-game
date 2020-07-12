using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShop : MonoBehaviour
{
    private GameObject panelShop;
    private GameObject buttonReRoll;

    // Start is called before the first frame update
    void Start()
    {
        panelShop = GameObject.Find("PanelShop");
        buttonReRoll = GameObject.Find("ButtonReRoll");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void clickOnButtonShop()
    {
        panelShop.SetActive(!panelShop.activeSelf);
        buttonReRoll.SetActive(!buttonReRoll.activeSelf);

    }
}