using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ChosenEventUI : MonoBehaviour
{
    public TextMeshProUGUI[] DateTexts;
    public TextMeshProUGUI ScheduleText;
    public TextMeshProUGUI MemberSlotCountText;
    public TextMeshProUGUI StartPriceText;
    public TextMeshProUGUI PriceRateStepText;
    public TextMeshProUGUI StarNameInHeaderText;
    private StarData _currentStarData;
    [SerializeField] GameObject eventUI;
    public TextMeshProUGUI EventWithStarName;
    public Button ShowAboutStarButton;
    public ChildMenu childMenuForAboutStar;
    private AfishaCell _currentafishaCell;
    [SerializeField] Image AuñtionTimerFillImage;
    [SerializeField] TextMeshProUGUI AuñtionTimerText;
    void Start()
    {
        ShowAboutStarButton.onClick.AddListener(delegate { ShowAboutStarUI(); });
    }

    public void SetChosenEventUI(AfishaCell afishaCell)
    {
        _currentafishaCell = afishaCell;
        ScheduleText.text = afishaCell.Schedule;
        MemberSlotCountText.text = afishaCell.MemberSlotsCount.ToString();
        StartPriceText.text = afishaCell.StartPrice.ToString();
        PriceRateStepText.text = afishaCell.PriceRateStep.ToString();
        for (int i = 0; i < DateTexts.Length; i++)
        {
            DateTexts[i].text = afishaCell.Date.ToString();
        }
        _currentStarData = afishaCell.AfishaData.starData;
        eventUI.SetActive(true);
        EventWithStarName.text = "Âñòðå÷à çâåçäû " + _currentStarData.StarName;
        StarNameInHeaderText.text = _currentStarData.StarName;
        SetupFillBar();
    }
    private void ShowAboutStarUI()
    {
        AboutStarUI.instance.SetupParentUIOnClose(childMenuForAboutStar);
        AboutStarUI.instance.ShowAboutStarUI(_currentStarData);
    }

    private void SetupFillBar()
    {
       var d =  DateTime.Now;
        var d2 = _currentafishaCell.Date;
        TimeSpan remainingTime = d2 - d;
        Debug.Log("d.Minute" + d.Minute);
        AuñtionTimerText.text = $"{remainingTime.Days} äíåé {remainingTime.Hours} ÷àñîâ {remainingTime.Minutes} ìèíóò";
        string t =string.Format("{0:D2}:{1:D2}:{2:D2}",
                remainingTime.Days,
                remainingTime.Hours,
                remainingTime.Minutes);
        Debug.Log($"date diff:{t} ");
    }
}
