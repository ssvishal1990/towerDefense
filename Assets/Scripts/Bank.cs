using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] TextMeshProUGUI displayBalance;
    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }

    int winningRequiredGold = 10000;
    private void Awake()
    {
        currentBalance = startingBalance;
        updateDisplayedScore();
    }
    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        updateDisplayedScore();
    }

    public void Withdrawl(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        updateDisplayedScore();
        if (currentBalance < 0)
        {
            Debug.Log(" lost the game");
        }else if (currentBalance > winningRequiredGold)
        {
            // THis is the winning condition. Need to do some stuff here
        }
    }

    void updateDisplayedScore()
    {
        displayBalance.text = "Gold: " + currentBalance;
    }
}
