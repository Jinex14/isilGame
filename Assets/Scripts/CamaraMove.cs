using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMove : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float velocidad;
    void Start()
    {
    rb2d = GetComponent<Rigidbody2D>();
    }

void Update()
{
    rb2d.velocity = new Vector2(velocidad, rb2d.velocity.y);
}
}
