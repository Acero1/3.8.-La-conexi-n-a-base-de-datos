using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed = 5f; // Velocidad ajustable desde el inspector
    private Rigidbody2D rb;
    private Vector2 Direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = Direction * Speed; // ✅ propiedad correcta
    }

    // Método para establecer la dirección desde otro script
    public void SetDirection(Vector2 direction)
    {
        Direction = direction.normalized; // 🔹 Normalizamos para evitar que afecte la velocidad
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
