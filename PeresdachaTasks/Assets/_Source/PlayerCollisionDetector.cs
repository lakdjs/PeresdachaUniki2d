using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionDetector : MonoBehaviour
{
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private LayerMask rewardLayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((obstacleLayer & (1 << collision.gameObject.layer)) != 0)
        {
            SceneManager.LoadScene(0);
            Debug.Log("Obstacle");
        }
        if ((rewardLayer & (1 << collision.gameObject.layer)) != 0)
        {
            Debug.Log("reward");
        }
    }
}
