using UnityEngine;

public class OnClick : MonoBehaviour
{
    void Update()
    {
        if(GameOver.GameIsPaused == true && Input.GetMouseButtonDown(0))
        {
            FindObjectOfType<AudioManager>().Play("OnClick");
        }
    }
}
