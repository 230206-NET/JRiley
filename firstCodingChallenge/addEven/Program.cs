using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        Console.Write("Enter a: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter b: ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Enter c: ");
        int c = int.Parse(Console.ReadLine());
        int total = 0;
        
        if (a % 2 == 0){
            total += a;
        }
        else {
            total -= a;
        }

        if(b %2 == 0){
            total += b;
        }
        else total -= b;

        if(c % 2 == 0){
            total += c;
        }
        else {
            total -= c;
        }
        
        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(total);
        
    }

}