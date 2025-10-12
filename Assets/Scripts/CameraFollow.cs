using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;      // El jugador
    public float smoothSpeed = 5f; // Qué tan suave sigue
    public Vector3 offset;        // Para ajustar la posición

    private void LateUpdate()
    {
        if (target != null)
        {
            // Solo sigue en el eje X
            float targetX = target.position.x + offset.x;

            // Mantiene la altura y el z originales
            Vector3 desiredPosition = new Vector3(targetX, transform.position.y + offset.y, transform.position.z);

            // Movimiento suave
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
