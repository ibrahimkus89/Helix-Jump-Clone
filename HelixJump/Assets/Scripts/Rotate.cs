using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 150f;

    void Start()
    {
      
        //Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            transform.Rotate(0,-mouseX *rotationSpeed*Time.deltaTime,0);
        }
    }
}
