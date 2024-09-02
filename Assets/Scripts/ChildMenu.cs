using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildMenu : MonoBehaviour
{
    private void OnEnable()
    {
        SetupHeaderBackButton();
    }

    public void SetupHeaderBackButton()
    {
        ShowBackButtonManager.instance.SetButtonFunc(gameObject);
    }
}
