using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChosenEventUI : MonoBehaviour
{
    public TextMeshProUGUI[] DateTexts;
    public TextMeshProUGUI ScheduleText;
    public TextMeshProUGUI MemberSlotCountText;
    public TextMeshProUGUI StartPriceText;
    public TextMeshProUGUI PriceRateStepText;
    private StarData _currentStarData;
    void Start()
    {

    }

    public void SetChosenEventUI(AfishaCell afishaCell)
    {
        ScheduleText.text = afishaCell.Schedule;
        MemberSlotCountText.text = afishaCell.MemberSlotsCount.ToString();
        StartPriceText.text = afishaCell.StartPrice.ToString();
        PriceRateStepText.text = afishaCell.PriceRateStep.ToString();
        for (int i = 0; i < DateTexts.Length; i++)
        {
            DateTexts[i].text = afishaCell.Date;
        }
        _currentStarData = afishaCell.AfishaData.starData;
    }
}
