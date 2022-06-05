using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float force;
    [SerializeField] HighscoreManager highscoreManager;
    [SerializeField] GameObject gameOverCanvas;

    private bool hasStarted;

    private float scoreCooldown = 0.1f;
    private float lastScoreAddedTime;

    private void Start() 
    {
        hasStarted = false;
        Time.timeScale = 0;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        gameObject.transform.rotation = Quaternion.Euler(0,0,rb.velocity.y / 7);
    }

    private void Jump()
    {
        if(!hasStarted)
        {
            hasStarted = true;
            Time.timeScale = 1f;
        }
        rb.velocity = Vector2.up * force;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Time.timeScale = 0f;
        highscoreManager.GameOverHandler();
        gameOverCanvas.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(Time.time > lastScoreAddedTime)
        {
            highscoreManager.AddScorePoint();
            lastScoreAddedTime = Time.time + scoreCooldown;
        }
    }
}
