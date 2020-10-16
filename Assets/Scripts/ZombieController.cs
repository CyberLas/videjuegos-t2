using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private PuntajeController puntajeController;
    int seguir = 0;
    int puntaje = 0;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;
    private float  a = 0.5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(waiter());
        puntajeController = FindObjectOfType<PuntajeController>();
    }

    // Update is called once per frame
    IEnumerator waiter()
        {
            yield return new WaitForSeconds(Random.Range(5.0f, 7.0f));
            transform.localScale = new Vector3(a,a,a);
        }
    void Update()
    {
        
        rb.velocity = new Vector2(0,rb.velocity.y);

        if(seguir == 0){
            rb.velocity = new Vector2(-1, rb.velocity.y);
            sr.flipX = true;
        }else{
            rb.velocity = new Vector2(1, rb.velocity.y);
            sr.flipX = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "kunai") {
            Destroy(gameObject,0.5f);
            puntaje += 10;
            puntajeController.AddVida(puntaje);
        }
    }
}
