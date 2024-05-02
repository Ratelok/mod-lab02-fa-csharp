using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
    public class State
    {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;
    }
    public class FA1
    {
        public static State a = new State()
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State b = new State()
        {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State c = new State()
        {
            Name = "c",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = a;

        public FA1()
        {
            a.Transitions['0'] = a;
            a.Transitions['1'] = b;
            b.Transitions['0'] = c;
            b.Transitions['1'] = a;
            c.Transitions['0'] = b;
            c.Transitions['1'] = c;
        }

        public bool? Run(IEnumerable<char> s)
        {
            int count0 = 0;
            int count1 = 0;
            State current = InitialState;
            foreach (var c in s) // цикл по всем символам 
            {
                current = current.Transitions[c]; // меняем состояние на то, в которое у нас переход
                if (current == null)              // если его нет, возвращаем признак ошибки
                    return null;
                if (c == '0')
                    count0++;
                else
                    count1++;
                //Иначе переходим к следующему
            }
            return count0 == 1 && count1 >= 1;         // результат true если в конце финальное состояние 
        }
    }

    public class FA2
    {
        public static State a = new State()
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State b = new State()
        {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State c = new State()
        {
            Name = "c",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = a;

        public FA2()
        {
            a.Transitions['0'] = a;
            a.Transitions['1'] = b;
            b.Transitions['0'] = c;
            b.Transitions['1'] = a;
            c.Transitions['0'] = b;
            c.Transitions['1'] = c;
        }

        public bool? Run(IEnumerable<char> s)
        {
            int count0 = 0;
            int count1 = 0;
            State current = InitialState;
            foreach (var c in s) // цикл по всем символам 
            {
                current = current.Transitions[c]; // меняем состояние на то, в которое у нас переход
                if (current == null)              // если его нет, возвращаем признак ошибки
                    return null;
                if (c == '0')
                    count0++;
                else
                    count1++;
                //Иначе переходим к следующему
            }
            return count0 % 2 != 0 && count1 % 2 != 0;         // результат true если в конце финальное состояние 
        }
    }

    public class FA3
    {
        public static State a = new State()
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State b = new State()
        {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State c = new State()
        {
            Name = "c",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        public static State InitialState = a;

        public FA3()
        {
            a.Transitions['0'] = a;
            a.Transitions['1'] = b;
            b.Transitions['0'] = a;
            b.Transitions['1'] = c;
            c.Transitions['0'] = c;
            c.Transitions['1'] = c;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            // FA1 tests
            String s1 = "0111";
            FA1 fa1 = new FA1();
            bool? result1 = fa1.Run(s1);
            Console.WriteLine("Expected: True, Actual: " + result1);

            String s2 = "01011";
            FA1 fa2 = new FA1();
            bool? result2 = fa2.Run(s2);
            Console.WriteLine("Expected: False, Actual: " + result2);

            String s3 = "110101011";
            FA1 fa3 = new FA1();
            bool? result3 = fa3.Run(s3);
            Console.WriteLine("Expected: False, Actual: " + result3);

            String s4 = "1110111";
            FA1 fa4 = new FA1();
            bool? result4 = fa4.Run(s4);
            Console.WriteLine("Expected: True, Actual: " + result4);

            String s5 = "10";
            FA1 fa5 = new FA1();
            bool? result5 = fa5.Run(s5);
            Console.WriteLine("Expected: True, Actual: " + result5);

            // FA2 tests
            String s6 = "0101";
            FA2 fa6 = new FA2();
            bool? result6 = fa6.Run(s6);
            Console.WriteLine("Expected: False, Actual: " + result6);

            String s7 = "00110011";
            FA2 fa7 = new FA2();
            bool? result7 = fa7.Run(s7);
            Console.WriteLine("Expected: False, Actual: " + result7);

            String s8 = "0001";
            FA2 fa8 = new FA2();
            bool? result8 = fa8.Run(s8);
            Console.WriteLine("Expected: True, Actual: " + result8);

            String s9 = "111000";
            FA2 fa9 = new FA2();
            bool? result9 = fa9.Run(s9);
            Console.WriteLine("Expected: True, Actual: " + result9);

            // FA3 tests
            String s10 = "00110011";
            FA3 fa10 = new FA3();
            bool? result10 = fa10.Run(s10);
            Console.WriteLine("Expected: True, Actual: " + result10);

            String s11 = "0101";
            FA3 fa11 = new FA3();
            bool? result11 = fa11.Run(s11);
            Console.WriteLine("Expected: False, Actual: " + result11);
        }
    }
}