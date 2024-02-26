﻿using System;
struct Shaxmatisti
{
    public string lastname;
    public double result1, result2, result3, result4, result5, summ;
    public Shaxmatisti(string ln, double r1, double r2, double r3, double r4, double r5)
    {
        lastname = ln;
        result1 = r1;
        result2 = r2;
        result3 = r3;
        result4 = r4;
        result5 = r5;
        summ = r1 + r2 + r3 + r4 + r5;
    }

    class Programm
    {
        static void sortirovka(Shaxmatisti[] shaxmatistis)
        {
            for (int i = 0; i < shaxmatistis.Length; i++)
            {
                for (int j = 0; j < shaxmatistis.Length - i - 1; j++)
                {
                    if (shaxmatistis[j].summ < shaxmatistis[j + 1].summ)
                    {
                        Shaxmatisti t = shaxmatistis[j];
                        shaxmatistis[j] = shaxmatistis[j + 1];
                        shaxmatistis[j + 1] = t;
                    }
                }
            }
        }
        static void PrintSha(Shaxmatisti[] shaxmatistis)
        {
            Console.WriteLine("Фамилия  r1   r2      r3      r4       r5    summ");
            for (int i = 0; i < shaxmatistis.Length; i++)
            {
                Console.WriteLine($"{shaxmatistis[i].lastname,-8} {shaxmatistis[i].result1,-5} {shaxmatistis[i].result2,-5}  {shaxmatistis[i].result3,-5}  {shaxmatistis[i].result4,-8}  {shaxmatistis[i].result5,-5} {shaxmatistis[i].summ}");
            }
        }
        static void Main()
        {
            Shaxmatisti[] shaxmatistis = {
            new Shaxmatisti("Карякин",0,0.5,0,1,0),
            new Shaxmatisti("Карлсен",1,1,1,0.5,0),
            new Shaxmatisti("Дубов",1,0,0.5,0.5,1),
            new Shaxmatisti("Nepo",1,1,0.5,0.5,0),
            new Shaxmatisti("Таль",0.5,1,0,0,1),
        };
            sortirovka(shaxmatistis);
            PrintSha(shaxmatistis);
        }

    }
}