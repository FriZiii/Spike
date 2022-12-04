using UnityEngine;

[CreateAssetMenu(fileName = "New Skin", menuName = "Skin")]
public class Skin : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    public int HighScoreCost;
    public int CoinCost;
}
