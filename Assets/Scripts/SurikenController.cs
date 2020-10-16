using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurikenController : MonoBehaviour
{
    private Rigidbody2D Kunay;
    public float kunayspeed;

    public float bulletLife;
    void Awake() 
    {
        Kunay = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Kunay.velocity = new Vector2(kunayspeed, Kunay.velocity.x);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,bulletLife);
    }
}
