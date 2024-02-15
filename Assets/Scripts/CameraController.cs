using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float speed = 1f;
    public float sensitivity = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the camera forward, backward, left, and right
        transform.position += transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position += transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        // Rotate the camera based on the mouse movement
        if (Input.GetKey(KeyCode.LeftControl))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            transform.eulerAngles += new Vector3(-mouseY * sensitivity, mouseX * sensitivity, 0);
        }
    }
}
