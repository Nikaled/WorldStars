using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseStarManager : MonoBehaviour
{
    public List<StarData> ChosenStarsData = new();
    public static ChooseStarManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void AddStarToChosen(StarData chosenStar)
    {
        for (int i = 0; i < ChosenStarsData.Count; i++)
        {
            if (ChosenStarsData[i].name == chosenStar.name)
            {
                return;
            }
        }
        ChosenStarsData.Add(chosenStar);
    }
    public void RemoveStarFromChosen(StarData chosenStar)
    {
        for (int i = 0; i < ChosenStarsData.Count; i++)
        {
            if (ChosenStarsData[i].name == chosenStar.name)
            {
                ChosenStarsData.RemoveAt(i);
                return;
            }
        }
    }
}
