using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBackButtonManager : MonoBehaviour
{
    public Button BackButton;
    public static ShowBackButtonManager instance;
    private void Awake()
    {
        instance = this;
    }

    public void SetButtonFunc(GameObject ObjectToHide)
    {
        BackButton.gameObject.SetActive(true);
        BackButton.onClick.RemoveAllListeners();
        BackButton.onClick.AddListener(() => ObjectToHide.SetActive(false)); 
    }
}
