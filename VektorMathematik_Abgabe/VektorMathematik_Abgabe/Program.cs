using System;
using System.Collections.Generic;

namespace VektorMathematik_Abgabe
{
    class Program
    {
        static void Main(string[] args)
        {
            StartScreen();
            ShowSelectionMenu();
        }

        /// <summary>
        /// Methode zur Ausgabe des Namens "Vektor Mathematik"
        /// </summary>
        #region StartScreen
        static void StartScreen()
        {
            Console.WriteLine("Vektor Mathematik");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Press any key to exit the game");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
        }
        #endregion

        /// <summary>
        /// Methode zum Anzeigen des Auswahlmenüs und Verarbeiten der auswahl
        /// </summary>
        #region ShowSelectionMenu 
        static void ShowSelectionMenu()
        {
            List<string> options = new List<string>
            {
                "1. addition of vectors",
                "2. subtraction of vectors",
                "3. multiplication of a vector by a scalar",
                "4. calculating the distance between two vectors",
                "5. calculating the length of a vector",
                "6. calculating the square length of a vector",
                "7. exit"
            };

            int selectedIndex = 0;
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < options.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.WriteLine(options[i]);
                    Console.ResetColor();
                }

                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex - 1 + options.Count) % options.Count;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex + 1) % options.Count;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    if (selectedIndex == options.Count - 1)
                    {
                        break;
                    }
                    else
                    {
                        ProcessSelect(selectedIndex + 1);
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// Methode zur Verarbeitung der vom Benutzer ausgewählten Option.
        /// </summary>
        /// <param name="option">Die ausgewählte Option.</param>
        #region ProcessSelect
        static void ProcessSelect(int option)
        {
            switch (option)
            {
                case 1:
                    // Addition von Vektoren
                    InputVectorValues('+');
                    break;
                case 2:
                    // Subtraktion von Vektoren
                    InputVectorValues('-');
                    break;
                case 3:
                    // Multiplikation eines Vektors mit einem Skalar
                    InputVectorValues('*');
                    break;
                case 4:
                    // Berechnung der Distanz zwischen zwei Vektoren
                    InputVectorValues('d');
                    break;
                case 5:
                    // Berechnung der Länge eines Vektors
                    InputVectorValues('l');
                    break;
                case 6:
                    // Berechnung der Quadratlänge eines Vektors
                    InputVectorValues('q');
                    break;
                default:
                    break;
            }
        }
        #endregion

        /// <summary>
        /// Methode zur Eingabe von Werten für Vektoren und Durchführung der entsprechenden Operation.
        /// </summary>
        /// <param name="operation">Die ausgewählte Operation (+, -, *, d, l, q).</param>
        #region InputVectorValues
        static void InputVectorValues(char operation)
        {
            Vektor vektor1 = new Vektor();
            Vektor vektor2 = new Vektor();

            Console.WriteLine("Please enter the values for vector 1:");
            Console.WriteLine();

            // Hier wird die Eingabe von Vektor 1 gemacht und Überprüft
            Console.Write("x-Value: ");
            vektor1.x = GetValidIntegerInput();
            Console.WriteLine();

            Console.Write("y-Value: ");
            vektor1.y = GetValidIntegerInput();
            Console.WriteLine();

            Console.Write("z-Value: ");
            vektor1.z = GetValidIntegerInput();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Please enter the values for vector 2:");
            Console.WriteLine();

            // Hier wird die Eingabe von Vektor 2 gemacht und Überprüft
            Console.Write("x-Value: ");
            vektor2.x = GetValidIntegerInput();
            Console.WriteLine();

            Console.Write("y-Value: ");
            vektor2.y = GetValidIntegerInput();
            Console.WriteLine();

            Console.Write("z-Value: ");
            vektor2.z = GetValidIntegerInput();
            Console.WriteLine();
            Console.Clear();

            // Hier wird je nach Auswahl die entsprechende Operation durchgeführt
            switch (operation)
            {
                case '+':
                    Vektor vektorSumme = vektor1 + vektor2;
                    Console.WriteLine($"Die Summe der Vektoren ist: ({vektorSumme.x}, {vektorSumme.y}, {vektorSumme.z})");
                    break;
                case '-':
                    Vektor vektorDifferenz = vektor1 - vektor2;
                    Console.WriteLine($"Die Differenz der Vektoren ist: ({vektorDifferenz.x}, {vektorDifferenz.y}, {vektorDifferenz.z})");
                    break;
                case '*':
                    Console.WriteLine("Bitte geben Sie einen Skalarwert ein:");
                    int skalar = GetValidIntegerInput();
                    Vektor vektorProdukt = vektor1 * skalar;
                    Console.WriteLine($"Das Produkt des Vektors mit dem Skalar ist: ({vektorProdukt.x}, {vektorProdukt.y}, {vektorProdukt.z})");
                    break;
                case 'd':
                    float distanz = Vektor.Distance(vektor1, vektor2);
                    Console.WriteLine($"Die Distanz zwischen den Vektoren beträgt: {distanz}");
                    break;
                case 'l':
                    float laenge = vektor1.Length();
                    Console.WriteLine($"Die Länge des Vektors beträgt: {laenge}");
                    break;
                case 'q':
                    float quadratLaenge = vektor1.SquareLength();
                    Console.WriteLine($"Die Quadratlänge des Vektors beträgt: {quadratLaenge}");
                    break;
                default:
                    break;
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Press any key to exit the game");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
        }
        #endregion

        /// <summary>
        /// Das ist eine Hilfsmethode zur Eingabe und Überprüfung ganzer Zahlen im Bereich von 0 bis 100.
        /// </summary>
        /// <returns>Die gültige eingegebene Ganzzahl.</returns>
        #region GetValidIntegerInput
        static int GetValidIntegerInput()
        {
            int value = 0; // Initialisierung der Variable
            while (true)
            {
                string input = Console.ReadLine();
                if (!int.TryParse(input, out value) || value < 0 || value > 100)
                {
                    Console.Clear(); // Löschen der Konsole
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine positive Ganzzahl im Bereich von 0-100 ein:");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Drücken Sie eine beliebige Taste, um fortzufahren.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    Console.Clear(); // Löschen der Konsole

                    // Erneute Eingabeaufforderung ohne vorherige Aufforderungen
                    Console.WriteLine("Bitte geben Sie den Wert erneut ein:");
                    Console.WriteLine();
                    Console.Write("Wert: ");
                }
                else
                {
                    break; // Verlassen der Schleife bei gültiger Eingabe
                }
            }
            return value;
        }
        #endregion
    }
}
