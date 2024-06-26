using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    private bool levelCompleted = false;
    void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Player" && !levelCompleted) 
        {
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel",2f);
        }
    }
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
