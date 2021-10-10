using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public float keyboard_sensitivity = 1.0f;
    public float mouse_sensitivity = 10.0f;

    private float xrot = 0.0f;
    private float yrot = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * keyboard_sensitivity * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * keyboard_sensitivity * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * keyboard_sensitivity * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * keyboard_sensitivity * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            xrot -= Input.GetAxis("Mouse Y") * mouse_sensitivity;
            yrot += Input.GetAxis("Mouse X") * mouse_sensitivity;
            transform.localRotation = Quaternion.Euler(xrot, yrot, 0.0f);
        }
    }
}
