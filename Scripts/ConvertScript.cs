using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConvertScript : MonoBehaviour
{
    [SerializeField] private PlayerData pData;
    [SerializeField] private MainSceneScript mainScript;
    [SerializeField] private float _moneyFromTicket;
    [SerializeField] private TextMeshProUGUI money;
    [SerializeField] private TextMeshProUGUI tickets;
    [SerializeField] private TextMeshProUGUI multiplyText;
    [SerializeField] private float _ticketsToConvert;


    [SerializeField] private float _ticketsNeed;
    [SerializeField] private float _moneyNeed;
    [SerializeField] private TextMeshProUGUI moneyNeed;
    [SerializeField] private TextMeshProUGUI moneyAd_nm;
    [SerializeField] private TextMeshProUGUI tickets_nm;
    [SerializeField] private TextMeshProUGUI money_bgnm;
    [SerializeField] private TextMeshProUGUI tickets_bgnm;
    private void Start()
    {
        multiplyText.text = "1x" + mainScript.GetMultiply();
    }
    private void Update()
    {
        if (mainScript.uiScript.idMenu == 9)
        {
            CalculateConvert(mainScript.uiScript.sliderConvertMenu.value);
        }
        if (mainScript.uiScript.isNoMoneyOpen)
        {
            money_bgnm.text = FormatNumsHelper.FormatNum(pData.GetMoney());
            tickets_bgnm.text = FormatNumsHelper.FormatNum(pData.GetTickets());
        }
    }
    public void CalculateConvert(float value)
    {
        _ticketsToConvert = (pData.GetTickets() * value);
        _ticketsToConvert = Mathf.RoundToInt(_ticketsToConvert);
        tickets.text = _ticketsToConvert.ToString();
        _moneyFromTicket = _ticketsToConvert * mainScript.GetMultiply();
        money.text = _moneyFromTicket.ToString();
    }
    public void Convert()
    {
        if (_ticketsToConvert != 0)
        {
            mainScript.uiScript.uiTween.Convert();
            mainScript.uiScript.audioUI.PlaySoundSecond(mainScript.uiScript.audioUI.ConvertMoney);
        }
        if (pData.CheckValue(_ticketsToConvert, true))
        {
            pData.ChangeTickets(this.gameObject, -_ticketsToConvert);
            pData.ChangeMoney(this.gameObject, _moneyFromTicket, false);
            mainScript.uiScript.sliderConvertMenu.value = 0f;
            CalculateConvert(0f);
        }
        else
        {
            mainScript.uiScript.CloseMenu();
            mainScript.uiScript.OpenDonateMenu();
        }
    }
    public void BuyTickets()
    {
        mainScript.uiScript.CloseMenu();
        mainScript.uiScript.OpenDonateMenu();
    }
    public float GetMoneyNeed()
    {
        return _moneyNeed;
    }
    public void CalculateTickets(float value)
    {
        _moneyNeed = value;
        _ticketsNeed = Mathf.RoundToInt(pData.GetDifferenceMoney(value) / mainScript.GetMultiply());
        if (_ticketsNeed == 0)
            _ticketsNeed = 1;
        tickets_nm.text = _ticketsNeed.ToString();
        moneyAd_nm.text = FormatNumsHelper.FormatNum(mainScript.GetStaticReward());
        moneyNeed.text = FormatNumsHelper.FormatNum(pData.GetDifferenceMoney(value));
    }
    public void BuyMoney()
    {
        if (pData.CheckValue(_ticketsNeed, true))
        {
            pData.ChangeTickets(this.gameObject, -_ticketsNeed);
            pData.ChangeMoney(this.gameObject, _moneyNeed, false);
            mainScript.uiScript.uiTween.CloseNoMoney();
        }
        else
        {
            mainScript.uiScript.CloseMenu();
            mainScript.uiScript.uiTween.CloseNoMoney();
            mainScript.uiScript.OpenDonateMenu();
        }
    }
}
