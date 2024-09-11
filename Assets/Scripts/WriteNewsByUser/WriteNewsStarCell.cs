using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WriteNewsStarCell : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI StarName;
    StarData _starData; 

    public void InitCell(StarData starData)
    {
        _starData = starData;
        StarName.text = _starData.name;


    }
}
