using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 dir;
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();

        dir = transform.up.normalized * 7f * rb.mass;

        Invoke(nameof(DestroyObj), 5);
    }

    private void FixedUpdate()
    {
        rb.velocity = dir * Time.deltaTime;
    }

    private void DestroyObj()
    {
        Destroy(this.gameObject);
    }
}
