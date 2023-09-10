using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GoToTarget _enemy;
    [SerializeField] private int _delay;
    [SerializeField] private Transform _target;
    
    private GoToTarget _spawnedObject;
    private float _elapsedTime;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _delay)
        {
            _spawnedObject = Instantiate(_enemy, transform.position, Quaternion.identity);
            _spawnedObject.SetTarget(_target);
            _elapsedTime = 0;
        }
    }

    private IEnumerator CopyObjects()
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);
        while (true)
        {
            _spawnedObject = Instantiate(_enemy, transform.position, Quaternion.identity);
            _spawnedObject.SetTarget(_target);

            yield return delay;
        }
    }
}
