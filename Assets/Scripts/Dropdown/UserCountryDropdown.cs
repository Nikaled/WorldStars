using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserCountryDropdown : DropdownWriter
{
    public enum UserProfileCountry
    {
        None = 0,
        Brasilia = 1,
        Russia = 2,
        India = 3,
        China = 4,
        UAR = 5,
        Different = 6
    }
    protected override void OnChangeValue(TMP_Dropdown dropdown)
    {
        int index = dropdown.value;
        ChangeCountry(index);
    }
    protected override void Start()
    {
        base.Start();
        currDropdown.value = (int)Geekplay.Instance.PlayerData.userProfileCountry;
    }
    private void ChangeCountry(int countryIndex)
    {
        UserProfileCountry countryEnum = (UserProfileCountry)countryIndex;
        Geekplay.Instance.PlayerData.userProfileCountry = countryEnum;
        Debug.Log("Current country:" + Geekplay.Instance.PlayerData.userProfileCountry);
        Geekplay.Instance.Save();
    }

}
