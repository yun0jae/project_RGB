using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sensitivity = 2f;

    private Vector2 rotation = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotation += new Vector2(mouseX, mouseY);
        rotation.y = Mathf.Clamp(rotation.y, -90f, 90f); // Limit vertical rotation

        transform.localRotation = Quaternion.Euler(-rotation.y, rotation.x, 0f);
    }
}
