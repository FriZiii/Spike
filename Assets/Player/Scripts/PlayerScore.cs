using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerScore : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI score;
    private int scoreValue = 0;

    private void Update()
    {
        score.text = scoreValue.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
            scoreValue++;
        }
    }

    public int GetScore()
    {
        return scoreValue;
    }
}
