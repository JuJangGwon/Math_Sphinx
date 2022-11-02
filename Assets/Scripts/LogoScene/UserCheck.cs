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
    [Header("·Î±×ÀÎ ÆË¾÷")]
    public GameObject login_popup;
    public TextMeshProUGUI login_id;
    public TextMeshProUGUI login_pw;

    [Space]
    [Header("È¸¿ø°¡ÀÔ ÆË¾÷")]
    public GameObject signup_popup;
    public TextMeshProUGUI signup_id;
    public TextMeshProUGUI signup_pw;

    [Space]
    [Header("´Ð³×ÀÓ ÆË¾÷")]
    public GameObject nickname_popup;
    public TextMeshProUGUI nickname_text;

    [Space]
    [Header("¾Ë¸² ÆË¾÷")]
    public GameObject Information_popup;
    public TextMeshProUGUI information_title;
    public TextMeshProUGUI information_content;
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

    public void Open_Popup(GameObject pu, int n)
    {
        switch (n)
        {
            case 0:
            case 1:
            case 2:
                information_title.text = title_text[n];
                break;
            default:
                break;
        }

        pu.SetActive(true);
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
