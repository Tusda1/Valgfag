using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 10;

    private void OnEnable()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * projectileSpeed;
    }

    // If the projectile is outside the camera bounds, disable
    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hazard"))
        {
            other.GetComponent<Hazard>().Hit();
            gameObject.SetActive(false);
        }
    }
    
}
