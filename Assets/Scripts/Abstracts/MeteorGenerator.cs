using System.Collections.Generic;
using UnityEngine;

public abstract class MeteorGenerator
{
    Queue<GameObject> _meteorPool;
    GameObject _meteor;

    float _poolSize = 10f;

    // Create constructor method
    public MeteorGenerator(GameObject meteor)
    {
        _meteor = meteor;

        _meteorPool = new Queue<GameObject>();

        for (int i = 0; i < _poolSize; i++) // Object Pooling
        {
            GameObject meteorClone = GameObject.Instantiate(_meteor);

            meteorClone.SetActive(false);
            _meteorPool.Enqueue(meteorClone);
        }
    }


    public GameObject TakeMeteor()
    {
        GameObject meteorClone = _meteorPool.Dequeue();

        meteorClone.SetActive(true);
        _meteorPool.Enqueue(meteorClone);

        return meteorClone;
    }
}
