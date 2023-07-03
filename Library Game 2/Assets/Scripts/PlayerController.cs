using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    private Vector3 _input;

    void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical));"));
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        _rb.MovePosition(transform.position + transform.forward * _speed * Time.deltaTime);
    }
}
