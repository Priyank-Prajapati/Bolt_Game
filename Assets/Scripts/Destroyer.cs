using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroyer : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    { 
        Destroy(other.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
