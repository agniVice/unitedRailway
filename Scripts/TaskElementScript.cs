using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization.Components;
using DG.Tweening;

public class TaskElementScript : MonoBehaviour
{
    [SerializeField] private TasksSystemScript tsScript;
    [SerializeField] private TaskInfo tInfo;
    [SerializeField] public string type;
    [SerializeField] private float count;
    [SerializeField] private float currentCount;
    [SerializeField] private float newCurrentCount;
    [SerializeField] private string nameTask;
    [SerializeField] private string info;
    [SerializeField] private float price;
    [SerializeField] private bool isTicket;
    [SerializeField] public bool isGeneral;
    [SerializeField] private Sprite spriteTask;

    //UI
    [SerializeField] private LocalizeStringEvent nameTaskText;
    [SerializeField] private LocalizeStringEvent infoTaskText;
    [SerializeField] private TextMeshProUGUI countTaskText;
    [SerializeField] private TextMeshProUGUI priceTaskText;
    [SerializeField] private Image fullBar;
    [SerializeField] private Image currency;
    [SerializeField] public Image mask;
    public Image imageTask;
    public Image doneImage;

    private float elapsedTime;
    private float timer = 3f;
    public void Init()
    {
        type = tInfo.type;
        count = tInfo.count;
        info = tInfo.info;
        price = tInfo.price;
        isTicket = tInfo.isTicket;
        isGeneral = tInfo.isGeneral;
        nameTask = tInfo.nameTask;
        imageTask.sprite = tInfo.spriteTask;

        nameTaskText.SetEntry(nameTask);
        nameTaskText.StringReference.Arguments = new[] { count.ToString() };
        nameTaskText.RefreshString();
        infoTaskText.SetEntry(info);
        infoTaskText.StringReference.Arguments = new[] { count.ToString() };
        infoTaskText.RefreshString();

        countTaskText.text = FormatNumsHelper.FormatNum(currentCount) + "/" + FormatNumsHelper.FormatNum(count);
        priceTaskText.text = FormatNumsHelper.FormatNum(price);
        fullBar.fillAmount = currentCount / count;
        if (isTicket)
            currency.sprite = tsScript.uiScript.currencyTickets;
        else
            currency.sprite = tsScript.uiScript.currencyMoney;
        if (isDone())
            doneImage.gameObject.SetActive(true);
        else
            doneImage.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (tsScript.uiScript.isTaskMenuOpen)
        {
            if (currentCount != newCurrentCount)
            {
                elapsedTime += Time.deltaTime;
                float perc = elapsedTime / timer;
                currentCount = Mathf.Lerp(currentCount, newCurrentCount, Mathf.SmoothStep(0, 1, perc));
                countTaskText.text = FormatNumsHelper.FormatNum(currentCount) + "/" + FormatNumsHelper.FormatNum(count);
                fullBar.fillAmount = currentCount / count;
            }
        }
    }
    private void CompleteTask()
    {
        GivePlayerReward();
        newCurrentCount = count;
        tsScript.IsAllTasksDone();
        doneImage.gameObject.SetActive(true);
        tsScript.uiScript.audioUI.PlaySoundThird(tsScript.uiScript.audioUI.TaskComplete);
    }
    private void GivePlayerReward()
    {
        if (isDone())
        {
            if (isTicket)
                tsScript.uiScript.mainScript.pData.ChangeTickets(this.gameObject, price, false);
            else
                tsScript.uiScript.mainScript.pData.ChangeMoney(this.gameObject, price, false);
        }
    }
    public bool isDone()
    {
        if (newCurrentCount >= count)
            return true;
        else
            return false;
    }
    public void TakeInfo(float count)
    {
        elapsedTime = 0;
        newCurrentCount += count;
        if (isDone())
            CompleteTask();
    }
}
