using UnityEngine;

public class SelectSkin : MonoBehaviour
{
    [SerializeField] private Sprite[] skins;
    [SerializeField] private SpriteRenderer playerSprite;
    private void Update()
    {
        for (int i = 0; i < skins.Length; i++)
        {
            if (skins[i].name == PlayerPrefs.GetString("SkinName", "Default"))
            {
                playerSprite.sprite = skins[i];
            }
        }
    }
}
