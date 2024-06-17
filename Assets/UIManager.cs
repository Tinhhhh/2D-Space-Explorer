using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //GameOverObject
    public GameObject Title;
    public GameObject Exit;
    public GameObject Restart;
    public GameObject MainMenu;

    //Winnning Object
    public GameObject WinningTitle;
    public GameObject WinningExit;
    public GameObject WinningStartGame;
    public GameObject WinningMainMenu;

    static public UIManager Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        UIManager.Instance = this;
        //GameOver Disappear When Game Start
        this.Title = GameObject.Find("Title");
        this.Exit = GameObject.Find("Exit");
        this.Restart = GameObject.Find("Restart");
        this.MainMenu = GameObject.Find("MainMenu");
        this.Title.SetActive(false);
        this.Exit.SetActive(false);
        this.Restart.SetActive(false);
        this.MainMenu.SetActive(false);

        //Winning Disappear When Game Start
        this.WinningTitle = GameObject.Find("WinningTitle");
        this.WinningExit = GameObject.Find("WinningExit");
        this.WinningStartGame = GameObject.Find("WinningStartGame");
        this.WinningMainMenu = GameObject.Find("WinningMainMenu");
        this.WinningTitle.SetActive(false);
        this.WinningExit.SetActive(false);
        this.WinningStartGame.SetActive(false);
        this.WinningMainMenu.SetActive(false);
    }
}
