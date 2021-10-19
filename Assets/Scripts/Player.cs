using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    private Animation thisAnimation;
    public float velocity = 1;
    private Rigidbody rb;

    public int ScoreCounter;
    public Text ScoreText;


    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * velocity;
            thisAnimation.Play();
        }

        if (transform.position.y <= -3.7 || transform.position.y >= 3.7)
        {
            SceneManager.LoadScene("GameOver_Scene");
        }
    }

    private void OnCollisionEnter(Collision obstacle)
    {
        if (obstacle.gameObject.tag.Equals("Obstacle"))
        {
            SceneManager.LoadScene("GameOver_Scene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Score")
        {
            ScoreCounter += 1;
            ScoreText.text = "SCORE: " + ScoreCounter;
        }
    }
}
