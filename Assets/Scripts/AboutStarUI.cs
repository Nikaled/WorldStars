using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AboutStarUI : MonoBehaviour
{
    public static AboutStarUI instance;
    public StarData currentStar;

    [SerializeField] TextMeshProUGUI StarName;
    [SerializeField] TextMeshProUGUI StarInfo;
    [SerializeField] Image StarImage;
    [SerializeField] GameObject AboutStarUIObject;
    private void Awake()
    {
        instance = this;
    }

    public void ShowAboutStarUI(StarData chosenStar)
    {
        currentStar = chosenStar;
        StarName.text = currentStar.StarName;
        StarInfo.text = currentStar.StarDescription;
        StarImage.sprite = currentStar.StarImage;
 
        AboutStarUIObject.SetActive(true);

    }
}
