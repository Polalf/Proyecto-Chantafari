using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 10;
    private Rigidbody rb;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 100f;
    private bool canJump;
    [SerializeField] private float distRayToGround = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (canJump)
            {
                rb.AddForce(transform.up * jumpForce);
            }
        }
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        rb.position += new Vector3(x, 0, z).normalized * speed * Time.fixedDeltaTime;

        #region Raycast
        Ray ray = new Ray(transform.position, -transform.up);
        canJump = Physics.Raycast(ray, distRayToGround);
        Debug.DrawRay(transform.position, -transform.up*distRayToGround, Color.red);
        #endregion 
    }

}
