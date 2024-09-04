using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class StarCell : MonoBehaviour
{
    public string StarName;
    [SerializeField] TextMeshProUGUI StarNameView;
    public UserCountryDropdown.UserProfileCountry StarCountry;
    public Profession starProfession;
    public StarData starData;
    [SerializeField] Button _chooseStarButton;
    [SerializeField] TextMeshProUGUI _chooseStarText;
    [SerializeField] Sprite _inactiveSprite;
    [SerializeField] Sprite _activeSprite;
    private bool _IsStarSelected;
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
    private void Awake()
    {
        StarName = starData.StarName;
        StarNameView.text = starData.StarName;
        StarCountry = starData.StarCountry;
        starProfession = starData.StarProfession;
    }
    public void StarIsChosenView(bool Is)
    {
        if (Is)
        {
            _chooseStarButton.onClick.RemoveAllListeners();
            _chooseStarButton.onClick.AddListener(delegate { DeselectStarButton(); });
            _chooseStarButton.GetComponent<Image>().sprite = _activeSprite;
        }
        else
        {
            _chooseStarButton.onClick.RemoveAllListeners();
            _chooseStarButton.onClick.AddListener(delegate { ChooseStarButton(); });
            _chooseStarButton.GetComponent<Image>().sprite = _inactiveSprite;
        }
        _IsStarSelected = Is;
    }

    public void ChooseStarButton()
    {
        ChooseStarManager.instance.AddStarToChosen(starData);
        StarIsChosenView(true);
    }
    public void DeselectStarButton()
    {

    }
}
