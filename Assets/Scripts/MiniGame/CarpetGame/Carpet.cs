using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carpet : MonoBehaviour
{
    public bool spawned_lug;
    public GameObject lugs;
    public GameObject neighbor_lug;
    public Vector3 spawn_position;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rg = collision.transform.GetComponent<Rigidbody2D>();
        rg.AddForce(Vector2.up * 800);
        if(!spawned_lug)
        {
            Destroy(neighbor_lug);
            Instantiate(lugs, transform.position + spawn_position, Quaternion.identity);
            spawned_lug = true;
        }
    }
}
