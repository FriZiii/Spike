using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hover : MonoBehaviour
{
    [SerializeField] GameObject hoverBlock;

    private void Awake()
    {
        hoverBlock.SetActive(false);
    }
    public void isHover()
    {
        hoverBlock.SetActive(true);
    }

    public void isNotHover()
    {
        hoverBlock.SetActive(false);
    }

}
