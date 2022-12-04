using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerDeath : MonoBehaviour
{
    [Header("Disable Player Movement")]
    [SerializeField] PlayerMovement playerMovement;

    [Header("Change Player Color")]
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Color color;

    [SerializeField] PlayerScore score;

    private bool PlayerIsDead = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Spike")
        {
            FindObjectOfType<AudioManager>().Play("PlayerDie");
            PlayerIsDead = true;
            playerMovement.enabled = false;
            sprite.color = color;


            if (score.GetScore() > PlayerPrefs.GetInt("HighScore"))
                FindObjectOfType<AudioManager>().Play("HighScore");
        }
    }

    public bool isPlayerDead()
    {
        return PlayerIsDead;
    }
}
