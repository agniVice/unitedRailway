using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.Localization.Components;

public class PriceListItemScript : MonoBehaviour
{
    [SerializeField] private PriceManager pManager;
    [SerializeField] private PriceListScript pList;
    [SerializeField] private Image imageElement;
    [SerializeField] private LocalizeStringEvent nameElement;
    [SerializeField] public TextMeshProUGUI growPriceElement;
    [SerializeField] public TextMeshProUGUI decreasePriceElement;
    [SerializeField] public TextMeshProUGUI differentText;
    public TextMeshProUGUI priceElement;
    [SerializeField] private Image currencyImage;
    [SerializeField] private GameObject mask;

    [SerializeField] private bool isThisTypeOpen;
    public string _name;
    [SerializeField] private float _newPrice;
    [SerializeField] private Sprite _currency;
    [SerializeField] private Sprite _image;
    [SerializeField] private float _price;
    public Image changeImageGrow;
    public Image changeImageDecrease;
    private void Awake()
    {
        //pManager = FindObjectOfType<PriceManager>();
    }
    public void GetPrice()
    {
        _price = pManager.GetPrice(_name);
    }
    public void Open()
    {
        gameObject.GetComponent<RectTransform>().localScale = Vector3.zero;
        gameObject.GetComponent<RectTransform>().DOScale(0.5f,  Random.Range(0.1f, 0.5f)).SetEase(Ease.OutBack).SetDelay(0.2f);
        if (isThisTypeOpen)
            mask.SetActive(false);
        else
            mask.SetActive(true);
        GetPrice();
        imageElement.sprite = _image;
        nameElement.SetEntry(_name);
        priceElement.text = FormatNumsHelper.FormatNum(_price);
        currencyImage.sprite = _currency;
        if (pManager.gameObject.GetComponent<PriceListScript>().timesOfUpdate != 0)
        {
            differentText.gameObject.GetComponent<Animator>().enabled = true;
            differentText.gameObject.SetActive(true);
        }
        else
            differentText.gameObject.SetActive(false);
    }
    public void CheckDifference(float count)
    {
        if (isThisTypeOpen)
        {
            string different;
            if (_price * count >= _price)
            {
                different = "+" + FormatNumsHelper.FormatNum(Mathf.RoundToInt(_price * count) - _price);
                changeImageGrow.gameObject.SetActive(true);
                changeImageGrow.color = new Color(255, 255, 255, 0);
                changeImageGrow.GetComponent<RectTransform>().anchoredPosition = new Vector2(244, -130);
                changeImageGrow.DOFade(1, 1).SetEase(Ease.OutQuad);
                changeImageGrow.GetComponent<RectTransform>().DOAnchorPos(new Vector3(244, -30, 0), 1).SetEase(Ease.OutQuad).OnComplete(() => {
                changeImageGrow.GetComponent<RectTransform>().DOAnchorPos(new Vector3(244, 160, 0), 1).SetEase(Ease.InQuad).SetDelay(1f);
                changeImageGrow.DOFade(0, 1).SetEase(Ease.InQuad).SetDelay(1f).OnComplete(() => { changeImageGrow.gameObject.SetActive(false); });
                });
                differentText.color = Color.green;
            }
            else
            {
                different = "-" + FormatNumsHelper.FormatNum(_price - Mathf.RoundToInt(_price * count));
                changeImageDecrease.gameObject.SetActive(true);
                changeImageDecrease.color = new Color(255, 255, 255, 0);
                changeImageDecrease.GetComponent<RectTransform>().anchoredPosition = new Vector2(244, 160);
                changeImageDecrease.DOFade(1, 1).SetEase(Ease.OutQuad);
                changeImageDecrease.GetComponent<RectTransform>().DOAnchorPos(new Vector3(244, -30, 0), 1).SetEase(Ease.OutQuad).OnComplete(() => {
                changeImageDecrease.GetComponent<RectTransform>().DOAnchorPos(new Vector3(244, -130, 0), 1).SetEase(Ease.InQuad).SetDelay(1f);
                changeImageDecrease.DOFade(0, 1).SetEase(Ease.InQuad).SetDelay(1f).OnComplete(() => { changeImageGrow.gameObject.SetActive(false); });
                });
                differentText.color = Color.red;
            }
            differentText.gameObject.SetActive(false);
            differentText.text = different;
            differentText.gameObject.SetActive(true);
        }
    }
}
