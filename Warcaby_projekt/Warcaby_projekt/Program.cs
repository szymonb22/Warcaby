﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace Warcaby_projekt
{
    class Program
    {
        
        static void Wybor()
        {
            Console.WriteLine("Wcisnij N aby zaczac Gre 1 na 1\n" +
                "Wcisnij M aby zagrac z komputerem"+"Wcisnij I aby zocaczyc instrukcja"+
                  "Wcisnij W aby wyjsc  z gry\n"
                );
            char wybór = Convert.ToChar(Console.ReadLine());


            switch (wybór)
            {
                case 'N':
                    NowaGra();
                    break;
                case 'I':
                    Instrukcja();
                    break;
                case 'M':
                    NowaGra();
                    break;
                case 'i':
                    Instrukcja(); 
                    break;
                default:
                    Console.WriteLine("Wcisnij N lub P");
                    break;
            }


        }
        static void Instrukcja()
        {
            Console.Write("Poruszanie :" +
                " Najpierw wybierz współrzedną pionową potem poziomą  oraz kierunek w która strone chcesz zrobic ruch l- lewo a p- prawo "
                + "Pamietaj aby zatwierdzic wspołrzedne enterem np 2" +
                "5" +
                "l");
        }

        static void Main(string[] args)
        {
            //Wybor();
            NowaGra();
            Console.ReadLine();
        }
        static void NowaGra()
        {
            int i, j, m, n, k, w;

            int g = 1;    // zmienna gracza
            int pionkiO = 0;
            int pionkiX = 0;

            char ruch;
            char[,] plansza =
           {
           { ' ','O',' ','O',' ','O',' ','O'},
           { 'O',' ','O',' ',' ',' ','O',' '},
           { ' ','O',' ','O',' ','O',' ','O'},
           { ' ',' ',' ',' ',' ',' ',' ',' '},
           { ' ','O',' ',' ',' ',' ',' ',' '},
           { 'X',' ','X',' ','X',' ','X',' '},
           { ' ','X',' ','X',' ','X',' ','X'},
           { 'X',' ','X',' ','X',' ','X',' '}
            };

            Console.WriteLine("Jestes graczem numer " + g);
            Console.WriteLine("Twoje pionki to X. Pionki gracza 2 to O");
            Console.WriteLine("  12345678 ");
            Console.WriteLine(" ==========");
            for (i = 0; i < 8; i++)
            {
                Console.Write("{0}|", i + 1);
                for (j = 0; j < 8; j++)
                {
                    if (plansza[i, j] == 'X' || plansza[i, j] == 'K')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        pionkiX++;
                    }
                    if (plansza[i, j] == 'O' || plansza[i, j] == 'D')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        pionkiO++;
                    }
                    Console.Write(plansza[i, j]);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("|");

            }
            Console.WriteLine(" ==========");

            while (true)
            {
                          
                while (g == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    k = 0; w = 1;
                    if (plansza[k, w] == 'X')
                        plansza[k, w] = 'K';                                           // zamiana pionka X na damke K
                    if (plansza[k, w + 2] == 'X')
                        plansza[k, w + 2] = 'K';
                    if (plansza[k, w + 4] == 'X')
                        plansza[k, w + 4] = 'K';
                    if (plansza[k, w + 6] == 'X')
                        plansza[k, w + 6] = 'K';
                    Console.ForegroundColor = ConsoleColor.White;


                    Console.WriteLine("Ruch Gracza 1");
                    g += 1;
                    Console.WriteLine("Wprowadz wspołrzedne np 1 2 i kieunek l-lewo p - prawo ,piewsza wspórzedna pionowa druga pozioma");



                    
                    
                        n = int.Parse(Console.ReadLine());//kolumna
                        m = int.Parse(Console.ReadLine()); //wiersz


                        n = n - 1;
                        m = m - 1;
                    ruch = Convert.ToChar(Console.ReadLine());




                    switch (ruch)
                    {
                        case 'l':
                            if (n >= 0 && m >= 0 && n < 10 && m < 10)
                            {
                                if (plansza[m, n] != 'X' && plansza[m, n] != 'K')
                                {             /* spr czy to twój pionek*/
                                    g = g - 1;
                                    Console.WriteLine("Nie twoj pionek!");
                                    break;
                                }
                                if (plansza[m, n] != 'K')
                                {
                                    plansza[m, n] = ' ';



                                    if (n - 2 >=0 && m - 2 >=0)
                                    {
                                        if (plansza[m -2, n - 2] == ' ' && plansza[m - 1, n - 1] == 'O' || plansza[m - 1, n - 1] == 'D')
                                        {

                                            // bicie w lewo
                                            plansza[m - 1, n - 1] = ' ';
                                            plansza[m - 2, n - 2] = 'X';
                                            pionkiO--;
                                        }
                                        else
                                        {
                                            if (plansza[--m, --n] != ' ')
                                            {   //sprawdza czy docelowe miejsce jest wolne
                                                g = g - 1;
                                                Console.WriteLine("Pole zajete");
                                                plansza[++m, ++n] = 'X';
                                                break;
                                            }
                                            else plansza[m, n] = 'X';

                                        }
                                    }

                                    else
                                    {
                                        if (plansza[--m, --n] != ' ')
                                        {   //sprawdza czy docelowe miejsce jest wolne
                                            g = g - 1;
                                            Console.WriteLine("Pole zajete");
                                            plansza[++m, ++n] = 'X';
                                            break;
                                        }
                                        else plansza[m, n] = 'X';

                                    }

                                }
                                else
                                {
                                    plansza[m, n] = ' ';
                                    if (n - 2 >= 0&& n-1>=0)
                                    {
                                        if (plansza[m + 2, n - 2] == ' ' && plansza[m + 1, n - 1] == 'O' || plansza[m + 1, n - 1] == 'D')
                                        {     // bicie w lewo przez damke K
                                            plansza[m + 1, n - 1] = ' ';
                                            plansza[m + 2, n - 2] = 'K';
                                            pionkiO--;

                                        }
                                        else
                                        {
                                            if (plansza[++m, ++n] != ' ')
                                            {
                                                g = g - 1;
                                                Console.WriteLine("Pole zajete");
                                                plansza[--m, --n] = 'K';
                                                break;
                                            }
                                            else plansza[m, n] = 'K';
                                        }
                                    }
                                    else
                                    {
                                        if (plansza[++m, --n] != ' ')
                                        {
                                            g = g - 1;
                                            Console.WriteLine("Pole zajete");
                                            plansza[--m, --n] = 'K';
                                            break;
                                        }
                                        else plansza[m - 1, n + 1] = 'K';
                                    }

                                }
                            }
                            else
                            {
                                g = g - 1;
                                Console.WriteLine("Zly ruch");
                            }
                            k = 0; w = 1;
                            if (plansza[k, w] == 'X')
                                plansza[k, w] = 'K';                                           // zamiana pionka X na damke K
                            if (plansza[k, w + 2] == 'X')
                                plansza[k, w + 2] = 'K';
                            if (plansza[k, w + 4] == 'X')
                                plansza[k, w + 4] = 'K';
                            if (plansza[k, w + 6] == 'X')
                                plansza[k, w + 6] = 'K';


                            Console.WriteLine("  12345678 ");
                            Console.WriteLine(" ==========");
                            for (i = 0; i < 8; i++)
                            {
                                Console.Write("{0}|", i + 1);
                                for (j = 0; j < 8; j++)
                                {
                                    if (plansza[i, j] == 'X')
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                    }
                                    if (plansza[i, j] == 'O')
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                    }
                                    Console.Write(plansza[i, j]);
                                }
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("|");

                            }
                            Console.WriteLine(" ==========");
                            break;
                        case 'p':
                            if (n > -1 && m > -1 && n < 7 && m < 8)
                            {

                                if (plansza[m, n] != 'X' && plansza[m, n] != 'K')
                                {
                                    g = g - 1;
                                    Console.WriteLine("Nie twoj pionek!");
                                    break;
                                }
                                if (plansza[m, n] != 'K')
                                {
                                    plansza[m, n] = ' ';

                                    if (n + 2 < 8 && n + 2 >= 0 && m - 2 >= 0)
                                    {
                                        if (plansza[m - 2, n + 2] == ' ' && plansza[m - 1, n + 1] == 'O'|| plansza[m - 1, n + 1] == 'D')
                                        {
                                            plansza[m - 1, n + 1] = ' ';              //bicie   w prawo
                                            plansza[m - 2, n + 2] = 'X';
                                            pionkiO--;
                                        }
                                        else
                                        {
                                            if (plansza[--m, ++n] != ' ' && plansza[m, n] != 'K')
                                            {
                                                g = g - 1;
                                                Console.WriteLine("Pole zajete");
                                                plansza[++m, --n] = 'X';
                                                break;
                                            }
                                            else plansza[m, n] = 'X';
                                        }

                                    }

                                    else
                                    {
                                        if (plansza[--m, ++n] != ' ' && plansza[m, n] != 'K')
                                        {
                                            g = g - 1;
                                            Console.WriteLine("Pole zajete");
                                            plansza[++m, --n] = 'X';
                                            break;
                                        }
                                        else plansza[m, n] = 'X';
                                    }


                                }
                                else
                                {
                                    plansza[m, n] = ' ';
                                    if (n + 2 < 8 && m + 2 < 8)
                                    {
                                        if (plansza[m + 2, n + 2] == ' ' && plansza[m + 1, n + 1] == 'O' || plansza[m + 1, n + 1] == 'D')
                                        {
                                            plansza[m + 1, n + 1] = ' ';              //bicie przez damke K w prawo
                                            plansza[m + 2, n + 2] = 'K';
                                            pionkiO--;
                                        }
                                        else
                                        {
                                            if (plansza[++m, ++n] != ' ')
                                            {
                                                g = g - 1;
                                                Console.WriteLine("Pole zajete");
                                                plansza[--m, --n] = 'K';
                                                break;
                                            }
                                            else plansza[m, n] = 'K';
                                        }
                                    }
                                    else
                                    {
                                        if (plansza[++m, ++n] != ' ')
                                        {
                                            g = g - 1;
                                            Console.WriteLine("Pole zajete");
                                            plansza[--m, --n] = 'K';
                                            break;
                                        }
                                        else plansza[m, n] = 'K';

                                    }
                                }
                            }
                            
                            else
                            {
                                g = g - 1;
                                Console.WriteLine("Zly ruch");
                            }
                            k = 0; w = 1;
                            if (plansza[k, w] == 'X')
                                plansza[k, w] = 'K';                                           // zamiana pionka X na damke K
                            if (plansza[k, w + 2] == 'X')
                                plansza[k, w + 2] = 'K';
                            if (plansza[k, w + 4] == 'X')
                                plansza[k, w + 4] = 'K';
                            if (plansza[k, w + 6] == 'X')
                                plansza[k, w + 6] = 'K';

                            Console.WriteLine("  12345678 ");
                            Console.WriteLine(" ==========");
                            for (i = 0; i < 8; i++)
                            {
                                Console.Write("{0}|", i + 1);
                                for (j = 0; j < 8; j++)
                                {
                                    if (plansza[i, j] == 'X')
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                    }
                                    if (plansza[i, j] == 'O')
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                    }
                                    Console.Write(plansza[i, j]);
                                }
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("|");

                            }
                            Console.WriteLine(" ==========");
                            
                            break;
                        default:
                            g = g - 1;
                            Console.WriteLine("Wpisz poprawne polecenie");
                            break;
                    }

                }
                if (pionkiO == 0)
                {
                    Console.WriteLine("Wygrywa Gracz 1");

                    Wybor();
                }
                g = 1;
                while (g == 2)
                {


                    Console.WriteLine("Ruch gracza 2");
                    g = g - 1;
                    Console.WriteLine("Wprowadz wspołrzedne np 1 2 i kieunek l-lewo p - prawo ,piewsza wspórzedna pionowa druga pozioma");
                    n = int.Parse(Console.ReadLine());
                    n = n - 1;
                    m = int.Parse(Console.ReadLine());
                    m = m - 1;
                    ruch = Convert.ToChar(Console.ReadLine());

                    switch (ruch)
                    {
                        case 'l':
                            if (n > -1 && m > -1 && n < 8 && m < 8)                             {
                                if (plansza[m, n] != 'O' && plansza[m, n] != 'D')
                                {
                                    g = g + 1;
                                    Console.WriteLine("Nie twoj pionek!");
                                    break;
                                }
                                if (plansza[m, n] != 'D')
                                {
                                    plansza[m, n] = ' ';
                                    if (m + 2 < 8 && n - 2 >= 0 && m + 1 < 8 && n - 1 >= 0)
                                    {
                                        if (plansza[m + 2, n - 2] == ' ' && plansza[m + 1, n - 1] == 'X' || plansza[m + 1, n - 1] == 'K')
                                        {
                                            plansza[m + 1, n - 1] = ' ';             //bicie  w lewo
                                            plansza[m + 2, n - 2] = 'O';
                                            pionkiX--;
                                        }
                                        else
                                        {
                                            if (plansza[++m, --n] != ' ')
                                            {
                                                g = g + 1;
                                                Console.WriteLine("Pole zajete");
                                                plansza[--m, ++n] = 'O'; //sprawdzenie czy pole jest wolne
                                                break;
                                            }
                                            else
                                                plansza[m, n] = 'O';
                                        }
                                    }
                                    else
                                    {
                                        if (plansza[++m, --n] != ' ')
                                        {
                                            g = g + 1;
                                            Console.WriteLine("Pole zajete");
                                            plansza[--m, ++n] = 'O'; //sprawdzenie czy pole jest wolne
                                            break;
                                        }
                                        else
                                            plansza[m, n] = 'O';
                                    }
                                }
                                else
                                {
                                    plansza[m, n] = ' ';
                                    if (n - 2 > 0)
                                    {
                                        if (plansza[m - 2, n - 2] == ' ' && plansza[m - 1, n - 1] == 'X' || plansza[m - 1, n - 1] == 'K') 
                                        {
                                            plansza[m - 1, n - 1] = ' ';             //bicie prez damke w lewo
                                            plansza[m - 2, n - 2] = 'D';
                                            pionkiX--;
                                        }
                                        else
                                        {
                                            if (plansza[--m, --n] != ' ')
                                            {
                                                g = g + 1;
                                                Console.WriteLine("Pole zajete");
                                                plansza[--m, ++n] = 'D'; // sprawdzenie czy pole jest wolne
                                                break;
                                            }
                                            else
                                                plansza[m, n] = 'D';
                                        }
                                    }
                                    else
                                    {
                                        if (plansza[--m, --n] != ' ')
                                        {
                                            g = g + 1;
                                            Console.WriteLine("Pole zajete");
                                            plansza[--m, ++n] = 'D'; // sprawdzenie czy pole jest wolne
                                            break;
                                        }
                                        else
                                            plansza[m, n] = 'D';

                                    }

                                }
                            }
                            else
                            {
                                g = g + 1;
                                Console.WriteLine("Zly ruch");
                            }
                            k = 7; w = 0;
                            Console.ForegroundColor = ConsoleColor.Green;
                            if (plansza[k, w] == 'O')
                                plansza[k, w] = 'D';
                            if (plansza[k, w | +2] == 'O')                                     // zamiana pionka O na damke D
                                plansza[k, w + 2] = 'D';
                            if (plansza[k, w + 4] == 'O')
                                plansza[k, w + 4] = 'D';
                            if (plansza[k, w + 6] == 'O')
                                plansza[k, w + 6] = 'D';
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("  12345678 ");
                            Console.WriteLine(" ==========");
                            for (i = 0; i < 8; i++)
                            {
                                Console.Write("{0}|", i + 1);
                                for (j = 0; j < 8; j++)
                                {
                                    if (plansza[i, j] == 'X')
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                    }
                                    if (plansza[i, j] == 'O')
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                    }
                                    Console.Write(plansza[i, j]);
                                }
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("|");

                            }
                            Console.WriteLine(" ==========");

                            break;
                        case 'p':
                            if (n > -1 && m > -1 && n < 7 && m < 8)
                            {
                                if (plansza[m, n] != 'O' && plansza[m, n] != 'D')
                                {
                                    g = g + 1;
                                    Console.WriteLine("Nie twoj pionek!");
                                    break;
                                }
                                if (plansza[m, n] != 'D')
                                {
                                    plansza[m, n] = ' ';
                                    if (n + 2 < 8)
                                    {
                                        if (plansza[m + 2, n + 2] == ' ' && plansza[m + 1, n + 1] == 'X'|| plansza[m + 1, n + 1] == 'K')
                                        {
                                            plansza[m + 1, n + 1] = ' ';                 //bicie w prawo
                                            plansza[m + 2, n + 2] = 'O';
                                            pionkiX--;
                                        }
                                        else
                                        {
                                            if (plansza[++m, ++n] != ' ')
                                            {
                                                g = g + 1;
                                                Console.WriteLine("Pole zajete");
                                                plansza[--m, --n] = 'O';
                                                break;
                                            }
                                            else plansza[m, n] = 'O';
                                        }
                                    }
                                    else
                                    {
                                        if (plansza[++m, ++n] != ' ')
                                        {
                                            g = g + 1;
                                            Console.WriteLine("Pole zajete");
                                            plansza[--m, --n] = 'O';
                                            break;
                                        }
                                        else plansza[m, n] = 'O';
                                    }

                                }
                                else
                                {
                                    plansza[m, n] = ' ';
                                    if (plansza[m, n + 1] == ' ' && plansza[m - 1, n + 1] == 'X'|| plansza[m - 1, n + 1] == 'K') 
                                    {
                                        plansza[m - 1, n + 1] = ' ';                 //bicie przez damke w prawo
                                        plansza[m - 2, n + 2] = 'D';
                                        pionkiX--;
                                    }
                                    else
                                    {
                                        if (plansza[m, ++n] != ' ')
                                        {
                                            g = g + 1;
                                            Console.WriteLine("Pole zajete");
                                            plansza[--m, --n] = 'O';
                                            break;
                                        }
                                        else plansza[--m, n] = 'D';
                                    }
                                }
                            }
                            else
                            {
                                g = g + 1;
                                Console.WriteLine("Zly ruch");
                            }
                            k = 7; w = 0;

                            if (plansza[k, w] == 'O')
                                plansza[k, w] = 'D';
                            if (plansza[k, w | +2] == 'O')                                     // zamiana pionka O na damke D
                                plansza[k, w + 2] = 'D';
                            if (plansza[k, w + 4] == 'O')
                                plansza[k, w + 4] = 'D';
                            if (plansza[k, w + 6] == 'O')
                                plansza[k, w + 6] = 'D';
                            Console.WriteLine("  12345678 ");
                            Console.WriteLine(" ==========");
                            for (i = 0; i < 8; i++)
                            {
                                Console.Write("{0}|", i + 1);
                                for (j = 0; j < 8; j++)
                                {
                                    if (plansza[i, j] == 'X')
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                    }
                                    if (plansza[i, j] == 'O')
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                    }
                                    Console.Write(plansza[i, j]);
                                }
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("|");

                            }
                            Console.WriteLine(" ==========");

                            break;
                        default:
                            g = g + 1;
                            Console.WriteLine("Wpisz poprawne polecenie");
                            break;
                    }
                }

                if (pionkiX == 0)
                {
                    Console.WriteLine("Wygrywa Gracz 2");
                    Wybor();
                }



            }

        }

    }

}