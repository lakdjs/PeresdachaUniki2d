using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private LayerMask finishLayer;
    public event Action OnAddScore;

    void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.position + -transform.right, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((finishLayer & (1 << collision.gameObject.layer)) != 0)
        {
            Spawn();
        }
    }
    private void Spawn()
    {
        Debug.Log("Spawn");
        transform.position = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)].position;
        OnAddScore.Invoke();
    }
}
