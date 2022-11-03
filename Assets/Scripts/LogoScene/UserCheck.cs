using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using System.Text.RegularExpressions;

public class UserCheck : MonoBehaviour
{
    [Header("애니메이터")]
    public Animator anime;

    [Header("로그인 팝업")]
    public GameObject login_popup;
    public TMP_InputField login_id;
    public TMP_InputField login_pw;

    [Space]
    [Header("회원가입 팝업")]
    public GameObject signup_popup;
    public TMP_InputField signup_id;
    public TMP_InputField signup_pw;

    [Space]
    [Header("닉네임 팝업")]
    public GameObject nickname_popup;
    public TMP_InputField nickname_text;

    [Space]
    [Header("알림 팝업")]
    public GameObject Information_popup;
    public TextMeshProUGUI information_title;
    public TextMeshProUGUI information_content;
    public Button btn;
    public string[] title_text;
    public string[] content_text;

    [Space]
    [Header("AWS")]
    DynamoDBContext context;
    AmazonDynamoDBClient DBclient;
    CognitoAWSCredentials credentials;

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
            }
        }
        else { }
    }

    public void Input_Field_Filter(TMP_InputField ip)
    {
        ip.text = Regex.Replace(ip.text, @"[^0-9a-zA-Z]", "");
    }

    public void Log_In()
    {
        User_Info u;
        context.LoadAsync<User_Info>(login_id.text, (AmazonDynamoDBResult<User_Info> result) =>
        {
            if (result.Exception != null)
            {
                Debug.LogException(result.Exception);
                return;
            }
            u = result.Result;
            print(u.id);
            //else
            //    Open_Information_Popup(0);
        }, null);
    }

    public void Sign_Up(string ID, string PW, string Nickname)
    {
        User_Info u = new User_Info
        {
            id = ID,
            pw = PW,
            nickname = Nickname
        };

        context.SaveAsync(u, (result) =>
        {
            if (result.Exception == null)
                Debug.Log("Sccess!");
            else
                Debug.Log(result.Exception);
        });
    }

    void Set_User_ID()
    {

    }

    void test()
    {
        UnityInitializer.AttachToGameObject(this.gameObject);
        credentials = new CognitoAWSCredentials("ap-northeast-2:63ad9b58-0275-494b-8211-cf194cd20758", RegionEndpoint.APNortheast2);
        DBclient = new AmazonDynamoDBClient(credentials, RegionEndpoint.APNortheast2);
        context = new DynamoDBContext(DBclient);
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
                Login_Text_Clear();
                login_popup.SetActive(true);
                break;
            case 4:
                SignUp_Text_Clear();
                signup_popup.SetActive(true);
                break;
            case 5:
                Nickname_Text_Clear();
                nickname_popup.SetActive(true);
                break;
        }
    }

    void Login_Text_Clear()
    {
        login_id.text = "";
        login_pw.text = "";
    }

    void SignUp_Text_Clear()
    {
        signup_id.text = "";
        signup_pw.text = "";
    }

    void Nickname_Text_Clear()
    {
        nickname_text.text = "";
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
        Sign_Up(signup_id.text, signup_pw.text,nickname_text.text);
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

[DynamoDBTable("User_Info")]
class User_Info
{
    [DynamoDBProperty] public string id { get; set; }
    [DynamoDBProperty] public string pw { get; set; }
    [DynamoDBProperty] public string nickname { get; set; }
}
