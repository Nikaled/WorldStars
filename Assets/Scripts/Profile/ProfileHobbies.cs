using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileHobbies : MonoBehaviour
{
    [SerializeField] Sprite _inactiveSprite;
    [SerializeField] Sprite _activeSprite;
    [SerializeField] Image[] _hobbies;
    [SerializeField] Image[] _wearStyle;
    private bool[] _hobbiesStatus;
    private bool[] _wearStyleStatus;


    private void Start()
    {
        DefaultSetupImages(_hobbies, ref _hobbiesStatus);
        DefaultSetupImages(_wearStyle, ref _wearStyleStatus);

        LoadArrData(Geekplay.Instance.PlayerData.ChosenProfileHobbies, ref _hobbiesStatus, _hobbies);
        LoadArrData(Geekplay.Instance.PlayerData.ChosenProfileWearstyle, ref _wearStyleStatus, _wearStyle);
        //LoadHobbies();
        //LoadWearStyle();
    }

    private void DefaultSetupImages(Image[] _images, ref bool[] arr)
    {
        arr = new bool[_images.Length];
        for (int i = 0; i < _images.Length; i++)
        {
            _images[i].sprite = _inactiveSprite;
        }
    }
    private void LoadArrData(bool[] PlayerdataArr, ref bool[] arr, Image[] images)
    {
        if (PlayerdataArr != null)
        {
            if (PlayerdataArr.Length > 0)
            {
                arr = PlayerdataArr;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i])
                    {
                        images[i].sprite = _activeSprite;
                    }
                    else
                    {
                        images[i].sprite = _inactiveSprite;
                    }
                }
            }
        }
    }
    public void HobbyToggle(int hobbyIndex)
    {
        if (_hobbiesStatus[hobbyIndex])
        {
            _hobbies[hobbyIndex].sprite = _inactiveSprite;
        }
        else
        {
            _hobbies[hobbyIndex].sprite = _activeSprite;
        }
        _hobbiesStatus[hobbyIndex] = !_hobbiesStatus[hobbyIndex];
        Geekplay.Instance.PlayerData.ChosenProfileHobbies = _hobbiesStatus;
        Geekplay.Instance.Save();
    }

    public void WearstyleToggle(int WearIndex)
    {
        if (_wearStyleStatus[WearIndex])
        {
            _wearStyle[WearIndex].sprite = _inactiveSprite;
        }
        else
        {
            _wearStyle[WearIndex].sprite = _activeSprite;
        }
        _wearStyleStatus[WearIndex] = !_wearStyleStatus[WearIndex];
        Geekplay.Instance.PlayerData.ChosenProfileWearstyle = _wearStyleStatus;
        Geekplay.Instance.Save();
    }
}
