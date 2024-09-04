using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StarData", menuName = "ScriptableObjects/StarData", order = 53)]
public class StarData : ScriptableObject
{
    public Sprite StarImage;
    public string StarName;
    public string StarDescription;
    public StarCell.Profession StarProfession;
    public UserCountryDropdown.UserProfileCountry StarCountry;
}
