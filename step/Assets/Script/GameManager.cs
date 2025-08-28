using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UserData userData;
    public PopupBank bank;

    public static GameManager _instance
    {
        get 
        {
            if (Instance == null) 
            {
                Instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return Instance;
        }
    
    }

    private void Awake()
    {
        if (Instance == null) 
        { 
            Instance = this;
            DontDestroyOnLoad(Instance);
        }

        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // 직렬화 -> 저장 -> 불러오기 -> 역직렬화
    public void SaveUserData()
    {
        var saveData = JsonUtility.ToJson(userData);

        //저장
        File.WriteAllText(Application.persistentDataPath + "/UserData.txt", saveData);

        //저장 경로 확인
        Debug.Log(Application.persistentDataPath);

        //PlayerPrefs.SetString("UserName", userData.UserName);
        //PlayerPrefs.SetInt("Cash", userData.Cash);
        //PlayerPrefs.SetInt("Balance", userData.Balance);

        //PlayerPrefs.Save();
    }

    public void LoadUserData()
    {

        if (File.Exists(Application.persistentDataPath + "/UserData.txt"))
        {
            var loadData = File.ReadAllText(Application.persistentDataPath + "/UserData.txt");
            userData = JsonUtility.FromJson<UserData>(loadData);
        }

        else 
        {
            userData = new UserData("김영수", 50000, 100000);
        }

            //string name = PlayerPrefs.GetString("UserName", "name");
            //int cash = PlayerPrefs.GetInt("Cash", 50000);
            //int balance = PlayerPrefs.GetInt("Balance", 100000);
    }

    private void Start()
    {
        LoadUserData();
    }
}
