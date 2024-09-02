using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMenuUIManager : MonoBehaviour
{
    [SerializeField] GameObject[] MenuGroup;

    public void HideAllMenuUI()
    {
        for (int i = 0; i < MenuGroup.Length; i++)
        {
            MenuGroup[i].SetActive(false);
        }
    }
}
