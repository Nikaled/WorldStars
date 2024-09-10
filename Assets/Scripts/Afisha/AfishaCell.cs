using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AfishaCell : MonoBehaviour
{
    [HideInInspector] public AfishaDataSO AfishaData;
    [HideInInspector] public string Date;
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
        Date = AfishaData.Date;
        MainPicture = AfishaData.MainPicture;
        ShortDescription = AfishaData.ShortDescription;
        Schedule = AfishaData.Schedule;
        MemberSlotsCount = AfishaData.MemberSlotsCount;
        StartPrice = AfishaData.StartPrice;
        PriceRateStep = AfishaData.PriceRateStep;
        DateText.text = Date;
        ShortDescText.text = ShortDescription;
    }
    private void Start()
    {
        OpenEventButton.onClick.AddListener(delegate { AfishaManager.instance.OpenStarEvent(this); });
    }
}
