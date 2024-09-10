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
    void Start()
    {
        ShowAboutStarButton.onClick.AddListener(delegate { ShowAboutStarUI(); });
     
    }

    public void SetChosenEventUI(AfishaCell afishaCell)
    {
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
        EventWithStarName.text = "Встреча звезды " + _currentStarData.StarName;
        StarNameInHeaderText.text = _currentStarData.StarName;
    }
    private void ShowAboutStarUI()
    {
        AboutStarUI.instance.SetupParentUIOnClose(childMenuForAboutStar);
        AboutStarUI.instance.ShowAboutStarUI(_currentStarData);
    }

    private void SetupFillBar()
    {
       var d =  DateTime.Today;
    }
}
