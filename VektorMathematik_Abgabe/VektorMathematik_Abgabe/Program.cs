using System;

namespace VektorMathematik_Abgabe
{
    class Program
    {
        static void Main(string[] args)
        {
            VektorMathematikAusgabe();
            EingabeVektorWerte();
            ZeigeAuswahlmenü();
        }

        // Methode zur Ausgabe des Namens "Vektor Mathematik"
        static void VektorMathematikAusgabe()
        {
            Console.WriteLine("Vektor Mathematik");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Press any key to exit the game");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
        }

        // Methode zur Eingabe von Werten für Vektoren 1 und 2
        static void EingabeVektorWerte()
        {
            Vektor vektor1 = new Vektor();
            Vektor vektor2 = new Vektor();

            Console.WriteLine("Bitte geben Sie die Werte für Vektor 1 ein:");
            Console.WriteLine();

            // Eingabe und Überprüfung für Vektor 1
            Console.Write("x-Wert: ");
            vektor1.x = GetValidIntegerInput();
            Console.WriteLine();

            Console.Write("y-Wert: ");
            vektor1.y = GetValidIntegerInput();
            Console.WriteLine();

            Console.Write("z-Wert: ");
            vektor1.z = GetValidIntegerInput();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Bitte geben Sie die Werte für Vektor 2 ein:");
            Console.WriteLine();

            // Eingabe und Überprüfung für Vektor 2
            Console.Write("x-Wert: ");
            vektor2.x = GetValidIntegerInput();
            Console.WriteLine();

            Console.Write("y-Wert: ");
            vektor2.y = GetValidIntegerInput();
            Console.WriteLine();

            Console.Write("z-Wert: ");
            vektor2.z = GetValidIntegerInput();
            Console.WriteLine();
            Console.Clear();

            Console.WriteLine("Vielen Dank! Sie haben die Werte für beide Vektoren erfolgreich eingegeben.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Press any key to exit the game");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
        }

        // Hilfsmethode zur Eingabe und Überprüfung ganzer Zahlen
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
                    Console.WriteLine("Ungültige Eingabe. Bitte gebe nur Positive Ganzzahlen sowie Zahlen im Bereich von 0-100 ein:");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Drücken Sie eine beliebige Taste, um fortzufahren.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    Console.Clear(); // Löschen der Konsole

                    // Erneute Eingabeaufforderung ohne vorherige Aufforderungen
                    Console.WriteLine("Bitte geben Sie die Werte erneut ein:");
                    Console.WriteLine();
                    Console.Write("x-Wert: ");
                }
                else
                {
                    break; // Verlassen der Schleife bei gültiger Eingabe
                }
            }
            return value;
        }

        // Methode zum Anzeigen des Auswahlmenüs
        static void ZeigeAuswahlmenü()
        {
            List<string> options = new List<string>
            {
                "1. Addition von Vektoren",
                "2. Subtraktion von Vektoren",
                "3. Multiplikation eines Vektors mit einem Skalar",
                "4. Berechnung der Distanz zwischen zwei Vektoren",
                "5. Berechnung der Länge eines Vektors",
                "6. Berechnung der Quadratlänge eines Vektors",
                "7. Exit"
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
                        break; // Exit aus dem Menü
                    }
                    else
                    {
                        // Hier wird die ausgewählte Option verarbeitet
                        VerarbeiteAuswahl(selectedIndex + 1);
                    }
                }
            }
        }

        // VerarbeiteAuswahl-Methode
        static void VerarbeiteAuswahl(int option)
        {
            Vektor vektor1 = new Vektor(); // Vektor 1 initialisieren
            Vektor vektor2 = new Vektor(); // Vektor 2 initialisieren

            switch (option)
            {
                case 1:
                    // Code für Addition von Vektoren
                    Vektor vektorSumme = vektor1 + vektor2;
                    Console.WriteLine($"Die Summe der Vektoren ist: ({vektorSumme.x}, {vektorSumme.y}, {vektorSumme.z})");
                    break;
                case 2:
                    // Code für Subtraktion von Vektoren
                    Vektor vektorDifferenz = vektor1 - vektor2;
                    Console.WriteLine($"Die Differenz der Vektoren ist: ({vektorDifferenz.x}, {vektorDifferenz.y}, {vektorDifferenz.z})");
                    break;
                case 3:
                    // Code für Multiplikation eines Vektors mit einem Skalar
                    Console.WriteLine("Bitte geben Sie einen Skalarwert ein:");
                    int skalar = GetValidIntegerInput();
                    Vektor vektorProdukt = vektor1 * skalar;
                    Console.WriteLine($"Das Produkt des Vektors mit dem Skalar ist: ({vektorProdukt.x}, {vektorProdukt.y}, {vektorProdukt.z})");
                    break;
                case 4:
                    // Code für Berechnung der Distanz zwischen zwei Vektoren
                    float distanz = Vektor.Distance(vektor1, vektor2);
                    Console.WriteLine($"Die Distanz zwischen den Vektoren beträgt: {distanz}");
                    break;
                case 5:
                    // Code für Berechnung der Länge eines Vektors
                    float laenge = vektor1.Length();
                    Console.WriteLine($"Die Länge des Vektors beträgt: {laenge}");
                    break;
                case 6:
                    // Code für Berechnung der Quadratlänge eines Vektors
                    float quadratLaenge = vektor1.SquareLength();
                    Console.WriteLine($"Die Quadratlänge des Vektors beträgt: {quadratLaenge}");
                    break;
                default:
                    break;
            }
        }
    }
}