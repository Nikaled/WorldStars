using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public int Coins { 
        get
        {
            return _coinsDontUse;
        }
        set
        {
            _coinsDontUse = value;
            CoinsChanged?.Invoke(_coinsDontUse);
        }
    }

    public event Action<int> CoinsChanged;
    public int _coinsDontUse;
    public LanguageDropdownWriter.UserProfileLanguage userProfileLang;
    public UserCountryDropdown.UserProfileCountry userProfileCountry;
    public bool[] ChosenProfileHobbies;
    public bool[] ChosenProfileWearstyle;


    /////InApps//////
    public string lastBuy;

    public int downloadsCount2;
    internal int myDonat;
}