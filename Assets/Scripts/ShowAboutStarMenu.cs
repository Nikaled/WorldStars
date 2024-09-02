using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAboutStarMenu : MonoBehaviour
{
    [SerializeField] GameObject AboutStarUI;
    [SerializeField] GameObject AboutStarDefaultParent;
    [SerializeField] GameObject AboutStarNewParent;

    private void OnEnable()
    {
        AboutStarUI.transform.parent = AboutStarNewParent.transform;
        AboutStarUI.transform.SetAsLastSibling();
        AboutStarUI.SetActive(false);
      
    }
    private void OnDisable()
    {
        AboutStarUI.transform.parent = AboutStarDefaultParent.transform;
        AboutStarUI.transform.SetAsLastSibling();
    }
}
