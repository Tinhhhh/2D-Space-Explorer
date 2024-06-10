using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject Title;
    public GameObject Exit;
    public GameObject Restart;
    public GameObject MainMenu;

    static public UIManager Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        UIManager.Instance = this;
        this.Title = GameObject.Find("Title");
        this.Exit = GameObject.Find("Exit");
        this.Restart = GameObject.Find("Restart");
        this.MainMenu = GameObject.Find("MainMenu");
        this.Title.SetActive(false);
        this.Exit.SetActive(false);
        this.Restart.SetActive(false);
        this.MainMenu.SetActive(false);
    }
}
