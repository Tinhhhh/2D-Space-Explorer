using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject WinTitle;
    public GameObject GameOverTitle;
    public GameObject Exit;
    public GameObject Restart;
    public GameObject MainMenu;
    public GameObject Player;

    static public UIManager Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        UIManager.Instance = this;
        this.WinTitle = GameObject.Find("WinTitle");
        this.GameOverTitle = GameObject.Find("GameOverTitle");
        this.Exit = GameObject.Find("Exit");
        this.Restart = GameObject.Find("Restart");
        this.MainMenu = GameObject.Find("MainMenu");
        this.Player = GameObject.Find("Player");
        this.WinTitle.SetActive(false);
        this.GameOverTitle.SetActive(false);
        this.Exit.SetActive(false);
        this.Restart.SetActive(false);
        this.MainMenu.SetActive(false);
        this.Player.SetActive(true);
    }
}
