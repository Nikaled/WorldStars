using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SearchBar : MonoBehaviour
{
    
    public TMP_InputField searchInput; // Поле ввода для поиска
    private List<string> data = new();
    
    void Start()
    {
        for (int i = 0; i < StarCellManager.instance.starCells.Length; i++)
        {
            data.Add(StarCellManager.instance.starCells[i].StarName);
        }
        searchInput.onValueChanged.AddListener(OnSearchInputChanged);
    }

    void OnSearchInputChanged(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            StarCellManager.instance.ShowSuggestions(null);
            return;
        }
        

        // Находим все строки, которые содержат введённый текст
        var suggestions = data.Where(item => item.ToLower().Contains(input.ToLower())).ToList();

        StarCellManager.instance.ShowSuggestions(suggestions);
        
    }
}