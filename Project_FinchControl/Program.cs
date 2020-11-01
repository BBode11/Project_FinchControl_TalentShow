using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using FinchAPI;

namespace Project_FinchControl
{
    //
    // enum for user programming
    //
    public enum Command
    {
        NONE,
        MOVEFORWARD,
        MOVEBACKWARD,
        STOPMOTORS,
        WAIT,
        TURNRIGHT,
        TURNLEFT,
        LEDON,
        LEDOFF,
        GETTEMPERATURE,
        DONE
    }


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
            int numberOfDataPoints = 0;
            double dataPointFrequency = 0;
            double[] temperatures = null;

            do
            {
                DisplayScreenHeader("Data Recorder Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Number of Data Points");
                Console.WriteLine("\tb) Frequency of Data Points");
                Console.WriteLine("\tc) Get Data");
                Console.WriteLine("\td) Show Data");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        numberOfDataPoints = DataRecorderDisplayGetNumberOfDataPoints();
                        break;

                    case "b":
                        dataPointFrequency = DataRecorderDisplayGetDataPointFrequency();

                        break;

                    case "c":
                        temperatures = DataRecorderDisplayGetData(numberOfDataPoints, dataPointFrequency, myFinch);

                        break;

                    case "d":
                        DataRecorderDisplayData(temperatures);

                        break;

                    case "e":
                        DisplayDisconnectFinchRobot(myFinch);

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

            } while (!quitDataRecorderMenu);

        }

        static void DataRecorderDisplayData(double[] temperatures)
        {
            DisplayScreenHeader("Temperature Data Display");
            //
            //displays data from finch
            //
            DataRecorderDisplayTable(temperatures);
        }

        static void DataRecorderDisplayTable(double[] temperatures)
        {
            //
            // Display table headers
            //
            Console.WriteLine(
                "Recording #".PadLeft(15) +
                "Temp".PadLeft(15)
                );
            Console.WriteLine(
               "-----------".PadLeft(15) +
               "-----------".PadLeft(15)
               );

            //
            // display table data
            //

            for (int i = 0; i < temperatures.Length; i++)
            {
                Console.WriteLine(
               (i + 1).ToString().PadLeft(15) +
               temperatures[i].ToString("n2").PadLeft(15)
               );
            }

            DisplayContinuePrompt();
        }

        static double[] DataRecorderDisplayGetData(int numberOfDataPoints, double dataPointFrequency, Finch myFinch)
        {
            double[] temperatures = new double[numberOfDataPoints];

            DisplayScreenHeader("Get Data");

            Console.WriteLine($"Number of data points: {numberOfDataPoints}");
            Console.WriteLine($"Data point frequency: {dataPointFrequency}");
            Console.WriteLine();
            Console.WriteLine("\tThe finch robot is ready to start recording temperature data.");
            DisplayContinuePrompt();

            for (int i = 0; i < numberOfDataPoints; i++)
            {
                temperatures[i] = myFinch.getTemperature();
                Console.WriteLine($"\tReading {i + 1}: {temperatures[i].ToString("n2")}");
                int waitInSeconds = (int)(dataPointFrequency * 1000);
                myFinch.wait(waitInSeconds);

            }

            DisplayContinuePrompt();
            DisplayScreenHeader("Get Data");

            Console.WriteLine();
            Console.WriteLine("\tTable of Temperatures");
            Console.WriteLine();

            DataRecorderDisplayTable(temperatures);
            Console.WriteLine();
            Console.Clear();

            //
            // tells user average temperature
            //
            Console.WriteLine($"\tAverage Temperature: {temperatures.Average()}");

            DisplayContinuePrompt();

            return temperatures;
        }

        /// <summary>
        /// Get the frequency of data points from user
        /// </summary>
        /// <returns>Frequency of data points</returns>
        static double DataRecorderDisplayGetDataPointFrequency()
        {
            bool validResponse;
            double DataPointFrequency;

            do
            {
                validResponse = true;
                DisplayScreenHeader("Data Point Frequency");

                Console.WriteLine("\tFrequency of data points in seconds: ");

                //
                // validate user input
                //
                if (!double.TryParse(Console.ReadLine(), out DataPointFrequency))
                {
                    validResponse = false;

                    Console.WriteLine();
                    Console.WriteLine("Please enter an acceptable number in digit form, for example '10'.");

                    DisplayContinuePrompt();
                }
                Console.WriteLine();
                Console.WriteLine($"Frequency of Data Points in Seconds: {DataPointFrequency}");
            } while (!validResponse);
            //
            // pause for user
            //


            DisplayContinuePrompt();

            return DataPointFrequency;
        }

        /// <summary>
        /// Get the number of data points from the user
        /// </summary>
        /// <returns>Number of data points</returns>
        static int DataRecorderDisplayGetNumberOfDataPoints()
        {
            bool validResponse;
            int numberOfDataPoints;
            string userResponse;
            do
            {
                validResponse = true;
                DisplayScreenHeader("Number of Data Points");

                Console.WriteLine("\tNumber of data points: ");
                userResponse = Console.ReadLine();
                //
                // validate user input
                //
                if (!int.TryParse(userResponse, out numberOfDataPoints))
                {
                    validResponse = false;

                    Console.WriteLine();
                    Console.WriteLine("Please enter an acceptable number in digit form, for example '10'.");

                    DisplayContinuePrompt();
                }
                Console.WriteLine();
                Console.WriteLine($"Number of Data Points: {numberOfDataPoints}");
            } while (!validResponse);
            //
            // pause for user
            //
            DisplayContinuePrompt();

            return numberOfDataPoints;
        }
        #endregion

        #region Alarm System Menu

        /// <summary>
        /// *****************************************************************
        /// *                     Alarm System Menu                         *
        /// *****************************************************************
        /// </summary>
        static void AlarmSystemDisplayMenuScreen(Finch myFinch)
        {
            Console.CursorVisible = true;

            bool quitAlarmSystemMenu = false;
            string menuChoice;

            string sensorsToMonitor = "";
            string rangeType = "";
            int minMaxThresholdValue = 0;
            int timeToMonitor = 0;

            do
            {
                DisplayScreenHeader("Alarm System Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Set Sensors to Monitor");
                Console.WriteLine("\tb) Set Range Type");
                Console.WriteLine("\tc) Set Minimum/Maximum Threshold Value");
                Console.WriteLine("\td) Set Time to Monitor");
                Console.WriteLine("\te) Set Alarm");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        sensorsToMonitor = LightAlarmDisplaySetSensorsToMonitor();
                        break;

                    case "b":
                        rangeType = LightAlarmDisplaySetRangeType();
                        break;

                    case "c":
                        minMaxThresholdValue = LightAlarmSetMinMaxThresholdValue(rangeType, myFinch);
                        break;

                    case "d":
                        timeToMonitor = LightAlarmSetTimeToMonitor();
                        break;

                    case "e":
                        LightAlarmSetAlarm(myFinch, sensorsToMonitor, rangeType, minMaxThresholdValue, timeToMonitor);
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

        static void LightAlarmSetAlarm(Finch myFinch, string sensorsToMonitor, string rangeType, int minMaxThresholdValue, int timeToMonitor)
        {
            int secondsElapsed = 0;
            bool thresholdExceeded = false;
            int currentLightSensorValue = 0;

            DisplayScreenHeader("Set Alarm");

            Console.WriteLine($"\tSensors to Monitor: {sensorsToMonitor}");
            Console.WriteLine($"\tRange Type: {rangeType}");
            Console.WriteLine("\tMin/Max Threshold Value: " + minMaxThresholdValue);
            Console.WriteLine($"\tTime to Monitor: {timeToMonitor}");

            Console.WriteLine("\tPress any key to begin monitoring.");
            Console.ReadKey();
            Console.WriteLine();

            //
            // alarm
            //
            while ((secondsElapsed < timeToMonitor) && !thresholdExceeded)
            {
                switch (sensorsToMonitor)
                {
                    case "left":
                        currentLightSensorValue = myFinch.getLeftLightSensor();
                        break;

                    case "right":
                        currentLightSensorValue = myFinch.getRightLightSensor();
                        break;

                    case "both":
                        currentLightSensorValue = (myFinch.getRightLightSensor() + myFinch.getRightLightSensor()) / 2;
                        break;
                }

                switch (rangeType)
                {
                    case "minimum":
                        if (currentLightSensorValue < minMaxThresholdValue)
                        {
                            thresholdExceeded = true;
                        }
                        break;

                    case "maximum":
                        if (currentLightSensorValue > minMaxThresholdValue)
                        {
                            thresholdExceeded = true;
                        }
                        break;
                }
                myFinch.wait(1000);
                secondsElapsed++;
                //
                // increasing seconds by 1
                //
            }

            if (thresholdExceeded)
            {
                Console.WriteLine($"\tThe {rangeType} threshold value of {minMaxThresholdValue} was exceeded by the current light sensor value of {currentLightSensorValue}.");
            }
            else
            {
                Console.WriteLine($"\tThe {rangeType} threshold value of {minMaxThresholdValue} was not exceeded.");
            }
            DisplayMenuPrompt("Alarm System");
        }

        static int LightAlarmSetTimeToMonitor()
        {
            int timeToMonitor;
            string userResponse;
            bool validResponse;

            do
            {
                validResponse = true;
                DisplayScreenHeader("Time to Monitor");

                Console.WriteLine("\tTime to Monitor: ");
                userResponse = Console.ReadLine();
                //
                // validate user input
                //
                if (!int.TryParse(userResponse, out timeToMonitor))
                {
                    //echo value and validate
                    validResponse = false;

                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter the number of seconds you would like to monitor, for example: '5'.");

                    DisplayContinuePrompt();
                }
                Console.WriteLine();
                Console.WriteLine($"Time to Monitor: {timeToMonitor}");
            } while (!validResponse);


            DisplayMenuPrompt("Alarm System");

            return timeToMonitor;
        }

        static int LightAlarmSetMinMaxThresholdValue(string rangeType, Finch myFinch)
        {
            int minMaxThresholdValue;
            bool validResponse;
            string userResponse;

            do
            {
                validResponse = true;
                DisplayScreenHeader("Minimum/Maximum Threshold Value");

                Console.WriteLine($"\tLeft light sensor ambient value: {myFinch.getLeftLightSensor()}");
                Console.WriteLine($"\tRight light sensor ambient value: {myFinch.getRightLightSensor()}");
                Console.WriteLine();

                Console.Write($"\tEnter the {rangeType} light sensor value:");
                userResponse = Console.ReadLine();

                //
                //validate user input
                //

                if (!int.TryParse(userResponse, out minMaxThresholdValue))
                {
                    validResponse = false;

                    Console.WriteLine();
                    Console.WriteLine("Please enter an acceptable number in digit form, for example: '50'.");

                    DisplayContinuePrompt();
                }
                Console.WriteLine();
                Console.WriteLine($"The threshold value is {rangeType}, while the light sensor value is {minMaxThresholdValue}.");
                //echo value and validate
            } while (!validResponse);

            //
            // pause for user
            //
            DisplayMenuPrompt("Alarm System");

            return minMaxThresholdValue;
        }

        static string LightAlarmDisplaySetSensorsToMonitor()
        {
            string sensorsToMonitor;

            DisplayScreenHeader("Sensors to Monitor");

            Console.WriteLine("\tSensors to monitor [left, right, both]:");
            sensorsToMonitor = Console.ReadLine().ToLower();

            //
            // create loop
            //
            if (sensorsToMonitor == "left")
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("\tYou will be monitoring the left sensors.");
                DisplayMenuPrompt("Alarm System");

                return sensorsToMonitor;
            }
            else if (sensorsToMonitor == "right")
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("\tYou will be monitoring the right sensors.");
                DisplayMenuPrompt("Alarm System");

                return sensorsToMonitor;
            }
            else if (sensorsToMonitor == "both")
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("\tYou will be monitoring both sensors.");
                DisplayMenuPrompt("Alarm System");

                return sensorsToMonitor;
            }
            else
            {
                Console.WriteLine("Please enter one of the values: 'left', 'right', or 'both'");
                sensorsToMonitor = Console.ReadLine().ToLower();
                Console.WriteLine($"You will be monitoring {sensorsToMonitor} sensor(s).");
            }

            DisplayMenuPrompt("Alarm System");

            return sensorsToMonitor;
        }

        static string LightAlarmDisplaySetRangeType()
        {
            string rangeType;

            DisplayScreenHeader("Range Type");

            Console.WriteLine("\tRange Type [minimum, maximum]:");
            rangeType = Console.ReadLine();

            if (rangeType == "minimum")
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("\tThe range type you selected is minimum.");
                DisplayMenuPrompt("Alarm System");

                return rangeType;
            }
            else if (rangeType == "maximum")
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("\tThe range type you selected is maximum.");
                DisplayMenuPrompt("Alarm System");

                return rangeType;
            }
            else
            {
                Console.WriteLine("Please enter one of the values: 'minimum', or 'maximum'.");
                rangeType = Console.ReadLine().ToLower();
                Console.WriteLine($"The range type selected is {rangeType}");
            }

            DisplayMenuPrompt("Alarm System");

            return rangeType;
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

            //
            // tuple to store command parameters
            // 

            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;

            List<Command> commands = new List<Command>();

            do
            {
                DisplayScreenHeader("User Programming Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Set Command Parameters");
                Console.WriteLine("\tb) Add Commands");
                Console.WriteLine("\tc) View Commands");
                Console.WriteLine("\td) Execute Commands");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        commandParameters = UserProgrammingDisplayGetCommandParameters();
                        break;

                    case "b":
                        UserProgrammingDisplayGetFinchCommands(commands);
                        break;

                    case "c":
                        UserProgrammingDisplayFinchCommands(commands);
                        break;

                    case "d":
                        UserProgrammingDisplayExecuteFinchCommands(myFinch, commands, commandParameters);
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
        /// <summary>
        /// *************************************************
        /// *           Execute User Commands               *
        /// *************************************************
        /// </summary>
        /// <param name="myFinch">Finch robot object</param>
        /// <param name="commands">list of commands</param>
        /// <param name="commandParameters">tuple of command parameters</param>
        static void UserProgrammingDisplayExecuteFinchCommands(
            Finch myFinch,
            List<Command> commands,
            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters)
        {

            {
                int motorSpeed = commandParameters.motorSpeed;
                int ledBrightness = commandParameters.ledBrightness;
                int waitMilliSeconds = (int)(commandParameters.waitSeconds = 1000);
                string commandFeedback = "";
                const int TURNING_MOTOR_SPEED = 100;

                DisplayScreenHeader("Execute Finch Commands");

                Console.WriteLine("\tThe finch robot is ready to execute the list of commands.");
                DisplayContinuePrompt();

                foreach (Command command in commands)
                {
                    switch (command)
                    {
                        case Command.NONE:
                            break;

                        case Command.MOVEFORWARD:
                            myFinch.setMotors(motorSpeed, motorSpeed);
                            commandFeedback = Command.MOVEFORWARD.ToString();
                            break;

                        case Command.MOVEBACKWARD:
                            myFinch.setMotors(-motorSpeed, -motorSpeed);
                            commandFeedback = Command.MOVEBACKWARD.ToString();
                            break;

                        case Command.STOPMOTORS:
                            myFinch.setMotors(0, 0);
                            commandFeedback = Command.STOPMOTORS.ToString();
                            break;

                        case Command.WAIT:
                            myFinch.wait(waitMilliSeconds);
                            commandFeedback = Command.WAIT.ToString();
                            break;

                        case Command.TURNRIGHT:
                            myFinch.setMotors(TURNING_MOTOR_SPEED, -TURNING_MOTOR_SPEED);
                            commandFeedback = Command.TURNRIGHT.ToString();
                            break;

                        case Command.TURNLEFT:
                            myFinch.setMotors(-TURNING_MOTOR_SPEED, TURNING_MOTOR_SPEED);
                            commandFeedback = Command.TURNLEFT.ToString();
                            break;

                        case Command.LEDON:
                            myFinch.setLED(ledBrightness, ledBrightness, ledBrightness);
                            commandFeedback = Command.LEDON.ToString();
                            break;

                        case Command.LEDOFF:
                            myFinch.setLED(0, 0, 0);
                            commandFeedback = Command.LEDOFF.ToString();
                            break;

                        case Command.GETTEMPERATURE:
                            commandFeedback = $"Temperature: {myFinch.getTemperature().ToString("n2")}\n";
                            break;

                        default:

                            break;
                    }
                    Console.WriteLine($"\t{commandFeedback}");
                }
                DisplayMenuPrompt("User Programming");
            }

        }

        /// <summary>
        /// *************************************************
        /// *           Display User Commands               *
        /// *************************************************
        /// </summary>
        /// <param name="commands"></param>
        static void UserProgrammingDisplayFinchCommands(List<Command> commands)
        {
            DisplayScreenHeader("Finch Robot Commands");

            // Command = Enum, param name = commands, command = the commands the user inputs.
            foreach (Command command in commands)
            {
                Console.WriteLine($"\t{command}");
            }

            DisplayMenuPrompt("User Programming");
        }

        /// <summary>
        /// *************************************************
        /// *           Gather Commands From User           *
        /// *************************************************
        /// </summary>
        /// <param name="commands">list of commands</param>
        static void UserProgrammingDisplayGetFinchCommands(List<Command> commands)
        {
            Command command = Command.NONE;

            DisplayScreenHeader("Finch Robot Commands");

            //
            // list of commands
            //
            int commandCount = 1;
            Console.WriteLine("\tList of Available Commands");
            Console.WriteLine();
            Console.Write("\t-");
            foreach (string commandName in Enum.GetNames(typeof(Command)))
            {
                Console.Write($"- {commandName.ToLower()} -");
                if (commandCount % 5 == 0) Console.Write("-\n\t-");
                commandCount++;
            }
            Console.WriteLine();

            //
            // Once equal to done the commands are saved and the loop ends
            //
            while (command != Command.DONE)
            {
                Console.WriteLine("\tEnter Command:");

                if (Enum.TryParse(Console.ReadLine().ToUpper(), out command))
                {
                    commands.Add(command);
                }
                else
                {
                    Console.WriteLine("\t\t***************************************");
                    Console.WriteLine("\t\tPlease Enter A Command From The List Above.");
                    Console.WriteLine("\t\t***************************************");

                }
            }

            // echos command

            DisplayMenuPrompt("User Programming");
        }

        /// <summary>
        /// ***************************************************
        /// *       Get Command Parameters from User          *
        /// ***************************************************
        /// </summary>
        /// <returns>tuple of command parameters</returns>
        static (int motorSpeed, int ledBrightness, double waitSeconds) UserProgrammingDisplayGetCommandParameters()
        {
            DisplayScreenHeader("Command Paramerters");

            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;

            //
            // CREATE METHOD OR LOOP for validation of integer and double.
            //

            GetValidInteger("\tEnter Motor Speed [1 - 255]:", 1, 255, out commandParameters.motorSpeed);
            GetValidInteger("\tEnter LED Brightness [1 -255]:", 1, 255, out commandParameters.ledBrightness);
            GetValidDouble("\tEnter Wait in Seconds:", 0, 10, out commandParameters.waitSeconds);

            Console.WriteLine();
            Console.WriteLine($"\tMotor Speed: {commandParameters.motorSpeed}");
            Console.WriteLine($"\tLED Brightness: {commandParameters.ledBrightness}");
            Console.WriteLine($"\tWait Command Duration: {commandParameters.waitSeconds}");

            DisplayMenuPrompt("User Programming");

            return commandParameters;
        }

        /// <summary>
        /// Method for validation of Doubles
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="minimumValue"></param>
        /// <param name="maximumValue"></param>
        /// <param name="validDouble"></param>
        /// <returns>a valid double</returns>
        private static double GetValidDouble(string prompt, double minimumValue, double maximumValue, out double validDouble)
        {
            bool validDoubles;

            do
            {
                Console.Write(prompt);
                if (maximumValue - minimumValue == 0)
                {
                    validDoubles = double.TryParse(Console.ReadLine(), out validDouble);
                    if (!validDoubles)
                    {
                        Console.WriteLine("Please enter a valid integer value.");

                    }
                }
                else
                {
                    validDoubles = double.TryParse(Console.ReadLine(), out validDouble);
                    if (!validDoubles)
                    {
                        
                        Console.WriteLine("Please enter a valid integer value");
                    }
                    else if (validDouble < minimumValue)
                    {
                        validDoubles = false;
                        Console.WriteLine($"Please enter an integer greater than {minimumValue}.");

                    }
                    else if (validDouble > maximumValue)
                    {
                        validDoubles = false;
                        Console.WriteLine($"Please enter an integer less than {maximumValue}.");
                    }
                }
            } while (!validDoubles);

            return validDouble;
        }

        /// <summary>
        /// validation for a valid integer
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="minimumValue"></param>
        /// <param name="maximumValue"></param>
        /// <param name="validInteger"></param>
        /// <returns>valid integer</returns>
        private static int GetValidInteger(string prompt, int minimumValue, int maximumValue, out int validInteger)
        {
            {
                bool validIntegers;

                do
                {
                    Console.Write(prompt);
                    if ((minimumValue == 0 && maximumValue == 0) || maximumValue - minimumValue == 0)
                    {
                        validIntegers = int.TryParse(Console.ReadLine(), out validInteger);
                        if (!validIntegers)
                        {
                            Console.WriteLine("Please enter a valid integer");
                        }
                    }
                    else
                    {
                        validIntegers = int.TryParse(Console.ReadLine(), out validInteger);
                        if (!validIntegers)
                        {
                            Console.WriteLine("Please enter a valid integer value");
                        }
                        else if (validInteger < minimumValue)
                        {
                            validIntegers = false;
                            Console.WriteLine($"Please enter an integer greater than {minimumValue}.");

                        }
                        else if (validInteger > maximumValue)
                        {
                            validIntegers = false;
                            Console.WriteLine($"Please enter an integer less than {maximumValue}.");
                        }
                    }
                } while (!validIntegers);

                return validInteger;
            }
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
        private static void DisplayWelcomeScreen()
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
