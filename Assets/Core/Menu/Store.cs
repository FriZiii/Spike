using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Store : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coins;
    [SerializeField] TextMeshProUGUI highScore;
    private void Update()
    {
        coins.text = PlayerPrefs.GetInt("Coins").ToString();
        highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
