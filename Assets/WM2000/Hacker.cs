using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // game variables
    string[] Level1Passwords =  {"copper", "stickemup", "lethalweapon", "policeacademy"};
    string[] Level2Passwords =  {"cia", "pentagon", "bigstick", "communistas"};

    // gamestate
    int level;
    enum Screen { MainMenu, Password, Win}
    Screen currentScreen;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        show_main_menu("...booting...\n");
    }

    void show_main_menu (string status) {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        string greeting = status + "Hello Hooman. I am compooter.";
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("Is so very nice to met you. \nYou want pleh gam? I can be gam :)");
        Terminal.WriteLine("\nWe pleh hack manfram?");
        Terminal.WriteLine("Hack de polease? Click de 1 botton!");
        Terminal.WriteLine("Hack de goberman? Click de 2 botton!");
        Terminal.WriteLine("\nYou press now what?");
    }

    void OnUserInput(string input) {

        // two different approaches
        //print(input == "1");
        if (input == "menu") {
            show_main_menu("...rebooting...\n");
        } else if (currentScreen == Screen.MainMenu) {
            RunMainMenu(input);
        } else if (currentScreen == Screen.Password) {
            CheckPassword(input);
        }
	}

    void RunMainMenu(string input) {
        if (input == "1"){
		    level = 1;
            password = Level1Passwords[2]; // TODO: make random
            GameStart ();
        } else if (input == "2") {
            level = 2;
            password = Level2Passwords[3]; // TODO: make random
            GameStart ();
        } else {
            Terminal.WriteLine("Compooter no compoot. Choose 1 or 2 or 'menu'.");
        }
    }

    void GameStart () {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You choose number " + level);
        Terminal.WriteLine("Password:");
    }



    void CheckPassword (string input) {
        if (input == password) {
            Terminal.WriteLine("yup :)");
        } else {
            Terminal.WriteLine("nope :(");
        }
    }
}
