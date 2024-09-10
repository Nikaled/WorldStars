using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName ="AfishaData", menuName ="ScriptableObjects/AfishaData", order =100)]
public class AfishaDataSO : ScriptableObject
{
    public StarData starData;
    public string Date = "2024-09-10";
    public Sprite MainPicture;
    public string ShortDescription;
    public string Schedule;
    public int MemberSlotsCount;
    public int StartPrice;
    public int PriceRateStep;
}
