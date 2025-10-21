using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject John;

    void Update()
    {
        // Obtenemos la posición actual de la cámara
        Vector3 position = transform.position;

        // Igualamos la posición X con la del jugador (John)
        position.x = John.transform.position.x;

        // Actualizamos la posición de la cámara
        transform.position = position;
    }
}
