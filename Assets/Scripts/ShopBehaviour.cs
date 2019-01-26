using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBehaviour : MonoBehaviour
{
    private GuiBehaviour gui;
    private GameObject shopRoot;
    private PlayerMovement player;
    
    public bool InTrigger { get; private set; }
    public bool InShop { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InTrigger = true;

            player = other.GetComponent<PlayerMovement>();
            gui = other.GetComponent<GuiBehaviour>();
            shopRoot = gui.shopParent;
            
            ShowHint();
        }
    }

    private void ShowHint()
    {
        gui.ShowText("Press <color=yellow>F</color> to enter shop");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InTrigger = false;
            ToggleShop();
        }
    }

    private void Update()
    {
        if (!InTrigger) return;
        
        if (Input.GetKeyUp(KeyCode.F) && !InShop)
        {
            ToggleShop(true);
        }
        else if(Input.GetKeyUp(KeyCode.Escape) && InShop)
        {
            ToggleShop();
        }
    }

    private void ToggleShop(bool show = false)
    {
        shopRoot.SetActive(show);
        InShop = show;
        player.enabled = !show;
        
        if (!show && InTrigger)
        {
            ShowHint();
        }
        else if (show)
        {
            gui.ShowText("Press <color=yellow>ESC</color> to exit the shop.");
        }
        else
        {
            gui.ShowText();
        }
    }
}