using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control - Menu Starter
    // Description: Finch robot showing lights, sounds, and movement within C#.
    // Application Type: Console
    // Author: Bode, Brandon
    // Dated Created: 10/01/2020
    // Last Modified: 10/04/2020
    //
    // **************************************************

    class Program
    {
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch finchRobot = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        DisplayTalentShowMenuScreen(finchRobot);
                        break;

                    case "c":
                        DataRecorderDisplayMenuScreen(finchRobot);
                        break;

                    case "d":
                        AlarmSystemDisplayMenuScreen(finchRobot);
                        break;

                    case "e":
                        UserProgrammingDisplayMenuScreen(finchRobot);
                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        static void DisplayTalentShowMenuScreen(Finch myFinch)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) Dance");
                Console.WriteLine("\tc) The Boogie");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayLightAndSound(myFinch);
                        break;

                    case "b":
                        Dance(myFinch);
                        break;

                    case "c":
                        TheBoogie(myFinch);

                        break;

                    case "d":

                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }
        #endregion

        #region Light and Sound
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayLightAndSound(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tThe Finch robot will now show off its glowing talent!");
            DisplayContinuePrompt();

            //
            // Leds change from blue to red while sound increases and decreases in frequency
            //

            for (int ledValue = 0; ledValue < 255; ledValue++)
            {
                finchRobot.setLED(ledValue, ledValue, 255);
                finchRobot.wait(5);
                finchRobot.noteOn(ledValue * 10);
            }
            for (int ledValue = 255; ledValue > 0; ledValue--)
            {
                finchRobot.setLED(255, ledValue, ledValue);
                finchRobot.wait(5);
                finchRobot.noteOn(ledValue * 10);
            }
         
            finchRobot.noteOff();
            Console.Clear();
            DisplayMenuPrompt("Talent Show Menu");
        }
        #endregion

        #region Dance
        /// *****************************************************************
        /// *               Talent Show > The Dance                  *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>

        static void Dance(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("The Dancing Finch");

            Console.WriteLine("\tThe Finch robot will now show off its spectacular dance moves!");
            DisplayContinuePrompt();

            Console.Clear();
            DisplayScreenHeader("The Full Circle");
            FullCircle(finchRobot);

            Console.WriteLine("\t\tThe Backing Up Circle");
            BackingUpCircle(finchRobot);


            DisplayMenuPrompt("Talent Show Menu");
        }
        static void FullCircle(Finch finchRobot)
        {
            finchRobot.setMotors(125, 0);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 125);
            finchRobot.wait(1000);
            finchRobot.setMotors(125, 0);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 125);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 125);
            finchRobot.wait(4000);

            finchRobot.setMotors(0, 0);
        }

        static void BackingUpCircle(Finch finchRobot)
        {

            finchRobot.setMotors(-125, 0);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, -125);
            finchRobot.wait(1000);
            finchRobot.setMotors(-125, 0);
            finchRobot.wait(1000);
            finchRobot.setMotors(-125, -125);
            finchRobot.wait(1000);
            finchRobot.setMotors(-500, 0);
            finchRobot.wait(2000);
            finchRobot.setMotors(0, 0);
        }
        #endregion

        #region The Boogie
        /// *****************************************************************
        /// *               Talent Show > The Boogie                  *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>

        static void TheBoogie(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("The Finch's Wild Boogie");

            Console.WriteLine("\tThe Finch robot will now show you how to boogie!");
            DisplayContinuePrompt();

            //
            // method attempts to sing star spangled banner while dancing
            //
            PlayMusic(finchRobot);

            DisplayMenuPrompt("Talent Show Menu");
        }

        static void PlayMusic(Finch finchRobot)
        {
            finchRobot.setLED(255, 0, 0);
            finchRobot.noteOn(710);
            finchRobot.setMotors(150, 0);
            finchRobot.wait(400);
            finchRobot.setMotors(0, 0);
            finchRobot.noteOn(510);
            finchRobot.wait(500);
            finchRobot.noteOn(400);
            finchRobot.wait(1200);
            finchRobot.noteOn(510);
            finchRobot.wait(700);
            finchRobot.noteOn(610);
            finchRobot.wait(700);
            finchRobot.noteOn(810);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.setMotors(150, 150);
            finchRobot.wait(300);
            finchRobot.setMotors(0, 0);
            
            finchRobot.setLED(255, 255, 255);
            finchRobot.wait(500);
            finchRobot.noteOn(1000);
            finchRobot.wait(700);
            finchRobot.noteOn(910);
            finchRobot.wait(500);
            finchRobot.noteOn(800);
            finchRobot.wait(700);
            finchRobot.noteOn(500);
            finchRobot.wait(600);
            finchRobot.noteOn(550);
            finchRobot.wait(600);
            finchRobot.noteOn(610);
            finchRobot.wait(700);
            finchRobot.noteOff();
            finchRobot.wait(500);
            finchRobot.setMotors(255, -255);
            finchRobot.wait(300);
            finchRobot.setMotors(0, 0);

            finchRobot.setLED(0, 0, 255);
            finchRobot.noteOn(610);
            finchRobot.wait(700);
            finchRobot.noteOn(550);
            finchRobot.noteOn(1000);
            finchRobot.wait(900);
            finchRobot.noteOn(910);
            finchRobot.wait(500);
            finchRobot.noteOn(810);
            finchRobot.wait(500);
            finchRobot.noteOn(750);
            finchRobot.wait(700);
            finchRobot.noteOff();
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.setMotors(0, -255);
            finchRobot.wait(500);
            finchRobot.setMotors(200, -50);
            finchRobot.wait(500);
            finchRobot.setMotors(0, 0);
        }
            #endregion

            #region Data Recorder

            /// <summary>
            /// *****************************************************************
            /// *                     Data Recorder Menu                          *
            /// *****************************************************************
            /// </summary>
            static void DataRecorderDisplayMenuScreen(Finch myFinch)
        {
            Console.CursorVisible = true;

            bool quitDataRecorderMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Data Recorder Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) This module is under development");
                Console.WriteLine("\tb) ...");
                Console.WriteLine("\tc) ...");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        
                        break;

                    case "b":
                        
                        break;

                    case "c":
                        
                        break;

                    case "d":

                        break;

                    case "q":
                        quitDataRecorderMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitDataRecorderMenu) ;

    }
        #endregion

        #region Alarm System Menu

        /// <summary>
        /// *****************************************************************
        /// *                     Data Recorder Menu                          *
        /// *****************************************************************
        /// </summary>
        static void AlarmSystemDisplayMenuScreen(Finch myFinch)
        {
            Console.CursorVisible = true;

            bool quitAlarmSystemMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Alarm System Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) This module is under development");
                Console.WriteLine("\tb) ...");
                Console.WriteLine("\tc) ...");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":

                        break;

                    case "b":

                        break;

                    case "c":

                        break;

                    case "d":

                        break;

                    case "q":
                        quitAlarmSystemMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitAlarmSystemMenu);

        }
        #endregion

        #region User Programming Menu

        /// <summary>
        /// *****************************************************************
        /// *                     User Programming Menu                          *
        /// *****************************************************************
        /// </summary>
        static void UserProgrammingDisplayMenuScreen(Finch myFinch)
        {
            Console.CursorVisible = true;

            bool quitUserProgrammingMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("User Programming Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) This module is under development");
                Console.WriteLine("\tb) ...");
                Console.WriteLine("\tc) ...");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":

                        break;

                    case "b":

                        break;

                    case "c":

                        break;

                    case "d":

                        break;

                    case "q":
                        quitUserProgrammingMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitUserProgrammingMenu);

        }
        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <Disconnect>
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.noteOn(700);
            finchRobot.wait(250);
            finchRobot.noteOff();

            finchRobot.disConnect();

            Console.Clear();
            Console.WriteLine("\tThe Finch robot is now disconnected.");

            DisplayMenuPrompt("Main Menu");
        }

        /// <Connect>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = finchRobot.connect();

            // TODO test connection and provide user feedback - text, lights, sounds
            Successfulconnection(finchRobot);


            DisplayMenuPrompt("Main Menu");

            //
            // reset finch robot
            //
            finchRobot.setLED(0, 0, 0);

            return robotConnected;
        }

        static void Successfulconnection(Finch finchRobot)
        {
            finchRobot.setLED(255, 0, 0);
            finchRobot.wait(500);
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(500);
            finchRobot.setLED(0, 0, 255);
            finchRobot.wait(500);
            finchRobot.noteOn(250);
            finchRobot.wait(500);
            finchRobot.noteOff();
            Console.Clear();
            Console.WriteLine("Robot Successfully Connected.");
        }
        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}
