using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text Texto_Exp;
    [SerializeField] private Text Texto_Lvl;
    private Player player;

    private void Start()
    {
        //Instalador
        player = FindObjectOfType<Player>();
        Configure(player);
    }

    /*------------------[OBSERVER PATTERN ]----------------------------*/
    public void Configure(IPlayerAction player)
    {
        player.ExpUpdated += Updated;
        player.LvlUpdated += LevelUpdated;
    }

    public void Updated(int exp)
    {
       
        Texto_Exp.text = "Player Exp:" + exp;
        
    }


    public void LevelUpdated(int exp)
    {


        Texto_Lvl.text = "Player Level:" + exp;

    }
}
