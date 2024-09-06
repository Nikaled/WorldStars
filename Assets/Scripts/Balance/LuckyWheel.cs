using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using DG.Tweening;


public class LuckyWheel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI RewardText;
    [SerializeField] GameObject RewardUI;
    [SerializeField] TextMeshProUGUI AddCoinsInputFieldText;
    [SerializeField] TMP_InputField AddCoinsInputField;
    [SerializeField] GameObject Wheel;
    Dictionary<int, int> SpinsCostsDictionary = new();

    private int[] _slotRewards;
    private int _currentReward;
    private float _secondsToOneSpin = 1f;
    private Vector3[] _wheelPosToSlots;
    private void Start()
    {
        Geekplay.Instance.PlayerData.Coins = 10000;
        SpinsCostsDictionary.Add(1, 100);   
        SpinsCostsDictionary.Add(2, 200);   
        SpinsCostsDictionary.Add(3, 300);
        SpinsCostsDictionary.Add(4, 300);
        SpinsCostsDictionary.Add(5, 300);
        _slotRewards = new int[] { 100, 200, 300, 400, 1000, 1200, 1400, 2000 };
        _wheelPosToSlots = new Vector3[_slotRewards.Length];

        float step = 360 / _wheelPosToSlots.Length;
        for (int i = 0; i < _wheelPosToSlots.Length; i++)
        {
            _wheelPosToSlots[i] = new Vector3(0, 0, step*i);
        }
    }
    public void TrySpinWheel_Button(int spins)
    {
        int cost;
       bool IsCorrectValue =  SpinsCostsDictionary.TryGetValue(spins, out cost);

        if (IsCorrectValue == false)
        {
            Debug.Log("Неправильное количество спинов");
            return;
        }
        if(Geekplay.Instance.PlayerData.Coins >= cost)
        {
            SpinLogic(spins);
        }
        else
        {
            return;
        }
    }

    private void SpinLogic(int Spins)
    {
        _currentReward = 0;
        StartCoroutine(SpinsAnimation());
        IEnumerator SpinsAnimation()
        {
            
            for (int i = 0; i < Spins; i++)
            {
                int rewardIndex = UnityEngine.Random.Range(0, _slotRewards.Length);
                _currentReward += _slotRewards[rewardIndex];
                RotateWheel(rewardIndex);
                yield return new WaitForSeconds(_secondsToOneSpin);
            }
            RewardText.text = _currentReward.ToString();
            RewardUI.SetActive(true);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            RotateWheel(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            RotateWheel(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            RotateWheel(2);
        }
    }
    private void RotateWheel(int rewardIndex)
    {
        Vector3 WheelToPointerCorrectingPos = new Vector3(0, 0, 90);
        Vector3 EndRotation = _wheelPosToSlots[rewardIndex] + WheelToPointerCorrectingPos;
        Wheel.transform.DORotate(EndRotation, 0);

        for (int i = 0; i < 3600; i++)
        {
            Wheel.transform.DOBlendableRotateBy(new Vector3(0, 0, 180), 1);
        }
        //Wheel.transform.DORotate( new Vector3(0,0,750), 5);
    }
    public void TryAddCoins()
    {  
        string numberInField = AddCoinsInputField.text;
        Debug.Log(numberInField);
        try
        {
            int result = int.Parse(numberInField);
            Geekplay.Instance.PlayerData.Coins += result;
        }
        catch (FormatException)
        {
            AddCoinsInputField.text = string.Empty;
            Debug.Log("Неверный ввод");
        }
    }
}
