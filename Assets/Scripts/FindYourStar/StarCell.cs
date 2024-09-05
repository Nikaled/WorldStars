using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class StarCell : MonoBehaviour
{
    [HideInInspector] public string StarName;
    [SerializeField] TextMeshProUGUI StarNameView;
    [HideInInspector] public UserCountryDropdown.UserProfileCountry StarCountry;
    [HideInInspector] public Profession starProfession;
    [HideInInspector] public StarData starData;

    [Header("SelectStarFields")]
    [SerializeField] Button _chooseStarButton;
    [SerializeField] TextMeshProUGUI _chooseStarText;
    [SerializeField] Sprite _inactiveSprite;
    [SerializeField] Sprite _activeSprite;
    private string _defaultButtonText = "¬€¡–¿“‹";
    private string _chosenButtonText = "¬€¡–¿ÕŒ";
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

    public void SetupStarCell(StarData starData)
    {
        this.starData = starData;
        StarName = starData.StarName;
        StarNameView.text = starData.StarName;
        StarCountry = starData.StarCountry;
        starProfession = starData.StarProfession;
        if(_chooseStarText != null)
        {
        _chooseStarText.text = _defaultButtonText;
        }
    }
    public virtual void StarIsChosenView(bool Is)
    {
        if (Is)
        {
            _chooseStarButton.onClick.RemoveAllListeners();
            _chooseStarButton.onClick.AddListener(delegate { DeselectStarButton(); });
            _chooseStarButton.GetComponent<Image>().sprite = _activeSprite;
            _chooseStarText.text = _chosenButtonText;
        }
        else
        {
            _chooseStarButton.onClick.RemoveAllListeners();
            _chooseStarButton.onClick.AddListener(delegate { ChooseStarButton(); });
            _chooseStarButton.GetComponent<Image>().sprite = _inactiveSprite;
            _chooseStarText.text = _defaultButtonText;
        }
    }
    public void ChooseStarButton()
    {
        ChooseStarManager.instance.AddStarToChosen(starData);
        StarCellManager.instance.ChosenStarsChanged = true;
        StarIsChosenView(true);
    }
    public void DeselectStarButton()
    {
        ChooseStarManager.instance.RemoveStarFromChosen(starData);
        StarCellManager.instance.ChosenStarsChanged = true;
        StarIsChosenView(false);
    }

    public void ShowStarInfo_Button()
    {
        AboutStarUI.instance.ShowAboutStarUI(starData);
    }
}
