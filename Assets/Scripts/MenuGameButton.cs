using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGameButton : MonoBehaviour
{
    public GameObject ContinueButton;
    public static MenuGameButton Instance;

    void Awake()
    {
        MenuGameButton.Instance = this;
        this.ContinueButton = GameObject.Find("Continue");

        if (PlayerPrefs.HasKey("Score") && PlayerPrefs.HasKey("PlayerX") && PlayerPrefs.HasKey("PlayerY") && PlayerPrefs.HasKey("PlayerZ"))
        {
            //Co du lieu
            this.ContinueButton.SetActive(true);
        }
        else
        {
            //Khong co du lieu
            this.ContinueButton.SetActive(false);
        }

    }
}
