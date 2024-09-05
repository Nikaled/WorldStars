using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UserCountryDropdown;
public class StarCellManager : MonoBehaviour
{
    [HideInInspector] public StarCell[] starCells;
    public List<StarData> _starsData;
    public static StarCellManager instance;
    [HideInInspector] public UserCountryDropdown.UserProfileCountry chosenCountryForStar = UserCountryDropdown.UserProfileCountry.None;
    private StarCell.Profession _chosenProfession = StarCell.Profession.None;
    private List<string> _searchSuggestions = null;
    private List<StarCell> _showedStars;


    [SerializeField] Image _chooseCountryButtonImage;
    [SerializeField] Image[] _CountryButtonImages;
    [SerializeField] TextMeshProUGUI _currentCountryName;
    [SerializeField] TextMeshProUGUI[] _countryTextes;
    private string _defaultCountryName = "—“–¿Õ¿";

    [SerializeField] Image _chooseProfessionButtonImage;
    [SerializeField] Image[] _professionButtonImages;
    [SerializeField] TextMeshProUGUI _currentProfessionName;
    [SerializeField] TextMeshProUGUI[] _professionTextes;
    private string _defaultProfName = "C‘≈–¿";

    [SerializeField] Sprite _inactiveSprite;
    [SerializeField] Sprite _activeSprite;


    [SerializeField] StarCell _starCellPrefab;
    [SerializeField] Transform _starCellParent;
    [SerializeField] GameObject _allStarsView;
    [SerializeField] Button _showChosenStarsButton;

    [SerializeField] StarCell _chosenStarCellPrefab;
    [SerializeField] Transform _chosenStarCellParent;
    [SerializeField] GameObject _chosenStarsView;
    [SerializeField] Button _showAllStarsButton;


    private StarCell[] _chosenStarCells;

    public bool ChosenStarsChanged;

    private void Awake()
    {
        instance = this;
        CreateStarCells(_starCellPrefab, _starCellParent, _starsData, ref starCells);
        _showedStars = starCells.ToList();
        _currentProfessionName.text = _defaultProfName;
        _currentCountryName.text = _defaultCountryName;
    }

    private void CreateStarCells(StarCell prefab, Transform parent, List<StarData> StarsDataList, ref StarCell[] createdStarCellsArray)
    {
        List<StarCell> CreatedCells = new();
        for (int i = 0; i < StarsDataList.Count; i++)
        {
            var newStar = Instantiate(prefab, parent);
            newStar.SetupStarCell(StarsDataList[i]);
            newStar.StarIsChosenView(false);
            CreatedCells.Add(newStar);
        }
        createdStarCellsArray = new StarCell[CreatedCells.Count];
        createdStarCellsArray = CreatedCells.ToArray();
    }
    public void HideAllStars()
    {
        for (int i = 0; i < starCells.Length; i++)
        {
            starCells[i].gameObject.SetActive(false);
        }
    }

    private void CheckAllLogic()
    {
        _showedStars = starCells.ToList();
        CheckCountryLogic();
        CheckProfessionLogic();
        CheckSearchLogic();
        HideAllStars();
        for (int i = 0; i < _showedStars.Count; i++)
        {
            _showedStars[i].gameObject.SetActive(true);
        }
    }

    public void CheckByCountry(int countryIndex)
    {
        UserProfileCountry chosenCountry = (UserProfileCountry)countryIndex;
        int correctedIndex = countryIndex - 1;

        if (chosenCountryForStar == chosenCountry)
        {
            chosenCountryForStar = UserCountryDropdown.UserProfileCountry.None;

            _CountryButtonImages[correctedIndex].sprite = _inactiveSprite;
            _currentCountryName.text = _defaultCountryName;
        }
        else
        {
            var OldCountry = (int)chosenCountryForStar - 1;

            if (OldCountry >= 0)
            {
                _CountryButtonImages[OldCountry].sprite = _inactiveSprite;
            }
            _CountryButtonImages[correctedIndex].sprite = _activeSprite;
            _currentCountryName.text = _countryTextes[correctedIndex].text;
            chosenCountryForStar = chosenCountry;
        }
        _chooseCountryButtonImage.sprite = chosenCountryForStar == UserCountryDropdown.UserProfileCountry.None ? _inactiveSprite : _activeSprite;

        Debug.Log(chosenCountryForStar);
        CheckAllLogic();
    }
    private void CheckCountryLogic()
    {
        if (chosenCountryForStar != UserCountryDropdown.UserProfileCountry.None)
        {
            for (int i = 0; i < _showedStars.Count; i++)
            {
                if (_showedStars[i].StarCountry != chosenCountryForStar)
                {
                    _showedStars.RemoveAt(i);
                    i--;
                }
            }
        }
    }



    public void CheckByProfession(int ProfEnumIndex)
    {
        var newProf = (StarCell.Profession)ProfEnumIndex;
        if (_chosenProfession == newProf)
        {
            _chosenProfession = StarCell.Profession.None;
            _professionButtonImages[ProfEnumIndex].sprite = _inactiveSprite;
            _currentProfessionName.text = _defaultProfName;
            _chooseProfessionButtonImage.sprite = _inactiveSprite;
        }
        else
        {
            if (newProf != StarCell.Profession.None)
            {
                var oldProf = (int)_chosenProfession;
                if (oldProf >= 0)
                {
                    _professionButtonImages[oldProf].sprite = _inactiveSprite;
                    _professionButtonImages[ProfEnumIndex].sprite = _activeSprite;
                }
                _currentProfessionName.text = _professionTextes[ProfEnumIndex].text;
                _chooseProfessionButtonImage.sprite = _activeSprite;
            }
            _chosenProfession = newProf;

        }
        CheckAllLogic();
    }
    private void CheckProfessionLogic()
    {
        if (_chosenProfession != StarCell.Profession.None)
        {
            for (int i = 0; i < _showedStars.Count; i++)
            {
                if (_showedStars[i].starProfession != _chosenProfession)
                {
                    _showedStars.RemoveAt(i);
                    i--;
                }
            }
        }
    }


    public void ShowSuggestions(List<string> suggestions)
    {
        _searchSuggestions = suggestions;
        CheckAllLogic();
    }
    private void CheckSearchLogic()
    {
        if (_searchSuggestions == null)
        {
            return;
        }
        for (int i = 0; i < _showedStars.Count; i++)
        {
            bool InList = false;
            for (int j = 0; j < _searchSuggestions.Count; j++)
            {
                if (_showedStars[i].StarName == _searchSuggestions[j])
                {
                    InList = true;
                }
            }
            if (InList == false)
            {
                _showedStars.RemoveAt(i);
                i--;
            }
        }
    }


    public void ShowChosenStars()
    {
        ShowChosenView(true);
        if(_chosenStarCells != null)
        {
            if (ChosenStarsChanged)
            {
                for (int i = 0; i < _chosenStarCells.Length; i++)
                {
                    Destroy(_chosenStarCells[i].gameObject);
                }
                _chosenStarCells = null;
                ChosenStarsChanged = false;
            }
        }

        if (_chosenStarCells == null)
        {
            CreateStarCells(_chosenStarCellPrefab, _chosenStarCellParent, ChooseStarManager.instance.ChosenStarsData, ref _chosenStarCells);
        }
    }

    private void ShowChosenView(bool Is)
    {
        _chosenStarsView.SetActive(Is);
        _allStarsView.SetActive(!Is);
        _showAllStarsButton.gameObject.SetActive(Is);
        _showChosenStarsButton.gameObject.SetActive(!Is);
    }
    public void HideChosenStars()
    {
        _chosenStarsView.SetActive(false);
        _allStarsView.SetActive(true);
        ShowChosenView(false);
    }
}
