using UnityEngine;

public class NPCPatrol : MonoBehaviour
{
    public Transform[] puntos; // puntos de patrulla
    public float velocidad = 2f;
    private int indiceActual = 0;

    void Update()
    {
        if (puntos.Length == 0) return;

        // Mover hacia el punto actual
        Transform objetivo = puntos[indiceActual];
        transform.position = Vector3.MoveTowards(transform.position, objetivo.position, velocidad * Time.deltaTime);

        // Si llega al punto, cambiar al siguiente
        if (Vector3.Distance(transform.position, objetivo.position) < 0.1f)
        {
            indiceActual = (indiceActual + 1) % puntos.Length;
        }

        // Opcional: girar al mirar al siguiente punto
        Vector3 direccion = (objetivo.position - transform.position).normalized;
        if (direccion != Vector3.zero)
        {
            Quaternion rotacion = Quaternion.LookRotation(direccion);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, Time.deltaTime * 5f);
        }
    }
}
