using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // game variables
    string[] Level1Passwords = { "copper", "jail", "raid", "detective" };
    string[] Level2Passwords = { "intelligence", "pentagon", "security", "communists", "politics" };
    string[] Level3Passwords = {"spaceship", "jupiter", "satellite", "planet"};
    const string menuHint = "Remember Hooman you can go to menu anytime ";

    // gamestate
    int level;
    int index;
    enum Screen { MainMenu, Password, Win }
    Screen currentScreen;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        show_main_menu("...booting...\n");
    }

    void show_main_menu(string status)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        string greeting = status + "Hello Hooman. I am compooter.";
        Terminal.WriteLine(greeting);
        Terminal.WriteLine(
@"Is so very nice to met you. Let's pleh gam :)

We pleh hack manfram?
Hack de polease? Click de 1 botton!
Hack de goberman? Click de 2 botton!
You press now what?");
        Terminal.WriteLine(menuHint);
    }

    void OnUserInput(string input)
    {

        // two different approaches
        //print(input == "1");
        if (input == "menu")
        {
            show_main_menu("...rebooting...\n");
        }
        else if (input == "quit" ||input == "close"||input == "exit") {
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool ValidPass = (input == "1" || input == "2" || input == "3");
        if (ValidPass)
        {
            level = int.Parse(input); // no longer need to manually assign level
            GameStart();
        }
        else
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Compooter no compoot. Choose 1, 2, 3 or 'menu'.");
        }
    }

    void GameStart()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine(menuHint);
        SetPassword();
        Terminal.WriteLine(@"Plz enter passward:
        Hint: Is like " + password.Anagram());
    }

    void SetPassword() {
        switch (level) {
            case 1:
                index = UnityEngine.Random.Range(0, Level1Passwords.Length);
                password = Level1Passwords[index];
                // could also do:
                // password = Level1Passwords[UnityEngine.Random.Range(0,Level1Passwords.Length)];
                break;
            case 2:
                index = UnityEngine.Random.Range(0, Level2Passwords.Length);
                password = Level2Passwords[index];
                break;
            case 3:
                index = UnityEngine.Random.Range(0, Level3Passwords.Length);
                password = Level3Passwords[index];
                break;
            default:
                Debug.LogError("Invalid Level Number");
                break;
        }
    }



    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            GameStart();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        YourEternalReward();
        Terminal.WriteLine(menuHint);

    }

    void YourEternalReward() {
        switch (level) {
            case 1:
                Terminal.WriteLine("Good Hooman. Have a cookie :)");
                Terminal.WriteLine(@"
                                                               
                 /-----\ 
                /   ^   \ 
               ( ^     ^ ) 
                \  ^   ^/   
                 \_____/ ");
            break;
            case 2:
                Terminal.WriteLine("Great job.");
                Terminal.WriteLine(@"
        iiiiiiiiii
      |:H:a:p:p:y:|
    __|___________|__
   |^^^^^^^^^^^^^^^^^|
   |:B:i:r:t:h:d:a:y:|
   |                 |
   ~~~~~~~~~~~~~~~~~~~");
                break;
            case 3:
                Terminal.WriteLine("Espectacoolar!");
                Terminal.WriteLine(@"
    ,-:` \;',`'-, 
  .'-;_,;  ':-;_,'.
 /;   '/    ,  _`.-\
| '`. (`     /` ` \`|
|:.  `\`-.   \_   / |
|     (   `,  .`\ ;'|
 \     | .'     `-'/
  `.   ;/        .'
    `'-._____.");
                break;
        }
    }

}


