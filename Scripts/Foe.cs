using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foe : MonoBehaviour
{
    public float speed;
    public Vector3 centerOfMap = Vector3.zero;
    private Rigidbody FoeRB;
    private GameObject player;
    void Start()
    {
        //Llama al jugador y enemigo como variables.
        FoeRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //detecta las posiciones del jugador y del enemigo
        Vector3 look = (player.transform.position - transform.position).normalized;
        //le da el movimiento para ir a por ti.
        FoeRB.AddForce(look * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        //Si choca con el jugador....
        if (collision.gameObject == player)
        {
            // Mueve el jugador al centro del mapa.
            player.transform.position = centerOfMap;
        }
    }
}