using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public TMP_Text DiamondCounter;

    private int _diamonds = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void AddDiamond()
    {
        _diamonds++;

        DiamondCounter.text = $"{_diamonds} / 10";
    }
}
