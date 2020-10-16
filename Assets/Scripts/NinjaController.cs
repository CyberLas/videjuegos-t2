using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    private PuntajeController puntajeController;


    public Transform KunaiSpawner;
    public GameObject  KunaiPrefab;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;

    NinjaController controller;

    public BoxCollider2D plataforma;

    [HideInInspector]
    public bool onLadder = false;
    
    public float climbSpeed;
    public float exitHop = 3f;

    private int muerte = 0;
    private int vida = 3;
    private int a=0;

    
private float movementSpeed = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        controller = GetComponent<NinjaController>();
        puntajeController = FindObjectOfType<PuntajeController>();
    }

    // Update is called once per frame
    void Update()
    {
        int planear = 0;
        //get the Input from Horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");
        //get the Input from Vertical axis
        float verticalInput = Input.GetAxis("Vertical");

        //update the position
        transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, verticalInput * movementSpeed * Time.deltaTime, 0);

        //output to log the position change
        Debug.Log(transform.position);
        rb.velocity = new Vector2(0,rb.velocity.y);

        animator.SetInteger("run", 0);
        animator.SetInteger("slide", 0);
        animator.SetInteger("escale", 0);
        animator.SetInteger("planning", 0);
        animator.SetInteger("attack", 0);
        animator.SetInteger("jump", 0);

        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if(muerte == 0)
            {
                rb.velocity = new Vector2(10, rb.velocity.y);
                sr.flipX = false;
                animator.SetInteger("run", 1);
            }
        }

        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if(muerte == 0)
            {
                rb.velocity = new Vector2(-10, rb.velocity.y);
                sr.flipX = true;
                animator.SetInteger("run", 1);
            }
        }
        
        if(Input.GetKey(KeyCode.Z))
        {
            if(muerte == 0)
            {
                animator.SetInteger("attack", 1);
                Instantiate(KunaiPrefab, KunaiSpawner.position, KunaiSpawner.rotation);
            }
        }

        if(Input.GetKey(KeyCode.Space))
        {
            if(muerte == 0)
            {
                animator.SetInteger("planning", 1);
                planear = 1;
            }
            if(transform.position.y >= 10.0 && planear == 0)
            {
                animator.SetInteger("dead", 1);
                a = 0;
            }
        }
        
        if(Input.GetKey(KeyCode.S))
        {
            if(muerte == 0)
            {
                animator.SetInteger("slide", 1);
            }
        }

        if(Input.GetKey(KeyCode.X))
        {
            if(muerte == 0)
            {
                animator.SetInteger("escale", 1);
            }
        }

        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if(muerte == 0)
            {
                rb.AddForce(new Vector2(0, 1), ForceMode2D.Impulse);
                if( a == 0){
                    animator.SetInteger("jump", 1);
                    rb.gravityScale = 1;
                    rb.mass=10;
                }else{
                    animator.SetInteger("escale", 1);
                    rb.AddForce(new Vector2(0, 4), ForceMode2D.Impulse);
                    rb.gravityScale = 2;
                    rb.mass=10;
                }
            }
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if((other.gameObject.tag == "zombie") && vida < 0) {
            animator.SetInteger("dead", 1);
            muerte = 1;
        }else{
            puntajeController.AddVida(vida--);
            vida--;
        }
        
        if((other.gameObject.tag == "escalera")) {
            a = 1;
        }else{
            a = 0;
        }
    }

}
