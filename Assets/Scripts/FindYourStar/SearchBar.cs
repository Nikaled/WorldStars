using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SearchBar : MonoBehaviour
{
    
    public TMP_InputField searchInput; // ���� ����� ��� ������
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
        // ������� ��������� � �������������

        StarCellManager.instance.HideAllStars();
        // ���� ������ ������ �����, �� ���������� ������
        if (string.IsNullOrEmpty(input)) return;

        // ������� ��� ������, ������� �������� �������� �����
        var suggestions = data.Where(item => item.ToLower().Contains(input.ToLower())).ToList();

        StarCellManager.instance.ShowSuggestions(suggestions);
        
    }
}