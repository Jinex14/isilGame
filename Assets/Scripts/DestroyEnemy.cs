using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
