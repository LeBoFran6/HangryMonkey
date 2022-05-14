using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Can1Up == true && Input.GetKeyDown(KeyCode.Z))
        {
            P1.SetActive(false);
            P1H.SetActive(true);
            F1B.SetActive(false);
            Can1Up = false;
            Can2Up = false;
            Can1Down = false;
            GameType = false;
        }

        if (Can1Down == true && Input.GetKeyDown(KeyCode.S))
        {
            P1.SetActive(false);
            P1B.SetActive(true);
            F1H.SetActive(false);
            Can1Down = false;
            Can2Down = false;
            Can1Up = false;
            GameType = true;

        }

        if (Can2Up == true && Input.GetKey("up"))
        {
            P2.SetActive(false);
            P2H.SetActive(true);
            F2B.SetActive(false);
            Can2Down = false;
            Can2Up = false;
            Can1Up = false;

        }

        if (Can2Down == true && Input.GetKey("down"))
        {
            P2.SetActive(false);
            P2B.SetActive(true);
            F2H.SetActive(false);
            Can2Down = false;
            Can1Down = false;
            Can2Up = false;
        }

        if(CanChoose == true && Can1Up == false && Can1Down == false && Can2Up == false && Can2Down == false)
        {
            GoButton.SetActive(true);
        }

       
    }



    public GameObject MainMenu;
    public GameObject PlayerSelectionMenu;
    public GameObject CreditsMenu;
    public GameObject LoadingInteractif;
    public GameObject WinScreen;


    public GameObject GoButton;


    public GameObject P1H;
    public GameObject P1;
    public GameObject P1B;
    public GameObject P2H;
    public GameObject P2;
    public GameObject P2B;

    public GameObject F1H;
    public GameObject F1B;
    public GameObject F2H;
    public GameObject F2B;


    public bool CanChoose = false;
    public bool Can1Up = true;
    public bool Can1Down = true;
    public bool Can2Up = true;
    public bool Can2Down = true;

    public bool GameType;
    //Le gametype permet de savoir si le p1 joue la banane (bool = false)   ou la pomme (bool = true)

    public void Play()
    {
        MainMenu.SetActive(false);
        PlayerSelectionMenu.SetActive(true);
        CanChoose = true;
    }
    public void Credits()
    {
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void BackPlayerSelec()
    {
        PlayerSelectionMenu.SetActive(false);
        MainMenu.SetActive(true);
        CanChoose = false;
        P1H.SetActive(false);
        P1.SetActive(true);
        P1B.SetActive(false);
        P2H.SetActive(false);
        P2.SetActive(true);
        P2B.SetActive(false);
        F1H.SetActive(true);
        F1B.SetActive(true);
        F2H.SetActive(true);
        F2B.SetActive(true);
        GoButton.SetActive(false);
        Can1Up = true;
        Can1Down = true;
        Can2Up = true;
        Can2Down = true;
    }
    public void Go()
    {
        PlayerSelectionMenu.SetActive(false);
        LoadingInteractif.SetActive(true);
    }
    public void ReturnTuMainMenuAfterGame()
    {
        WinScreen.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void BackCredits()
    {
        CreditsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
}
