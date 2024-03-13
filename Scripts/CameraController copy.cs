using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerCopy : MonoBehaviour
{
    public Transform player;
    public float offsetAngle = 180f;
    private Vector3 offset;
    public float rotationSpeed = 55f;
    
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset; 
        //gira la cámara junto con el jugador.
        //transform.rotation = Quaternion.LookRotation(player.forward, Vector3.up) * Quaternion.Euler(0, offsetAngle, 0);
        //PRIMERA PERSONA
        //transform.position = player.transform.position;
        if (Input.GetKey(KeyCode.J))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.K))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
