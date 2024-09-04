using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindStarCountryDropdown : UserCountryDropdown
{
    protected override void Start()
    {
        base.Start();
        currDropdown.value = 0;
    }
    protected override void ChangeCountry(int countryIndex)
    {
        UserProfileCountry countryEnum = (UserProfileCountry)countryIndex;
        //StarCellManager.instance.CheckByCountry(countryEnum);
    }
}
