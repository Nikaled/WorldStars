using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="AfishaData", menuName ="ScriptableObjects/AfishaData", order =100)]
public class AfishaDataSO : ScriptableObject
{
    public StarData starData;
    public string Date;
    public Sprite MainPicture;
    public string ShortDescription;
    public string Schedule;
    public int MemberSlotsCount;
    public int StartPrice;
    public int PriceRateStep;
}
