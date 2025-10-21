using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMovement : MonoBehaviour
{
    [Header("Prefabs y velocidad")]
    public GameObject BulletPrefab;
    public float Speed = 5f;
    public float JumpForce = 300f;

    private Rigidbody2D rb;
    private Animator animator;
    private float horizontal;
    private bool grounded;

    private float LastShoot;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Movimiento horizontal
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal < 0.0f)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (horizontal > 0.0f)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        animator.SetBool("running", horizontal != 0.0f);

        // Raycast para saber si está en el suelo
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        grounded = Physics2D.Raycast(transform.position, Vector3.down, 0.1f);

        // Saltar si está en el suelo
        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            Jump();
        }

        // Disparar si presiona espacio
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * JumpForce);
    }

    private void Shoot()
    {
        // Determinar dirección del disparo
        Vector2 direction = (transform.localScale.x == 1.0f) ? Vector2.right : Vector2.left;

        // Instanciar la bala
        GameObject bullet = Instantiate(BulletPrefab, transform.position + (Vector3)(direction * 0.3f), Quaternion.identity);

        // Asignar dirección a la bala
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * Speed, rb.linearVelocity.y);
    }
}
