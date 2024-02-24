using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleKill : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.collider.CompareTag("Player"))
        {
            PlayerController.isDead = true;
            StartCoroutine(ExecuteAfterTime(5f));
        }
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        PlayerController.isDead = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
