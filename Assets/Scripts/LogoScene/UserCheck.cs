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
using UnityEngine.SceneManagement;

public class UserCheck : MonoBehaviour
{
    [Header("AWS")]
    public AWS aws;
    [Space]

    [Header("애니메이터")]
    public Animator anime;

    [Header("로그인 팝업")]
    public GameObject login_popup;
    public TMP_InputField login_id;
    public TMP_InputField login_pw;
    public Toggle login_pw_toggle;

    [Space]
    [Header("회원가입 팝업")]
    public GameObject signup_popup;
    public TMP_InputField signup_id;
    public TMP_InputField signup_pw;
    public Toggle signup_pw_toggle;

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
    [TextArea]public string[] content_text;

    string user_id = "ID";
    string user_pw = "PW";

    int login_on_hash = Animator.StringToHash("LoginOn");
    int login_off_hash = Animator.StringToHash("LoginOff");
    int signup_on_hash = Animator.StringToHash("SignupOn");
    int signup_off_hash = Animator.StringToHash("SignupOff");
    int nick_on_hash = Animator.StringToHash("NicknameOn");
    int nick_off_hash = Animator.StringToHash("NicknameOff");
    int info_on_hash = Animator.StringToHash("InfoOn");
    int info_off_hash = Animator.StringToHash("InfoOff");

    void Awake()
    {
        PlayerPrefs.DeleteAll();

        if (PlayerPrefs.GetString(user_id) != "")
        {
            login_id.text = PlayerPrefs.GetString(user_id);
            if (PlayerPrefs.GetString(user_pw) != "")
            {
                login_pw.text = PlayerPrefs.GetString(user_pw);
                Log_In();
            }
        }
        else
        { 
            Open_Popup(6);
        }
    }

    //테스트용
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0)) { PlayerPrefs.DeleteAll(); }
    }

    public void Input_Field_Filter(TMP_InputField ip)
    {
        ip.text = Regex.Replace(ip.text, @"[^0-9a-zA-Z]", "");
    }

    public void Log_In()
    {
        User_Info u = null;
        aws.context.LoadAsync<User_Info>(login_id.text, (AmazonDynamoDBResult<User_Info> result) =>
        {
            u = null;
            if (result.Exception != null)
            {
                Debug.LogException(result.Exception);
                return;
            }
            print(u);
            u = result.Result;
            print(u);
            print(u.id);

            if (u.id == login_id.text)
            {
                if(u.pw == login_pw.text)
                {
                    aws.Input_User(u);
                    Save_User_Info(u);
                    Close_Popup(login_popup);
                    SceneManager.LoadScene("MainHomeScene");
                }
                else { Open_Popup(3); }
            }
            else { Open_Popup(3); }
            if (u == null) { Open_Popup(3); }

        }, null);
    }

    public void Save_User_Info(User_Info u)
    {
        PlayerPrefs.SetString(user_id, u.id);
        PlayerPrefs.SetString(user_pw, u.pw);
    }

    public void Sign_Up(string ID, string PW, string Nickname)
    {
        User_Info u = new User_Info
        {
            id = ID,
            pw = PW,
            nickname = Nickname,
            money = 6000,
            score = 0
        };

        aws.context.SaveAsync(u, (result) =>
        {
            if (result.Exception == null)
                Debug.Log("Sccess!");
            else
                Debug.Log(result.Exception);
        });
    }

    bool Sign_Up_Restriction(string s, int a, int b)
    {
        if(s.Length < a || s.Length > b) { return false; }
        else { return true; }
    }

    public void Open_Popup(int n)
    {
        switch (n)
        {
            case 0:
                information_title.text = title_text[n];
                information_content.text = content_text[n];
                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(Close_Nickname_Complete);
                anime.SetTrigger(info_on_hash);
                break;
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                information_title.text = title_text[n];
                information_content.text = content_text[n];
                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(delegate { Close_Popup(Information_popup); });
                anime.SetTrigger(info_on_hash);
                break;
            case 6:
                Login_Text_Clear();
                anime.SetTrigger(login_on_hash);
                break;
            case 7:
                SignUp_Text_Clear();
                anime.SetTrigger(signup_on_hash);
                break;
            case 8:
                Nickname_Text_Clear();
                anime.SetTrigger(nick_on_hash);
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
        Open_Popup(7);
    }

    public void Close_Sign_Up()
    {
        Close_Popup(signup_popup);
        Open_Popup(5);
    }

    public void Sign_Up_Check()
    {
        if(!Sign_Up_Restriction(signup_id.text, 5, 15) || !Sign_Up_Restriction(signup_pw.text, 8, 20))
        {
            Open_Popup(4);
        }
        else
        {
            Close_Popup(signup_popup);
            Open_Popup(8);
        }
    }

    public void Nickname_Check()
    {
        if (!Sign_Up_Restriction(nickname_text.text, 2, 12))
        {
            Open_Popup(5);
        }
        else
        {
            Sign_Up(signup_id.text, signup_pw.text, nickname_text.text);
            Close_Popup(nickname_popup);
            Open_Popup(0);
        }
    }

    public void Close_Nickname_Complete()
    {
        Close_Popup(Information_popup);
        Open_Popup(6);
    }

    public void Close_Popup(GameObject pu)
    {
        if (pu == login_popup)
        {
            anime.SetTrigger(login_off_hash);
        }
        else if (pu == signup_popup)
        {
            anime.SetTrigger(signup_off_hash);
        }
        else if (pu == Information_popup)
        {
            anime.SetTrigger(info_off_hash);
        }
        else if (pu == nickname_popup)
        {
            anime.SetTrigger(nick_off_hash);
        }
    }

    public void Show_Password(Toggle t)
    {
        TMP_InputField ifd = null;
        if(t == login_pw_toggle) { ifd = login_pw; }
        else if(t == signup_pw_toggle) { ifd = signup_pw; }

        if (t.isOn) { ifd.contentType = TMP_InputField.ContentType.Standard; }
        else { ifd.contentType = TMP_InputField.ContentType.Password; }
    }
}
