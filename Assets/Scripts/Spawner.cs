using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _delay;

    private Transform[] _spawners;

    private void Start()
    {
        _spawners = GetComponentsInChildren<Transform>();
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);

        for (int i = 1; i < _spawners.Length + 1; i++)
        {
            if (i == _spawners.Length)
            {
                i = 1;
            }

            Instantiate(_enemy, _spawners[i].position, Quaternion.identity);
            yield return delay;
        }
    }
}
