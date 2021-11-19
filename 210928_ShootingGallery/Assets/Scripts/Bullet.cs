using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 10f;
    private float lifeTime = 0.65f;
    private bool isShoot = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        if (!isShoot) return;
        transform.position += (Vector3.up * speed * Time.deltaTime);
    }

    public void Shoot()
    {
        isShoot = true;
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Enemy") Destroy(gameObject);
    }
}
