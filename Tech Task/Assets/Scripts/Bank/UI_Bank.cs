using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Bank : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI accountBalance;
    BankAccount bankAccount;
    private void Awake()
    {
        bankAccount = FindObjectOfType<BankAccount>();
        UpdateAccountBalance();
    }

    private void Start()
    {
        bankAccount.OnBalanceChange += UpdateAccountBalance;

    }

    private void OnDestroy()
    {
        bankAccount.OnBalanceChange -= UpdateAccountBalance;

    }

    void UpdateAccountBalance()
    {
        accountBalance.text = $"$ {bankAccount.GetCurrentBalance()}";
    }
}
