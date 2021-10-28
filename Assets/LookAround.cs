using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LookAround : MonoBehaviour
{
    Vector2 rotation = Vector2.zero;
    public  Rigidbody rb;
    public CharacterController characterController;
    


    public float speed = 1f;
    public float thrust = 100f;
    public float upDown = 10f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");

        transform.eulerAngles = (Vector2)rotation * speed;

        Movement();

       

    }


    private void Movement()
    {

        float horizontalMove = Input.GetAxis("Horizontal");
        Vector3 move = transform.right * horizontalMove * 15;
        characterController.Move(speed * Time.deltaTime * move);

        if (Input.GetKey("w"))
        {
            float forwardMove = Input.GetAxis("Vertical");
            Vector3 forward = transform.forward * forwardMove * 15;
            characterController.Move(speed * Time.deltaTime * forward);
        }
       
        if (Input.GetKey("space"))
        {
            float up = 1;
            Vector3 upMove = transform.up * up * 15;
            characterController.Move(speed * Time.deltaTime * upMove);
        }

        if (Input.GetKey("s"))
        {
            float back = 1;
            Vector3 backMove = transform.forward * -1 * back * 15;
            characterController.Move(speed * Time.deltaTime * backMove);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            float down = 1;
            Vector3 downMove = transform.up * -1 * down * 15;
            characterController.Move(speed * Time.deltaTime * downMove);
        }
    }
}


