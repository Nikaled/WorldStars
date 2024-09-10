using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class AfishaCell : MonoBehaviour
{
    [HideInInspector] public AfishaDataSO AfishaData;
    [HideInInspector] public DateTime Date;
    public TextMeshProUGUI DateText;
    [HideInInspector] public Sprite MainPicture;
    public Image PreviewImage;
    [HideInInspector] public string ShortDescription;
    public TextMeshProUGUI ShortDescText;
    [HideInInspector] public string Schedule;
    [HideInInspector] public int MemberSlotsCount;
    [HideInInspector] public int StartPrice;
    [HideInInspector] public int PriceRateStep;
    public Button OpenEventButton;
    public void SetDataToFields(AfishaDataSO afishaData)
    {
        AfishaData = afishaData;
        DateTime d;
        DateTime.TryParse(afishaData.Date, out d);
        Date = d;
        MainPicture = AfishaData.MainPicture;
        ShortDescription = AfishaData.ShortDescription;
        Schedule = AfishaData.Schedule;
        MemberSlotsCount = AfishaData.MemberSlotsCount;
        StartPrice = AfishaData.StartPrice;
        PriceRateStep = AfishaData.PriceRateStep;
        DateText.text = Date.ToString();
        ShortDescText.text = ShortDescription;
    }
    private void Start()
    {
        OpenEventButton.onClick.AddListener(delegate { AfishaManager.instance.OpenStarEvent(this); });
    }
}
