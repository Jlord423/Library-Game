using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnspeed = 360;
    private Vector3 _input;

    void Update()
    {
        GatherInput();
        Look();
    }

    void GatherInput()
    {
        // _input is a vector determined bt WASD with zero for the y axis
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    void FixedUpdate()
    {
        Move();
    }

    void Look()
    {
        if (_input != Vector3.zero)
        {
         

            var relative = (transform.position + _input.ToIso()) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            // Ensures turning is a smooth process 
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnspeed * Time.deltaTime);
        }
     
    }
    void Move()
    {
        // _input.magnitude gives the length of the vector,
        // TODO character travels twice as fast in combined direction 
        _rb.MovePosition(transform.position + (transform.forward * _input.normalized.magnitude) * _speed * Time.deltaTime);
    }
}
