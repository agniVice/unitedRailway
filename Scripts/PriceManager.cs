using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceManager : MonoBehaviour
{
    [SerializeField]
    private PlayerData pData;
    public float[] randomPercengeMin;
    public float[] randomPercengeMax;
    [Header("Raw")]
    [SerializeField]
    private float wheatPrice;
    [SerializeField]
    private float fishPrice;
    [SerializeField]
    private float woodPrice;
    [SerializeField]
    private float ironOrePrice;
    [SerializeField]
    private float coalOrePrice;                                   
    [SerializeField]
    private float oilPrice;                     
    [SerializeField]
    private float sugarPrice;                   
    [SerializeField]
    private float ironPrice;                    
    [SerializeField]
    private float linenAndCottonPrice;          
    [SerializeField]
    private float vegetablesPrice;
    [SerializeField]
    private float cowPrice;


    [Space]
    [Header("Product")]
    [SerializeField]
    private float planksPrice;
    [SerializeField]
    private float breadPrice;                      
    [SerializeField]
    private float clothPrice;
    [SerializeField]
    private float coalPrice;
    [SerializeField]
    private float dieselPrice;                     
    [SerializeField]
    private float furniturePrice;
    [SerializeField]
    private float meatPrice;
    [SerializeField]
    private float milkPrice;
    [SerializeField]
    private float cannedFishPrice;
    [SerializeField]
    private float mechanismsPrice;

    [Space]
    [Header("Passenger")]
    [SerializeField]
    private float passengerPrice;

    private float totalPrice;
    public void RandomUpdate(string name, float count)
    {
        switch (name)
        {
            case "Wheat":
                {
                    if(Mathf.RoundToInt(wheatPrice * count)<=0)
                        break;
                    else
                        wheatPrice = Mathf.RoundToInt(wheatPrice * count);
                    break;
                }
            case "Bread":
                {
                    if (Mathf.RoundToInt(breadPrice * count) <= 0)
                        break;
                    else
                        breadPrice = Mathf.RoundToInt(breadPrice * count);
                    break;
                }
            case "Wood":
                {
                    if (Mathf.RoundToInt(woodPrice * count) <= 0)
                        break;
                    else
                        woodPrice = Mathf.RoundToInt(woodPrice * count);
                    break;
                }
            case "Planks":
                {
                    if (Mathf.RoundToInt(planksPrice * count) <= 0)
                        break;
                    else
                        planksPrice = Mathf.RoundToInt(planksPrice * count);
                    break;
                }
            case "Passenger":
                {
                    if (Mathf.RoundToInt(passengerPrice * count) <= 0)
                        break;
                    else
                        passengerPrice = Mathf.RoundToInt(passengerPrice * count);
                    break;
                }
            case "Furniture":
                {
                    if (Mathf.RoundToInt(furniturePrice * count) <= 0)
                        break;
                    else
                        furniturePrice = Mathf.RoundToInt(furniturePrice * count);
                    break;
                }
            case "Cow":
                {
                    if (Mathf.RoundToInt(cowPrice * count) <= 0)
                        break;
                    else
                        cowPrice = Mathf.RoundToInt(cowPrice * count);
                    break;
                }
            case "Meat":
                {
                    if (Mathf.RoundToInt(meatPrice * count) <= 0)
                        break;
                    else
                        meatPrice = Mathf.RoundToInt(meatPrice * count);
                    break;
                }
            case "Vegetables":
                {
                    if (Mathf.RoundToInt(vegetablesPrice * count) <= 0)
                        break;
                    else
                        vegetablesPrice = Mathf.RoundToInt(vegetablesPrice * count);
                    break;
                }
            case "Milk":
                {
                    if (Mathf.RoundToInt(milkPrice * count) <= 0)
                        break;
                    else
                        milkPrice = Mathf.RoundToInt(milkPrice * count);
                    break;
                }
            case "Fish":
                {
                    if (Mathf.RoundToInt(fishPrice * count) <= 0)
                        break;
                    else
                        fishPrice = Mathf.RoundToInt(fishPrice * count);
                    break;
                }
            case "Canned Fish":
                {
                    if (Mathf.RoundToInt(cannedFishPrice * count) <= 0)
                        break;
                    else
                        cannedFishPrice = Mathf.RoundToInt(cannedFishPrice * count);
                    break;
                }
            case "Mechanisms":
                {
                    if (Mathf.RoundToInt(mechanismsPrice * count) <= 0)
                        break;
                    else
                        mechanismsPrice = Mathf.RoundToInt(mechanismsPrice * count);
                    break;
                }
            case "Iron Ore":
                {
                    if (Mathf.RoundToInt(ironOrePrice * count) <= 0)
                        break;
                    else
                        ironOrePrice = Mathf.RoundToInt(ironOrePrice * count);
                    break;
                }
            case "Iron":
                {
                    if (Mathf.RoundToInt(ironPrice * count) <= 0)
                        break;
                    else
                        ironPrice = Mathf.RoundToInt(ironPrice * count);
                    break;
                }
            case "Diesel":
                {
                    if (Mathf.RoundToInt(dieselPrice * count) <= 0)
                        break;
                    else
                        dieselPrice = Mathf.RoundToInt(dieselPrice * count);
                    break;
                }
            case "Oil":
                {
                    if (Mathf.RoundToInt(oilPrice * count) <= 0)
                        break;
                    else
                        oilPrice = Mathf.RoundToInt(oilPrice * count);
                    break;
                }
            case "Coal Ore":
                {
                    if (Mathf.RoundToInt(coalOrePrice * count) <= 0)
                        break;
                    else
                        coalOrePrice = Mathf.RoundToInt(coalOrePrice * count);
                    break;
                }
            case "Coal":
                {
                    if (Mathf.RoundToInt(coalPrice * count) <= 0)
                        break;
                    else
                        coalPrice = Mathf.RoundToInt(coalPrice * count);
                    break;
                }
        }
    }
    public void UpdatePrice(string name, float count)
    {
        switch (name)
        {
            case "Wheat":
                {
                    wheatPrice = count;
                    break;
                }
            case "Bread":
                {
                    breadPrice = count;
                    break;
                }
            case "Wood":
                {
                    woodPrice = count;
                    break;
                }
            case "Planks":
                {
                    planksPrice = count;
                    break;
                }
            case "Passenger":
                {
                    passengerPrice = count;
                    break;
                }
            case "Furniture":
                {
                    furniturePrice = count;
                    break;
                }
            case "Cow":
                {
                    cowPrice = count;
                    break;
                }
            case "Meat":
                {
                    meatPrice = count;
                    break;
                }
            case "Vegetables":
                {
                    vegetablesPrice = count;
                    break;
                }
            case "Milk":
                {
                    milkPrice = count;
                    break;
                }
            case "Fish":
                {
                    fishPrice = count;
                    break;
                }
            case "Canned Fish":
                {
                    cannedFishPrice = count;
                    break;
                }
            case "Mechanisms":
                {
                    mechanismsPrice = count;
                    break;
                }
            case "Iron Ore":
                {
                    ironOrePrice = count;
                    break;
                }
            case "Iron":
                {
                    ironPrice = count;
                    break;
                }
            case "Diesel":
                {
                    dieselPrice = count;
                    break;
                }
            case "Oil":
                {
                    oilPrice = count;
                    break;
                }
            case "Coal Ore":
                {
                    coalOrePrice = count;
                    break;
                }
            case "Coal":
                {
                    coalPrice = count;
                    break;
                }
        }
    }
    private void CheckPrice(string whatCheck, float count)
    {
        totalPrice = 0;
        switch (whatCheck)
        {
            case "Wheat":
                {
                    totalPrice = wheatPrice * count;
                    break;
                }
            case "Bread":
                {
                    totalPrice = breadPrice * count;
                    break;
                }
            case "Wood":
                {
                    totalPrice = woodPrice * count;
                    break;
                }
            case "Planks":
                {
                    totalPrice = planksPrice * count;
                    break;
                }
            case "Passenger":
                {
                    totalPrice = passengerPrice * count;
                    break;
                }
            case "Furniture":
                {
                    totalPrice = furniturePrice * count;
                    break;
                }
            case "Cow":
                {
                    totalPrice = cowPrice * count;
                    break;
                }
            case "Meat":
                {
                    totalPrice = meatPrice * count;
                    break;
                }
            case "Vegetables":
                {
                    totalPrice = vegetablesPrice * count;
                    break;
                }
            case "Milk":
                {
                    totalPrice = milkPrice * count;
                    break;
                }
            case "Fish":
                {
                    totalPrice = fishPrice * count;
                    break;
                }
            case "Canned Fish":
                {
                    totalPrice = cannedFishPrice * count;
                    break;
                }
            case "Iron Ore":
                {
                    totalPrice = ironOrePrice * count;
                    break;
                }
            case "Iron":
                {
                    totalPrice = ironPrice * count;
                    break;
                }
            case "Mechanisms":
                {
                    totalPrice = mechanismsPrice * count;
                    break;
                }
            case "Diesel":
                {
                    totalPrice = dieselPrice * count;
                    break;
                }
            case "Oil":
                {
                    totalPrice = oilPrice * count;
                    break;
                }
            case "Coal Ore":
                {
                    totalPrice = coalOrePrice * count;
                    break;
                }
            case "Coal":
                {
                    totalPrice = coalPrice * count;
                    break;
                }
        }
    }
    public void Sell(WagonScript sender, float count, string whatSell)
    {
        CheckPrice(whatSell, count);
        sender.totalPrice = totalPrice;
        pData.ChangeMoney(sender.gameObject, totalPrice);
    }
    public float GetPrice(string name)
    {
        switch (name)
        {
            case "Wheat":
                {
                    return wheatPrice;
                }
            case "Bread":
                {
                    return breadPrice;
                }
            case "Wood":
                {
                    return woodPrice;
                }
            case "Planks":
                {
                    return planksPrice;
                }
            case "Passenger":
                {
                    return passengerPrice;
                }
            case "Furniture":
                {
                    return furniturePrice;
                }
            case "Cow":
                {
                    return cowPrice;
                }
            case "Meat":
                {
                    return meatPrice;
                }
            case "Vegetables":
                {
                    return vegetablesPrice;
                }
            case "Milk":
                {
                    return milkPrice;
                }
            case "Fish":
                {
                    return fishPrice;
                }
            case "Canned Fish":
                {
                    return cannedFishPrice;
                }
            case "Iron Ore":
                {
                    return ironOrePrice;
                }
            case "Iron":
                {
                    return ironPrice;
                }
            case "Mechanisms":
                {
                    return mechanismsPrice;
                }
            case "Diesel":
                {
                    return dieselPrice;
                }
            case "Oil":
                {
                    return oilPrice;
                }
            case "Coal Ore":
                {
                    return coalOrePrice;
                }
            case "Coal":
                {
                    return coalPrice;
                }
        }
        return 0;
    }
}
