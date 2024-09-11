using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WriteNewsByUser : MonoBehaviour
{
    [SerializeField] TMP_InputField NewsHeader;
    [SerializeField] TMP_InputField NewsContent;
    [SerializeField] Sprite LoadedMainPhoto;
    [SerializeField] Sprite[] NewsPhotos;
    [SerializeField] Image[] LoadedPhotos;
    [SerializeField] Image MainPhoto;
    [SerializeField] GameObject ChooseStarPrefab;
    private string _headerText;
    private string _newsContentText;
    private StarData currentStarData;
    public void ApplyUserNews()
    {
        _headerText = NewsHeader.text;
        _newsContentText = NewsContent.text;
    }
    public void ChooseStar()
    {

    }
}
