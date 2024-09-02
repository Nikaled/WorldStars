using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondChildMenu : ChildMenu
{
    [SerializeField] ChildMenu ParentUI;


    private void OnDisable()
    {
        ParentUI.SetupHeaderBackButton();
    }
}
