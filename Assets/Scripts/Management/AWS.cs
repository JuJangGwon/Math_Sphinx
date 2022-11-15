using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

public class AWS : MonoBehaviour
{
    [Header("AWS")]
    public DynamoDBContext context;
    public AmazonDynamoDBClient DBclient;
    public CognitoAWSCredentials credentials;
    public TEXDraw text;

    [Header("User_Info")]
    public User_Info current_user;

    static AWS aws;
    public static AWS instance
    {
        get
        {
            if (aws == null)
                aws = null;
            return aws;
        }
    }

    void Awake()
    {
        ProblemText.Setting_Dictionary(); //따로 만들기 귀찮아서 여기다가 넣음
        Initialization();
    }

    void Initialization()
    {
        if (aws == null)
        {
            aws = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(this);

        UnityInitializer.AttachToGameObject(this.gameObject);
        credentials = new CognitoAWSCredentials("ap-northeast-2:63ad9b58-0275-494b-8211-cf194cd20758", RegionEndpoint.APNortheast2);
        DBclient = new AmazonDynamoDBClient(credentials, RegionEndpoint.APNortheast2);
        context = new DynamoDBContext(DBclient);
    }

    public void Input_User(User_Info u)
    {
        current_user = u;
        print("로그인 성공");
    }
}

[DynamoDBTable("User_Info")]
public class User_Info
{
    [DynamoDBProperty] public string id { get; set; }
    [DynamoDBProperty] public string pw { get; set; }
    [DynamoDBProperty] public string nickname { get; set; }
    [DynamoDBProperty] public int money { get; set; }
    [DynamoDBProperty] public int score { get; set; }

}

public class Info_Udate
{
    TextMeshProUGUI money_text;
    TextMeshProUGUI score_text;

    public Info_Udate(TextMeshProUGUI money_text, TextMeshProUGUI score_text)
    {
        this.money_text = money_text;
        this.score_text = score_text;
    }

    public int Money
    {
        get { return AWS.instance.current_user.money; }
        set
        {
            if (AWS.instance.current_user.money != value)
            {
                money_text.text = value.ToString();
                AWS.instance.current_user.money = value;
            }
        }
    }

    public int Score
    {
        get { return AWS.instance.current_user.score; }
        set
        {
            if (AWS.instance.current_user.score != value)
            {
                score_text.text = value.ToString();
                AWS.instance.current_user.score = value;
            }
        }
    }

    //public int Ranking
    //{
    //    get { return AWS.instance.current_user.rank; }
    //    set
    //    {
    //        if (AWS.instance.current_user.score != value)
    //        {
    //            score_text.text = value.ToString();
    //            AWS.instance.current_user.score = value;
    //        }
    //    }
    //}

    //string Ranking_Udpate(User_Info u)
    //{
    //    return "-";
    //}
}