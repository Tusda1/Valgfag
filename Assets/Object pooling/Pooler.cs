using System.Collections.Generic;
using UnityEngine;

public class Pooler
{
    private List<GameObject> _pooledObjects;
    private GameObject _objectToPool;
    
    public Pooler(GameObject objectToPool, int poolSize)
    {
        _objectToPool = objectToPool;
        _pooledObjects = new List<GameObject>();
        
        for (int i = 0; i < poolSize; i++)
        {
            var pooledObject = Object.Instantiate(_objectToPool);
            pooledObject.SetActive(false);
            _pooledObjects.Add(pooledObject);
        }
    }
    
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            if (!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }
        
        var pooledObject = Object.Instantiate(_objectToPool);
        pooledObject.SetActive(false);
        _pooledObjects.Add(pooledObject);
        Debug.Log("Created new object." + pooledObject.name);
        
        return pooledObject;
    }
}
