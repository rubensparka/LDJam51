using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class scr_PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb;
    public GameObject bullet;
    public float ShootCD;
    public float BulletSpeed;
    Animator animator;

    Vector3 movement;
    Vector3 movDir;
    float shootTimer;

    float angle;
    private void Start()
    {
        animator = GetComponentInChildren(typeof(Animator)) as Animator;
        shootTimer = ShootCD;
    }
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        movement.y = 0;

        movDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        shootTimer -= Time.deltaTime;
        if (Input.GetButton("Fire1") && shootTimer <= 0f)
        {
            GameObject thisBullet = Instantiate(bullet, transform.GetChild(0).position, Quaternion.identity);
            thisBullet.GetComponent<scr_Bullet>().speed = BulletSpeed;
            thisBullet.GetComponent<scr_Bullet>().playerY = transform.GetChild(0).position.y;
            shootTimer = ShootCD;
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        if (movDir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movDir);
        }

        transform.Find("Shooty").rotation = Quaternion.identity;
    }
}
