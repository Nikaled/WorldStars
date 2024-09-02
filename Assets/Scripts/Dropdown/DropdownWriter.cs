using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DropdownWriter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextBox;
    [SerializeField] protected TMP_Dropdown currDropdown;

    [SerializeField] string[] OptionsName;
    protected virtual void Start()
    {
        currDropdown.options.Clear();

        List<string> Items = new();

        for (int i = 0; i < OptionsName.Length; i++)
        {
            Items.Add(OptionsName[i]);
        }
        foreach (var item in Items)
        {
            currDropdown.options.Add(new TMP_Dropdown.OptionData() { text = item });
        }
        currDropdown.onValueChanged.AddListener(delegate { OnChangeValue(currDropdown); });
    }
    protected virtual void OnChangeValue(TMP_Dropdown dropdown)
    {
        int index = dropdown.value;
        TextBox.text = dropdown.options[index].text;
    }
}
