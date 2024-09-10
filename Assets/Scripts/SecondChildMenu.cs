using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondChildMenu : ChildMenu
{
    public ChildMenu ParentUI;
    public bool DynamicField;

    private void OnDisable()
    {
        if (ParentUI != null)
        {
            ParentUI.SetupHeaderBackButton();
        }
        if (DynamicField)
        {
            ParentUI = null;
        }
    }
}
