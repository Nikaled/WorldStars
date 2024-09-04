using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseStarManager : MonoBehaviour
{
    public List<StarData> _chosenStarsData = new();
    public static ChooseStarManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void AddStarToChosen(StarData chosenStar)
    {
        for (int i = 0; i < _chosenStarsData.Count; i++)
        {
            if (_chosenStarsData[i].name == chosenStar.name)
            {
                return;
            }
        }
        _chosenStarsData.Add(chosenStar);
    }
    public void RemoveStarFromChosen(StarData chosenStar)
    {
        for (int i = 0; i < _chosenStarsData.Count; i++)
        {
            if (_chosenStarsData[i].name == chosenStar.name)
            {
                _chosenStarsData.RemoveAt(i);
                return;
            }
        }
    }
}
