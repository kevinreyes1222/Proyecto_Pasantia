using UnityEngine;

public class PedestrianMov : MonoBehaviour
{
    public Transform[] destinos;
    private int destinoActual = 0;
    public float velocidad = 2f;
    public float rotacionVelocidad = 5f;

    void Update()
    {
        if (destinos.Length == 0) return;

        Transform destino = destinos[destinoActual];


        Vector3 direccion = (destino.position - transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, destino.position, velocidad * Time.deltaTime);

        if (direccion != Vector3.zero)
        {
            Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, rotacionVelocidad * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, destino.position) < 0.1f)
        {
            //destinoActual = (destinoActual + 1) % destinos.Length;
            destinoActual = Random.Range(0, destinos.Length);
        }
    }
}
