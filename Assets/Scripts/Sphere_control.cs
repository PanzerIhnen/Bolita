using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sphere_control : MonoBehaviour
{
    public float Thurst;
    public float JumpThurst;
    public LayerMask GroundLayer;
    public GameManager GameControl;

    private float _horizontal;
    private float _vertical;
    private bool _jump = false;
    private float _rayLenght = 0.6f;
    private bool _inGround = false;

    private Ray _groundRay;
    private RaycastHit _groundRayHit;

    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _inGround = IsTouchingGround();
        PlayerInputs();
    }

    void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerInputs()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        if (Input.GetMouseButtonDown(0) && _inGround)
        {
            _jump = true;
        }
    }

    void PlayerMovement()
    {
        Vector3 movementV = new Vector3(_horizontal, 0, _vertical);
        movementV.Normalize();
        _rb.AddForce(movementV * Thurst);

        if (_jump)
        {
            Jump();
        }
    }

    void Jump()
    {
        _rb.AddForce(Vector3.up * JumpThurst);
        _jump = false;
    }

    bool IsTouchingGround()
    {
        _groundRay.direction = Vector3.down;
        _groundRay.origin = transform.position;

        //Debug.DrawRay(_groundRay.origin, _groundRay.direction * _rayLenght, Color.red);
        if (Physics.Raycast(_groundRay, out _groundRayHit, _rayLenght, GroundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Diamond"))
        {
            Destroy(collision.gameObject);
            GameControl.AddDiamond();
        }

        if (collision.CompareTag("Death"))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
