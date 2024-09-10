using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfishaManager : MonoBehaviour
{
    [SerializeField] AfishaCell _afishaPrefab;
    private AfishaDataSO[] _starEvents;
    private List<AfishaCell> _currentCells = new();
    [SerializeField] Transform _cellParent;
    private AfishaCell _pressedCell;
    public static AfishaManager instance;
    [SerializeField] ChosenEventUI _chosenEventUI;
    private void Awake()
    {
        instance = this;
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
}
