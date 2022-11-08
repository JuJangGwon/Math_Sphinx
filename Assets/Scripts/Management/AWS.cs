using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    // Start is called before the first frame update
    void Awake()
    {
        UnityInitializer.AttachToGameObject(this.gameObject);
        credentials = new CognitoAWSCredentials("ap-northeast-2:63ad9b58-0275-494b-8211-cf194cd20758", RegionEndpoint.APNortheast2);
        DBclient = new AmazonDynamoDBClient(credentials, RegionEndpoint.APNortheast2);
        context = new DynamoDBContext(DBclient);
    }
}
