using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float velocidadBase = 10;
    [SerializeField] float velocidadCorrer = 20;
    [SerializeField] float cantidadGiro = 10f;
    [SerializeField] float fuerzaSalto = 10;
    float velocidad;
    Rigidbody2D rb;
    CapsuleCollider2D pies;
    public bool tocaSuelo = false;
    SurfaceEffector2D surfaceEffector2D;
    public bool puedeMover;
    Animator anim;

    //Disparos
    bool miroDerecha = true;
    [SerializeField] GameObject flecha;
    [SerializeField] GameObject arco;
    [SerializeField] GameObject arcoFlecha;
    float tiempoEntreDisparos = 1;
    float siguienteDisparo = 0;

    void Start()
    {
        puedeMover = true;
        anim = GetComponent<Animator>();
        velocidad = velocidadBase;
        rb = GetComponent<Rigidbody2D>();
        pies = GetComponent<CapsuleCollider2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void FixedUpdate()
    {
        if (puedeMover)
        {
            Acelerar();
            Mover();
            //RotarJugador();
        }
    }
    void Update()
    {
        if (!puedeMover) { return; }
        ComprueboSuelo();
        Saltar();
        VolteaSprite();
        if (Input.GetButtonDown("Fire1") && Time.time >= siguienteDisparo)
        {
            StartCoroutine(Disparar());
        }
    }

    private void ComprueboSuelo()
    {
        if (pies.IsTouchingLayers(LayerMask.GetMask("Plataforma")))
        {
            tocaSuelo = true;
            velocidad = velocidadBase;
            anim.SetBool("estaSuelo", true);
        }
        else
        {
            tocaSuelo = false;
            velocidad = velocidadBase / 3;
            anim.SetBool("estaSuelo", false);
        }
    }

    private void Saltar()
    {
        anim.SetFloat("VelocidadVertical", rb.velocity.y);
        if (Input.GetButtonDown("Jump") && tocaSuelo)
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            anim.SetBool("estaSaltando", true);
            //Debug.Log("Esto en down: " + rb.velocity.y);
            anim.SetFloat("VelocidadVertical", rb.velocity.y);  
        }
        if (Input.GetButtonUp("Jump"))
        {
            anim.SetFloat("VelocidadVertical", rb.velocity.y);
            //Debug.Log("Esto en up: " + rb.velocity.y);   
            anim.SetBool("estaSaltando", false);
        }
    }

    public void PararControl()
    {
        puedeMover = false;
    }

    /*  private void RotarJugador()
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
          }
      }*/
    private void VolteaSprite()
    {
        bool seMueve = Mathf.Abs(rb.velocity.x) > 0f;
        if(seMueve)
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        if (Mathf.Sign(rb.velocity.x) == 1)
            miroDerecha = true;
        else
            miroDerecha = false;
    }

    void Acelerar()
    {
        if (Input.GetKey(KeyCode.LeftControl))
            velocidad = velocidadCorrer;
        else
            velocidad = velocidadBase;

        //surfaceEffector2D.speed = velocidad;
    }
    private void Mover()
    {
        float mover = Input.GetAxis("Horizontal");
        if (mover != 0f)
            anim.SetBool("estaMoviendo", true);
        else
            anim.SetBool("estaMoviendo", false);

        //Sirface effector solo funciona con fuerzas.
        //Vector2 movimiento = new Vector2(mover, 0);
        //rb.AddForce(movimiento * velocidadBase);
       // Debug.Log(mover);
        Vector3 movimiento = new Vector3(mover * velocidad, rb.velocity.y, 0);
        rb.velocity = movimiento;
    }
    public void Morir()
    {
        if (puedeMover)
        {
            puedeMover = false;
            anim.SetTrigger("Muriendo");
            rb.velocity = new Vector2(10f, 50f);
            FindObjectOfType<GameManager>().MuerteJugador();
        }
    }

    IEnumerator Disparar()
    {
        float anguloDisparo = miroDerecha ? -45f : 130f;

        Quaternion rotacion = Quaternion.Euler(0, 0, anguloDisparo);
        Instantiate(flecha, arco.transform.position, rotacion);

        arcoFlecha.SetActive(false);
        arco.SetActive(true);

        siguienteDisparo = Time.time + tiempoEntreDisparos;

        yield return new WaitForSeconds(tiempoEntreDisparos);

        arcoFlecha.SetActive(true);
        arco.SetActive(false);

    }
}
