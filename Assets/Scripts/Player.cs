using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{

    float _pitch = 0;


    public bool invertLook = false;

    [SerializeField]
    float _sensitivity = 10;

    [SerializeField]
    float forwardSpeed = 2f;

    [SerializeField]
    float strafeSpeed = 2f;

    [SerializeField]
    float backSpeed = 1f;

    [SerializeField]
    Camera _cam;

    float dt;

    float mouseX;

    Vector2 _input;

    Rigidbody _rb;

    CharacterController _controller;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        dt = Input.GetAxis("Mouse Y") * _sensitivity;

        mouseX = Input.GetAxis("Mouse X") * _sensitivity;
 
    }

    private void FixedUpdate()
    {
        transform.localRotation *= Quaternion.Euler(0, mouseX, 0);


        dt = invertLook ? dt : -dt;

        if (_pitch <= 0)
        {
            if (_pitch > -90 || dt > 0)
            {
                _cam.transform.localRotation *= Quaternion.AngleAxis(dt, Vector3.right);
                _pitch += dt;
            }
        }
        else
        {
            if (_pitch < 90 || dt < 0)
            {
                _cam.transform.localRotation *= Quaternion.AngleAxis(dt, Vector3.right);
                _pitch += dt;
            }
        }

        _controller.Move(calculateVelocity() * Time.deltaTime);
    }


    Vector3 calculateVelocity()
    {

        if (_input.y > float.Epsilon)
        {
            return forwardSpeed * transform.forward * _input.y + strafeSpeed * transform.right * _input.x;
        }
        else if (_input.y < -float.Epsilon)
        {
            return backSpeed * transform.forward * _input.y + strafeSpeed * transform.right * _input.x;
        }
        else
        {
            return strafeSpeed * transform.right * _input.x;
        }
    }
}
