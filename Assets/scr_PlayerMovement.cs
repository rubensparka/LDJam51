using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class scr_PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb;
    Animator animator;

    Vector3 movement;
    Vector2 mouseWorldPosition;

    float angle;
    private void Start()
    {
        animator = GetComponentInChildren(typeof(Animator)) as Animator;
    }
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        movement.y = 0;

        Vector3 pos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos.y = transform.position.y;
        Vector3 dir = transform.position - pos;
        float angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
}
