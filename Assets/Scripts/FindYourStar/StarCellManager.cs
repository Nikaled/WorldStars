using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCellManager : MonoBehaviour
{
    public StarCell[] starCells;
    public static StarCellManager instance;
    [HideInInspector] public UserCountryDropdown.UserProfileCountry chosenCountryForStar = UserCountryDropdown.UserProfileCountry.None;
    private StarCell.Profession _chosenProfession = StarCell.Profession.None;
    private void Awake()
    {
        instance = this;
    }

    public void HideAllStars()
    {
        for (int i = 0; i < starCells.Length; i++)
        {
            starCells[i].gameObject.SetActive(false);
        }
    }

    public void ShowAllStars()
    {
        for (int i = 0; i < starCells.Length; i++)
        {
            starCells[i].gameObject.SetActive(true);
        }
    }
    public void CheckByCountry(UserCountryDropdown.UserProfileCountry chosenCountry)
    {
        if(chosenCountryForStar == chosenCountry)
        {
            chosenCountryForStar = UserCountryDropdown.UserProfileCountry.None;
        }
        else
        {
        chosenCountryForStar = chosenCountry;
        }
        Debug.Log(chosenCountryForStar);
        ShowAllStars();
        CheckCountryLogic();
        CheckProfessionLogic();
    }
    private void CheckCountryLogic()
    {
        if (chosenCountryForStar != UserCountryDropdown.UserProfileCountry.None)
        {
            for (int i = 0; i < starCells.Length; i++)
            {
                if (starCells[i].gameObject.activeInHierarchy)
                {
                    if (starCells[i].StarCountry != chosenCountryForStar)
                    {
                        starCells[i].gameObject.SetActive(false);
                    }
                }
            }
        }
    }
    private void CheckProfessionLogic()
    {
        if (_chosenProfession != StarCell.Profession.None)
        {
            for (int i = 0; i < starCells.Length; i++)
            {
                if (starCells[i].gameObject.activeInHierarchy)
                {
                    if (starCells[i].starProfession != _chosenProfession)
                    {
                        starCells[i].gameObject.SetActive(false);
                    }
                }
            }
        }
    }
    public void CheckByProfession(int ProfEnumIndex)
    {
         var newProf = (StarCell.Profession)ProfEnumIndex;
        if(_chosenProfession == newProf)
        {
            _chosenProfession = StarCell.Profession.None;
        }
        else
        {
            _chosenProfession = newProf;
        }
        ShowAllStars();
        CheckProfessionLogic();
        CheckCountryLogic();
    }
    public void ShowSuggestions(List<string> suggestions)
    {

        for (int i = 0; i < starCells.Length; i++)
        {
            bool InList = false;
            for (int j = 0; j < suggestions.Count; j++)
            {
                if(starCells[i].StarName == suggestions[j])
                {
                    starCells[i].gameObject.SetActive(true);
                    InList = true;
                }
            }
            if(InList == false)
            {
                starCells[i].gameObject.SetActive(false);
            }
        }
    }
}
