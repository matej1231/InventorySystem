using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _moveDirection;
    private float _speed = 3f;

    public Animator Animator;

    private void Awake()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _moveDirection.x = Input.GetAxis("Horizontal");
        _moveDirection.y = Input.GetAxis("Vertical");

        Animator.SetFloat("Horizontal", _moveDirection.x);
        Animator.SetFloat("Vertical", _moveDirection.y);
        Animator.SetFloat("Speed", _moveDirection.sqrMagnitude);
    }

    private void FixedUpdate()
    {        
        _rigidbody2D.MovePosition(_rigidbody2D.position + _speed * Time.fixedDeltaTime * _moveDirection);
    }
}
