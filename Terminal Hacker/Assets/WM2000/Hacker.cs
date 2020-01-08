using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    enum Screen
    {
        MainMenu,
        Password,
        Win
    };

    int _level;

    Screen _currentScreen = Screen.MainMenu;


    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    private void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Terminal Hacker The Game");
        Terminal.WriteLine("What would you like to hack?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for Local Library");
        Terminal.WriteLine("Press 2 for Local Police Station");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter Your Selection: ");
    }
    // Update is called once per frame
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "1")
        {
            _level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            _level = 2;
            StartGame();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level Mr Bond!");
        }
        else
        {
            Terminal.WriteLine("Please select a valid menu option");
        }
    }

    private void StartGame()
    {
        _currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("You have selected level: " + _level);
        Terminal.WriteLine("Enter Your Password:");

    }
}

