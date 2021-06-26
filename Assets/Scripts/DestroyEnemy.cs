using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D colider;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        colider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.tag);
        if(collision.gameObject.tag == "Bullet")
        {
            anim.SetBool("isDeath", true);
            colider.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Entro :S");
    }

    public void blockElement()
    {
        gameObject.SetActive(false);
    }
}
