using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int lives = 3;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float moveSpeed = 5;
    
    private Pooler _pooler;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _pooler = new Pooler(projectilePrefab, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Move(Vector3.up);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(Vector3.down);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            var projectile = _pooler.GetPooledObject();
            projectile.transform.position = transform.position;
            projectile.SetActive(true);
        }
    }
    
    private void Move(Vector3 direction)
    {
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    public void Hit()
    {
        lives--;
        
        if (lives <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
