using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class PopupBank : MonoBehaviour
{
    [Header("스파르타 뱅크")]
    public Text UserInfoCash;
    public Text CashPrice;
    public GameObject ZeroCashPanel;

    [Header("입출금")]
    public GameObject ATM;
    public GameObject Deposit;
    public GameObject Withdraw;
    public GameObject Balance;
    public InputField InputDeposit;
    public InputField InputWithdraw;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.bank = this;
        Refresh();
    }

    public void Refresh()
    {
        UserInfoCash.text = string.Format("Banlance    {0:N0}", GameManager.Instance.userData.Cash);
        Console.WriteLine(UserInfoCash);

        CashPrice.text = string.Format("현금 \n\n {0:N0}", GameManager.Instance.userData.Balance);
        Console.WriteLine(CashPrice);
    }

    public void CostomDeposits() 
    {
        // inputFeild에 입력된 문자열을 숫자로 변환
        int input = int.Parse(InputDeposit.text);
        GameManager.Instance.userData.Deposits(input);
    }

    public void CostomWithdraw() 
    {
        // inputFeild에 입력된 문자열을 숫자로 변환
        int input = int.Parse(InputWithdraw.text);
        GameManager.Instance.userData.Withdraws(input);
    }

    public void OnClickDeposit(int amount) 
    {
        GameManager.Instance.userData.Deposits(amount);
    }

    public void OnClickWithdraw(int amount) 
    {
        GameManager.Instance.userData.Withdraws(amount);
    }

    public void OnImCash() 
    {
        Deposit.SetActive(true);
        ATM.SetActive(false);
    }

    public void OnExCash() 
    {
        Withdraw.SetActive(true);
        ATM.SetActive(false);
    }

    public void OnBackBtn() 
    {
        Withdraw.SetActive(false);
        Deposit.SetActive(false);
        ZeroCashPanel.SetActive(false);
        ATM.SetActive(true);
    }

    public void OnZeroCash()
    {
        ZeroCashPanel.SetActive(true);
    }
}
