using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuScroll : MonoBehaviour
{
    [SerializeField] GameObject[] Previews;
    [SerializeField] Transform FirstPreviewPosition;
    [SerializeField] Transform SecondPreviewPosition;
    private Vector3 _firstPos;
    private Vector3 _secondPos;
    private int _currentPreviewIndex;
    private GameObject _firstPreview;
    private GameObject _secondPreview;
    [SerializeField] Transform[] ElementsTransform;
    private Vector3[] _elementsPositions;
    private Vector3 _firstElementCashedPos;
    private Vector3 _lastElementCashedPos;
    private int _lastVisibleElementIndex = 1;
    private void Start()
    {
        _elementsPositions = new Vector3[ElementsTransform.Length];
        for (int i = 0; i < ElementsTransform.Length; i++)
        {
            _elementsPositions[i] = ElementsTransform[i].position;
        }
        _firstElementCashedPos = _elementsPositions[0];
        _lastElementCashedPos = _elementsPositions[_lastVisibleElementIndex];
        _firstPos = FirstPreviewPosition.position;
        _secondPos = SecondPreviewPosition.position;
        _currentPreviewIndex = 0;
        _firstPreview = FirstPreviewPosition.gameObject;
        _secondPreview = SecondPreviewPosition.gameObject;
    }

    public void ForwardButton()
    {
        for (int i = 0; i < ElementsTransform.Length; i++)
        {
            _elementsPositions[i] = ElementsTransform[i].position;
        }
        for (int i = 0; i < ElementsTransform.Length; i++)
        {
            if(i - 1 > 0 )
            {
                ElementsTransform[i+1].position = _elementsPositions[i];
            }
            else
            {
                ElementsTransform[i].position = _lastElementCashedPos;
            }
            
        }
    }
    public void ShowNewPreviewButton()
    {
        _currentPreviewIndex++;
        _secondPreview.transform.position = _firstPos;
        _firstPreview.transform.position += new Vector3(-1000, 0, 0);
        _firstPreview = _secondPreview;
        if(_currentPreviewIndex == Previews.Length)
        {
            _currentPreviewIndex = 0;
        }
        _secondPreview = Previews[_currentPreviewIndex];
        _secondPreview.transform.position = _secondPos;
    }
    public void ShowPreviousPreviewButton()
    {
        _currentPreviewIndex--;
        _firstPreview.transform.position = _secondPos;
        _secondPreview.transform.position += new Vector3(-1000, 0, 0);
        _secondPreview = _firstPreview;
        if (_currentPreviewIndex == -1)
        {
            _currentPreviewIndex = Previews.Length -1;
        }
        _firstPreview = Previews[_currentPreviewIndex];
        _firstPreview.transform.position = _firstPos;
    }
}
