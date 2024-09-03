using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarCell : MonoBehaviour
{
    public string StarName;
    [SerializeField] TextMeshProUGUI StarNameView;
    public UserCountryDropdown.UserProfileCountry StarCountry;
    public Profession starProfession;
    public enum Profession
    {
        None = -1,
        Fashion = 0,
        Music = 1,
        Cinema = 2,
        Dancing = 3,
        Volleyball = 4,
        Football = 5,
        Cricket = 6,
        Basketball = 7,
        Hockey = 8
    }
    private void Start()
    {
        StarNameView.text = StarName;
    }
}
