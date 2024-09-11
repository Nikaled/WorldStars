using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class AfishaManager : MonoBehaviour
{
    [SerializeField] AfishaCell _afishaPrefab;
    private AfishaDataSO[] _starEvents;
    private List<AfishaCell> _currentCells = new();
    [SerializeField] Transform _cellParent;
    private AfishaCell _pressedCell;
    public static AfishaManager instance;
    [SerializeField] ChosenEventUI _chosenEventUI;
    [SerializeField] StarData DebugStarData;
    private int? _currentMonth = null;

    [SerializeField] Sprite _activeSprite;
    [SerializeField] Sprite _inactiveSprite;
    [SerializeField] TextMeshProUGUI _chooseMonthText;
    [SerializeField] TextMeshProUGUI[] _monthsTexts;
    [SerializeField] Button[] _monthsButton;
    [SerializeField] Button _chooseMonthButton;
    private string _defaultChooseMonthText;
    private void Awake()
    {
        instance = this;
        _defaultChooseMonthText = _chooseMonthText.text;
    }
    private void Start()
    {
        SetStarEvents(DebugStarData);
    }
    public void SetStarEvents(StarData starData)
    {
        _starEvents = starData.StarEvents;
        CreateEvents();
    }

    private void CreateEvents()
    {
        DestroyCells();

        for (int i = 0; i < _starEvents.Length; i++)
        {
            var newCell = Instantiate(_afishaPrefab, _cellParent);
            newCell.SetDataToFields(_starEvents[i]);
            _currentCells.Add(newCell);
        }
    }
    private void DestroyCells()
    {
        for (int i = 0; i < _currentCells.Count; i++)
        {
            Destroy(_currentCells[i].gameObject);
        }
    }
    public void OpenStarEvent(AfishaCell PressedCell)
    {
        _pressedCell = PressedCell;
        _chosenEventUI.SetChosenEventUI(_pressedCell);
    }
    public void ChooseMonth(int MonthNumber)
    {
        ButtonView(MonthNumber);

        if (_currentMonth == MonthNumber)
        {
            ShowAllEvents();
            _currentMonth = null;
            return;
        }
        _currentMonth = MonthNumber;


        for (int i = 0; i < _currentCells.Count; i++)
        {
            if (_currentCells[i].Date.Month == MonthNumber)
            {
                _currentCells[i].gameObject.SetActive(true);
            }
            else
            {
                _currentCells[i].gameObject.SetActive(false);
            }
        }
    }
    private void ButtonView(int MonthNumber)
    {
        if(_currentMonth == MonthNumber)
        {
            _monthsButton[MonthNumber - 1].image.sprite = _inactiveSprite;
            _chooseMonthButton.image.sprite = _inactiveSprite;
            _chooseMonthText.text = _defaultChooseMonthText;
            return;
        }
        if (_currentMonth != null)
        {
            _monthsButton[((int)_currentMonth) - 1].image.sprite = _inactiveSprite;
        }
        _monthsButton[MonthNumber - 1].image.sprite = _activeSprite;
        _chooseMonthButton.image.sprite = _activeSprite;
        _chooseMonthText.text = _monthsTexts[MonthNumber - 1].text;
    }
    public void ShowAllEvents()
    {
        for (int i = 0; i < _currentCells.Count; i++)
        {
            _currentCells[i].gameObject.SetActive(true);
        }
    }
}
