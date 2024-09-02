using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LanguageDropdownWriter : DropdownWriter
{
    public enum UserProfileLanguage
    {
        None = 0,
        Russian = 1,
        English = 2,
        Portugal = 3,
        Thai = 4,
        Chinese = 5,
        Isizulu = 6
    }
    protected override void OnChangeValue(TMP_Dropdown dropdown)
    {
        int index = dropdown.value;
        ChangeLang(index);
    }
    protected override void Start()
    {
        base.Start();
        currDropdown.value = (int)Geekplay.Instance.PlayerData.userProfileLang;
    }
    private void ChangeLang(int langIndex)
    {
        UserProfileLanguage newLang = (UserProfileLanguage)langIndex;
        Geekplay.Instance.PlayerData.userProfileLang = newLang;
        Debug.Log("Current Language:" + Geekplay.Instance.PlayerData.userProfileLang);
        Geekplay.Instance.Save();
    }
}
