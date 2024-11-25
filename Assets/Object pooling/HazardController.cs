using UnityEngine;

public class HazardController : MonoBehaviour
{
    [SerializeField] private GameObject hazardPrefab;
    [SerializeField] private float cooldown = 1f;
    [SerializeField] private Camera mainCamera;
    
    private Pooler _pooler;
    private float _timeSinceLastSpawn;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _pooler = new Pooler(hazardPrefab, 10);
    }

    // Update is called once per frame
    void Update()
    {
        _timeSinceLastSpawn += Time.deltaTime;
        
        if (_timeSinceLastSpawn >= cooldown)
        {
            _timeSinceLastSpawn = 0;
            
            var hazard = _pooler.GetPooledObject();
            
            Vector3 spawnPosition = mainCamera.ViewportToWorldPoint(new Vector3(Random.value, 1, mainCamera.nearClipPlane));
            spawnPosition.z = 0; // Ensure the z value is within the camera's view
            hazard.transform.position = spawnPosition;
            hazard.SetActive(true);
        }
    }
}
