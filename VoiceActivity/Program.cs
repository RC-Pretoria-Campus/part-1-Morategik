using System;

using System.Speech.Synthesis;

using System.Threading;



namespace VoiceActivity

{

    class Program

    {

        static SpeechSynthesizer synthesizer = new SpeechSynthesizer();



        static void Main()

        {

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Initializing chatbot...\n");

            Console.ResetColor();



            SpeakGreeting();

            DisplayAsciiLogo();

            ChatbotInteraction();

        }



        #region Text-to-Speech Greeting  

        static void SpeakGreeting()

        {

            string greeting = "Hello! Welcome to the Cybersecurity Awareness Chatbot.";

            synthesizer.Speak(greeting);

            PrintMessage("Chatbot", greeting, ConsoleColor.Green);

        }

        #endregion



        #region ASCII Logo  

        static void DisplayAsciiLogo()

        {

            Console.ForegroundColor = ConsoleColor.DarkCyan;

            Console.WriteLine(@" 
___ ___   ___   ____    ____  ______    ___   ____  ____  __   _____
|   |   | /   \ |    \  /    ||      |  /  _] /    ||    ||  | / ___/
| _   _ ||     ||  D  )|  o  ||      | /  [_ |   __| |  | |_ |(   \_ 
|  \_/  ||  O  ||    / |     ||_|  |_||    _]|  |  | |  |   \| \__  |
|   |   ||     ||    \ |  _  |  |  |  |   [_ |  |_ | |  |      /  \ |
|   |   ||     ||  .  \|  |  |  |  |  |     ||     | |  |      \    |
|___|___| \___/ |__|\_||__|__|  |__|  |_____||___,_||____|      \___|
                                                                     
    __  __ __   ____  ______  ____    ___   ______                   
   /  ]|  |  | /    ||      ||    \  /   \ |      |                  
  /  / |  |  ||  o  ||      ||  o  )|     ||      |                  
 /  /  |  _  ||     ||_|  |_||     ||  O  ||_|  |_|                  
/   \_ |  |  ||  _  |  |  |  |  O  ||     |  |  |                    
\     ||  |  ||  |  |  |  |  |     ||     |  |  |                    
 \____||__|__||__|__|  |__|  |_____| \___/   |__|                    
                                                                  

            ");

            Console.ResetColor();

            Console.WriteLine("=======================================================\n");

        }

        #endregion



        #region Chatbot Interaction 

        static void ChatbotInteraction()

        {

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write("Enter your name: ");

            Console.ResetColor();



            string userName = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(userName))

            {

                userName = "Guest";

            }



            string greetingMessage = $"Hello {userName}! How can I assist you with cybersecurity today?";

            synthesizer.Speak(greetingMessage);

            PrintMessage("Chatbot", greetingMessage, ConsoleColor.Green);

            PrintMessage("Chatbot", "Type 'help' to see available topics or 'exit' to quit.\n", ConsoleColor.Green);



            while (true)

            {

                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.Write("\nYou: ");

                Console.ResetColor();



                string userInput = Console.ReadLine()?.Trim().ToLower();



                if (string.IsNullOrWhiteSpace(userInput))

                {

                    PrintMessage("Chatbot", "Oops! You didn't type anything. Try asking about 'password safety' or 'phishing'.", ConsoleColor.Red);

                    continue;

                }



                ShowLoading(); // Simulates processing before responding 



                string response = GetChatbotResponse(userInput);

                synthesizer.Speak(response);

                PrintMessage("Chatbot", response, ConsoleColor.Green);



                if (userInput == "exit")

                {

                    return;

                }

            }

        }

        #endregion



        #region Chatbot Responses 

        static string GetChatbotResponse(string userInput)

        {

            switch (userInput)

            {

                case "how are you":

                    return "I'm just a bot, but I'm here to help you stay safe online!";



                case "what’s your purpose":

                case "what is your purpose":

                    return "I help users learn about cybersecurity safety practices.";



                case "help":

                    return "You can ask me about 'password safety', 'phishing', or 'safe browsing'.";



                case "password safety":

                    return "Use strong passwords with a mix of uppercase, lowercase, numbers, and symbols.";



                case "phishing":

                    return "Never click on suspicious links or emails from unknown sources.";



                case "safe browsing":

                    return "Always ensure websites use HTTPS before entering sensitive data.";



                case "exit":

                    return "Goodbye! Stay safe online.";



                default:

                    return "Sorry, I didn't understand that. Type 'help' for options.";

            }

        }

        #endregion



        #region UI Enhancements 

        static void PrintMessage(string speaker, string message, ConsoleColor color)

        {

            Console.ForegroundColor = color;

            Console.WriteLine($"{speaker}: {message}");

            Console.ResetColor();

        }



        static void ShowLoading(int dots = 3)

        {

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write("Chatbot is thinking");

            for (int i = 0; i < dots; i++)

            {

                Thread.Sleep(500);

                Console.Write(".");

            }

            Console.WriteLine("\n");

            Console.ResetColor();

        }

        #endregion

    }

}