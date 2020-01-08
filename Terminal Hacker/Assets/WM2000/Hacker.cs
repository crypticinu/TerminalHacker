using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    string[] level1Passwords = { "books", "aisle", "books", "self", "password" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };

    enum Screen
    {
        MainMenu,
        Password,
        Win
    };

    int _level;

    Screen _currentScreen;
    string _password;


    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    private void ShowMainMenu()
    {
        _currentScreen = Screen.MainMenu;
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
        else if (_currentScreen == Screen.MainMenu)
        {
            RunMenu(input);
        }
        else if (_currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
      
    }

    private void RunMenu(string input)
    {

        bool isValidLevelNumber = (input == "1" || input == "2");
        if (isValidLevelNumber)
        {
            _level = int.Parse(input);
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
        int index = 0;
        switch (_level)
        {
            case 1:
                index = UnityEngine.Random.Range(0, level1Passwords.Length);
                _password = level1Passwords[index];
                break;
            case 2:
                index = UnityEngine.Random.Range(0, level2Passwords.Length);
                _password = level2Passwords[index];
                break;
            default:
                break;
        }
        Terminal.WriteLine("Enter Your Password, hint: " + _password.Anagram());
    }
    private void CheckPassword(string input)
    {
        if (input == _password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Wrong Password, Try Again");

        }
    }

    private void DisplayWinScreen()
    {
        _currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    private void ShowLevelReward()
    {
        switch (_level)
        {
            case 1:
                Terminal.WriteLine("Won Library Level");
                break;
            case 2:
                Terminal.WriteLine("Won Police Station Level");
                break;
            default:
                break;
        }
    }
}

