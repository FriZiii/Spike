using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChangeDirection : MonoBehaviour
{
    public bool movingLeft { get; private set; }
    private bool actualDir;
    private bool lastDir;
    private void Awake()
    {
        movingLeft = RandomBool();
        actualDir = movingLeft;
        lastDir = actualDir;
    }

    private void Update()
    {
        actualDir = movingLeft;
    }

    public bool ChangeDir()
    {
        if (actualDir != lastDir)
        {
            lastDir = actualDir;
            return true;
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
            FindObjectOfType<AudioManager>().Play("PlayerChangeDirection");
            movingLeft = !movingLeft;
        }
    }

    private bool RandomBool()
    {
        return Random.value > 0.5f;
    }
}
