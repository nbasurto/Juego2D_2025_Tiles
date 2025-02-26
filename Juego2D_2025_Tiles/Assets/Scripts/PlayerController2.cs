using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    [SerializeField] float cantidadGiro = 10f;
    [SerializeField] float velocidadBoost = 20;
    [SerializeField] float velocidadBase = 10f;
    //[SerializeField] float velocidadSurface = -5f;
    float velocidad = 10;

    Rigidbody2D rb;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Mover();
            RotarJugador();
            Acelerar();
        }
    }

    public void PararControl()
    {
        canMove = false;
    }
    void Mover()
    {
        float moverVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(moverVertical, 0f, 0f);
        rb.AddForce(movimiento * velocidad);
    }

    void Acelerar()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            velocidad = velocidadBoost;
        }
        else
        {
            velocidad = velocidadBase;
        }
    }

    void RotarJugador()
    {
        float moverHorizontal = Input.GetAxis("Horizontal");
        rb.AddTorque(-cantidadGiro * moverHorizontal);
        /*
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddTorque(cantidadGiro);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddTorque(-cantidadGiro);
        }*/
    }
}
