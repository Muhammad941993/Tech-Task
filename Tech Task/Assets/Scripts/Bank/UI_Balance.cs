using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Balance : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI balanceText;
    Player player;
  
    void Start()
    {
        player = FindObjectOfType<Player>();
        player.OnBalanceChange += UpdateBalance;
    }

    private void OnDestroy()
    {
        player.OnBalanceChange -= UpdateBalance;
    }

    public void UpdateBalance()
    {
        balanceText.text =$"$ {player.GetCurrentCoins()}";
    }
}
