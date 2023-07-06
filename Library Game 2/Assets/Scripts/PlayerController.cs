using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnspeed = 360;
    [SerializeField] private GameObject mouseTarget;


    [SerializeField] private float timeBetweenAttacks;

    public float health;

    public GameObject firePoint;

    private bool alreadyAttacked;

    private Vector3 _input;

    public GameObject projectile;

    private bool rotateAfterFire;

    // private bool 

    void Update()
    {
        GatherInput();
        

    }

    void GatherInput()
    {
        // _input is a vector determined bt WASD with zero for the y axis
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    void FixedUpdate()
    {
        Shoot();
        Move();
        Look();

    }

    void Look()
    {
        if (_input != Vector3.zero && !Input.GetKey(KeyCode.Mouse0))
        {
            rotateAfterFire = false;

            var relative = transform.position + _input.ToIso() - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            //if (!rotateAfterFire)
            //    {
            //        // Ensures turning is a smooth process 
            //        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnspeed * Time.deltaTime)
            //    }
            //else
            //    {
            //        transform.LookAt(GameObject)
            //    }
            //    // Ensures turning is a smooth process 
            //    transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnspeed * Time.deltaTime);

            // Ensures turning is a smooth process
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnspeed * Time.deltaTime);

        }

    }
    void Move()
    {   // To prevent moving when firing bug
        if (!Input.GetKey(KeyCode.Mouse0))
        {
            // _input.magnitude gives the length of the vector,
            // TODO character travels twice as fast in combined direction 
            _rb.MovePosition(transform.position + (transform.forward * _input.normalized.magnitude) * _speed * Time.deltaTime);
        }

    }
    
    void Shoot()
    {
        if (Input.GetKey(KeyCode.Mouse0) && !alreadyAttacked)
        {
            transform.LookAt(GameObject.Find("MouseTarget").transform);
            Rigidbody rb = Instantiate(projectile, firePoint.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);


            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks * Time.deltaTime);
            rotateAfterFire = true;
        }

    }
    void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void CheckHit()
    {

    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyPlayer), 0.5f);
    }
    private void DestroyPlayer()
    {
        Destroy(gameObject);
    }
}