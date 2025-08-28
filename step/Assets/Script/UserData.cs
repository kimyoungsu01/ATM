
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class UserData
{
    public string UserName;
    public int Cash;  
    public int Balance;

    public UserData(string name, int cash, int balance) // 생성자란? 형식: 반환타입x, 클래스랑 이름이 똑같다, 매개변수는 있어도 되고 없어도 된다, 생성자의 맴버변수가 매개변수로 사용가능  
    {
        UserName = name;
        Cash = cash; // 소지 금액
        Balance = balance; // 은행 잔액
    }

    public void Deposits(int amount) // 입금
    {
        if (Cash >= amount)
        {
            Cash -= amount;
            Balance += amount;
            GameManager.Instance.bank.Refresh();
            GameManager.Instance.SaveUserData();
        }
        else
        {
            GameManager.Instance.bank.OnZeroCash();
        }
    }

    public void Withdraws(int amount) // 출금
    {
        if (Balance >= amount)
        {
            Cash += amount;
            Balance -= amount;
            GameManager.Instance.bank.Refresh();
            GameManager.Instance.SaveUserData();
        }

        else
        {
            GameManager.Instance.bank.OnZeroCash();
        }
    }
}
