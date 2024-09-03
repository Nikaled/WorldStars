using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CopyReferalButton : MonoBehaviour
{
    [HideInInspector] public string ReferalString;
    [SerializeField] private TextMeshProUGUI _referalURL;
    public void CopyText()
    {
        ReferalString = _referalURL.text;
        GUIUtility.systemCopyBuffer = ReferalString;
        Debug.Log("Text copied to clipboard: " + ReferalString);
    }
}