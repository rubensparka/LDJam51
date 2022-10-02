using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Bullet_Copy : MonoBehaviour
{
    Vector3 dir;
    public float speed;
    public float playerY;
    float deathTimer = 2f;

    void Start()
    {
        AddNonTriggerBoxCollider();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log(hit.point);
            dir = hit.point - transform.position;
            dir.y = 0;
        }
        transform.Rotate(90, 0, Mathf.Rad2Deg * Mathf.Atan2(dir.z, dir.x) + 90);
        
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

    private void AddNonTriggerBoxCollider()
    {
        Collider hitBox = gameObject.AddComponent<BoxCollider>();
        hitBox.isTrigger = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                print("HIT PLAYER MESH");
                break;

            case "Enemy":
                Destroy(gameObject);
                break;

            default:
                // do nothing
                break;
        }
    }


}