using System;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.down * speed;
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    public void Hit()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().Hit();
            Hit();
        }
    }
}
