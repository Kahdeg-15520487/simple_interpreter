﻿using System;
using System.Collections.Generic;
using System.IO;

namespace simple_interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Dictionary<string, int> variables = new Dictionary<string, int>();
                Interpreter interpreter = new Interpreter(variables);
                while (true)
                {
                    Console.Write("calc> ");
                    string text = Console.ReadLine();
                    Lexer lexer = new Lexer(text);
                    Parser parser = new Parser(lexer);
                    try
                    {
                        var result = parser.Parse();
                        result.Accept(interpreter);
                        Console.WriteLine(interpreter.Output);

                        //DotVisualizer dotvisitor = new DotVisualizer();
                        //result.Accept(dotvisitor);
                        //File.WriteAllText("ast.dot", dotvisitor.Output);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            else
            {
                Dictionary<string, int> variables = new Dictionary<string, int>();
                Interpreter interpreter = new Interpreter(variables);
                //var text = File.ReadAllText(args[0]);
                foreach (var text in File.ReadLines(args[0]))
                {
                    Lexer lexer = new Lexer(text);
                    Parser parser = new Parser(lexer);
                    try
                    {
                        var result = parser.Parse();
                        result.Accept(interpreter);
                        Console.WriteLine(interpreter.Output);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}