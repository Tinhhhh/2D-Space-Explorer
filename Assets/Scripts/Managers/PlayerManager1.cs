using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager1 : MonoBehaviour
{
    public static PlayerManager1 instance;
    [SerializeField] private TMP_Text extralifeDisplay;
    public int extralife = 3;
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    void Update(){
        // extralife = playerExtralife.GetExtraLife();
    }

    private void OnGUI()
    {
        extralifeDisplay.text = extralife.ToString();
    }

    
    public void MinusExtraLife(int amount)
    {
        extralife -= amount;
    }

    
}
