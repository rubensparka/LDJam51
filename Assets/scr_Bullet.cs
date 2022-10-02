using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Bullet : MonoBehaviour
{
    Vector3 dir;
    public float speed;
    public float playerY;
    float deathTimer = 2f;

    void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log(hit.point);
            dir = hit.point - transform.position;
            dir.y = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(dir);
        transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);
        deathTimer -= Time.deltaTime;
        if (deathTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }
}