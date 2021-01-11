using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteNP : MonoBehaviour
{
    public Sprite[] sprite;
    public byte i;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Sprite"))
            i = (byte) PlayerPrefs.GetInt("Sprite");
        else i = 0;
        GetComponent<SpriteRenderer>().sprite = sprite[i];
    }

    public void NextSprite()
    {
        i++;
        if (i > 9)
            i = 0;
        PlayerPrefs.SetInt("Sprite", i);
        PlayerPrefs.Save();
        Debug.Log($"Player Next Sprite: {i}");
        GetComponent<SpriteRenderer>().sprite = sprite[i];
    }

    public void PastSprite()
    {
        i--;
        if (i == 255)
            i = 9;
        PlayerPrefs.SetInt("Sprite", i);
        PlayerPrefs.Save();
        Debug.Log($"Player Past Sprite: {i}");
        GetComponent<SpriteRenderer>().sprite = sprite[i];

    }
}
