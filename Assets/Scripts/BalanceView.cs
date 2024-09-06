using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BalanceView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI BalanceText;


    private void OnEnable()
    {
        StartCoroutine(enCor());
        IEnumerator enCor()
        {
            yield return new WaitForEndOfFrame();
            ChangeBalanceText(Geekplay.Instance.PlayerData.Coins);
            Geekplay.Instance.PlayerData.CoinsChanged += ChangeBalanceText;
        }

    }
    private void ChangeBalanceText(int balance)
    {
        BalanceText.text = balance.ToString();
    }
    private void OnDisable()
    {
        Geekplay.Instance.PlayerData.CoinsChanged -= ChangeBalanceText;
    }
}
