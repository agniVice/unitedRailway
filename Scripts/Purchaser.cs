using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.SceneManagement;
public class Purchaser : MonoBehaviour
{
    public void OnPurchaseComplete(Product product)
    {
        switch (product.definition.id)
        {
            case "no_ad":
                {
                    RemoveAds();
                    break;
                }
            case "200tickets":
                {
                    GiveTickets(200);
                    break;
                }
            case "1000tickets":
                {
                    GiveTickets(1000);
                    break;
                }
            case "500tickets":
                {
                    GiveTickets(500);
                    break;
                }
            case "x3chance_get_tickets":
                {
                    GiveChance();
                    break;
                }
        }
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            FindObjectOfType<UITweenMainMenu>().RefreshDonateMenu();
        }
        else
        {
            FindObjectOfType<UserInterfaceScript>().RefreshDonate();
        }
    }
    private void RemoveAds()
    {
        FindObjectOfType<PlayerData>().DisableAd();
    }
    private void GiveTickets(int count)
    {
        FindObjectOfType<PlayerData>().ChangeTickets(gameObject, count, false);
        FindObjectOfType<PlayerData>().SaveData();
        Debug.Log("ChangeTickets: " + count);
    }
    private void GiveChance()
    {
        PlayerPrefs.SetInt("ChanceX3", 1);
        Debug.Log("Chance X3 Purchased");
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            FindObjectOfType<MainSceneScript>().ChanceTicketDonate();
        }
    }
}
