using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChosenStarCell : StarCell
{
    [Header("ChosenStarFields")]
    [SerializeField] Button ToChatButton;
    [SerializeField] Button ToNewsButton;

    public override void StarIsChosenView(bool Is)
    {
        return;
    }
}
