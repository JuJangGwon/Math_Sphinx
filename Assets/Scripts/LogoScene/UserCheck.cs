using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using Amazon;
//using Amazon.CognitoIdentity;
//using Amazon.DynamoDBv2;
//using Amazon.DynamoDBv2.DataModel;

public class UserCheck : MonoBehaviour
{
    [Header("애니메이터")]
    public Animator anime;

    [Header("로그인 팝업")]
    public GameObject login_popup;
    public TextMeshProUGUI login_id;
    public TextMeshProUGUI login_pw;

    [Space]
    [Header("회원가입 팝업")]
    public GameObject signup_popup;
    public TextMeshProUGUI signup_id;
    public TextMeshProUGUI signup_pw;

    [Space]
    [Header("닉네임 팝업")]
    public GameObject nickname_popup;
    public TextMeshProUGUI nickname_text;

    [Space]
    [Header("알림 팝업")]
    public GameObject Information_popup;
    public TextMeshProUGUI information_title;
    public TextMeshProUGUI information_content;
    public Button btn;
    public string[] title_text;
    public string[] content_text;

    //[Space]
    //[Header("AWS")]
    //DynamoDBContext context;
    //AmazonDynamoDBClient DBclient;
    //CognitoAWSCredentials credentials;

    string user_id = "ID";
    string user_pw = "PW";

    void Awake()
    {
        test();

        if (PlayerPrefs.GetString(user_id) != null)
        {
            login_id.text = PlayerPrefs.GetString(user_id);
            if (PlayerPrefs.GetString(user_pw) != null)
            {
                login_pw.text = PlayerPrefs.GetString(user_pw);
                Log_In();
            }
        }
    }

    public void Log_In()
    {

    }

    public void Sign_Up()
    {
        //User_Info u = new User_Info(signup_id.text, signup_pw.text);

        //context.SaveAsync(u, null);
    }

    void Set_User_ID()
    {

    }

    void test()
    {
        //UnityInitializer.AttachToGameObject(this.gameObject);
        //credentials = new CognitoAWSCredentials("?????? ???? ???? ?? ID", RegionEndpoint.APNortheast2);
        //DBclient = new AmazonDynamoDBClient(credentials, RegionEndpoint.APNortheast2);
        //context = new DynamoDBContext(DBclient);
    }

    public void Open_Information_Popup(int n)
    {
        switch (n)
        {
            case 0:
                information_title.text = title_text[n];
                information_content.text = content_text[n];
                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(Close_Nickname_Complete);
                Information_popup.SetActive(true);
                break;
            case 1:
            case 2:
                information_title.text = title_text[n];
                information_content.text = content_text[n];
                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(delegate { Close_Popup(Information_popup); });
                Information_popup.SetActive(true);
                break;
            case 3:
                login_popup.SetActive(true);
                break;
            case 4:
                signup_popup.SetActive(true);
                break;
            case 5:
                nickname_popup.SetActive(true);
                break;
        }
    }

    public void Open_Sign_Up()
    {
        Close_Popup(login_popup);
        Open_Information_Popup(4);
    }

    public void Close_Sign_Up()
    {
        Close_Popup(signup_popup);
        Open_Information_Popup(3);
    }

    public void Sign_Up_Check()
    {
        Close_Popup(signup_popup);
        Open_Information_Popup(5);
    }

    public void Nickname_Check()
    {
        Close_Popup(nickname_popup);
        Open_Information_Popup(0);
    }

    public void Close_Nickname_Complete()
    {
        Close_Popup(Information_popup);
        Open_Information_Popup(3);
    }

    public void Close_Popup(GameObject pu)
    {
        pu.SetActive(false);
    }
}

class User_Info
{
    //[DynamoDBHashKey] string user_id;
    //[DynamoDBProperty] string id;
    //[DynamoDBProperty] string pw;
    //[DynamoDBProperty] string nickname;

    //public User_Info(string id, string pw)
    //{
    //    this.id = id;
    //    this.pw = pw;
    //}

    public User_Info() { }
}
