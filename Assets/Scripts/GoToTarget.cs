using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTarget : MonoBehaviour
{
    [SerializeField] private float _duration;

    private Transform _target;
    private float _elapsedTime;
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position; 
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        transform.position = Vector3.Lerp(_startPosition, _target.position, _elapsedTime / _duration);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Target target))
        {
            Destroy(gameObject);
        }
    }
}
