using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Refferences")]
    public ChangeDirection change;
    public Rigidbody2D body;

    [Header("Movement Value")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    private void Update()
    {
        if(change.movingLeft)
            body.velocity = new Vector2(-speed, body.velocity.y);
        else if(!change.movingLeft)
            body.velocity = new Vector2(speed, body.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            FindObjectOfType<AudioManager>().Play("PlayerJump");
            Jump();
        }
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpPower);
        
    }
}
