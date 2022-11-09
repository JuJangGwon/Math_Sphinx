using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD

public class AWS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
=======
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

    [Header("User_Info")]
    public User_Info current_user;

    // Start is called before the first frame update
    void Awake()
    {
        UnityInitializer.AttachToGameObject(this.gameObject);
        credentials = new CognitoAWSCredentials("ap-northeast-2:63ad9b58-0275-494b-8211-cf194cd20758", RegionEndpoint.APNortheast2);
        DBclient = new AmazonDynamoDBClient(credentials, RegionEndpoint.APNortheast2);
        context = new DynamoDBContext(DBclient);
    }

    public void Input_User(User_Info u)
    {
        current_user = u;
        print("로그인 성공");
>>>>>>> DynamoDB
    }
}
