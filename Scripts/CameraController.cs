using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public float rotationSpeed = 5f;
    public float distance = 5f;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        if (Input.GetKey(KeyCode.I)){
            transform.Rotate(Vector3.right,-rotationSpeed*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.K)){
            transform.Rotate(Vector3.right,rotationSpeed*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.J))
        {
            //transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
            float horizontalInput = Input.GetAxis("Horizontal");

            // Rotate the camera around the player
            transform.RotateAround(player.transform.position, Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

            // Move the camera to maintain distance from the player
            Vector3 desiredPosition = player.transform.position - transform.forward * distance;
            transform.position = desiredPosition;
        }
        if (Input.GetKey(KeyCode.L))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        } 
    }
}
