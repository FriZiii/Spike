using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BuySetup : MonoBehaviour
{
    [SerializeField] private Skin skin;
    [SerializeField] private TextMeshProUGUI skinName;
    [SerializeField] private TextMeshProUGUI cost;
    [SerializeField] private Image skinSprite;

    [SerializeField] private GameObject Unbuyed;
    [SerializeField] private GameObject Selected;

    void Start()
    {
        skinName.text = skin.name;
        skinSprite.sprite = skin.sprite;

        if(skin.CoinCost != 0)
            cost.text = skin.CoinCost.ToString();

        if(skin.HighScoreCost !=0)
            cost.text = skin.HighScoreCost.ToString();
    }
    private void Update()
    {
        MarkAsUnBuyed();
        MarkAsSelected();
    }

    public void BuyByCoins()
    {
        if (skin.CoinCost <= PlayerPrefs.GetInt("Coins") && !IsBought())
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - skin.CoinCost);
            Debug.Log("Zakupiono");
            PlayerPrefs.SetInt(skin.name, 1);
        }
        else if (skin.CoinCost > PlayerPrefs.GetInt("Coins") && !IsBought())
        {
            Debug.Log("Nie wystarczaj¹ce fundusze");
        }
    }

    public void BuyByHighScore()
    {
        if(skin.HighScoreCost <= PlayerPrefs.GetInt("HighScore") && !IsBought())
        {
            PlayerPrefs.SetInt(skin.name, 1);
        }
        else if(skin.HighScoreCost <= PlayerPrefs.GetInt("HighScore") && !IsBought())
        {
            Debug.Log("Za ma³y score");
        }
    }

    public void SelectSkin()
    {
        if (IsBought())
        {
            PlayerPrefs.SetString("SkinName", skin.name);
            Debug.Log("Wybrano " + skin.name);
        }
    }

    private bool IsBought()
    {
        if(PlayerPrefs.GetInt(skin.name) == 1)
            return true; 
        else
            return false;
    }

    private void MarkAsUnBuyed()
    {
        if(skin.CoinCost == 0 && skin.HighScoreCost == 0)
            Unbuyed.SetActive(false);
        else if (PlayerPrefs.GetInt(skin.name) == 0)
            Unbuyed.SetActive(true);
        else if (PlayerPrefs.GetInt(skin.name) == 1)
            Unbuyed.SetActive(false);

    }

    private void MarkAsSelected()
    {
        if (PlayerPrefs.GetString("SkinName") == skin.name)
        {
            Selected.SetActive(true);
        }
        else
            Selected.SetActive(false);
    }
}
