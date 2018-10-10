using System;
using System.Collections;
using System.Collections.Generic;


// Текущее состояние + входной символ
using Input = System.Tuple<States, char>;

// Новое состояние + выходной сигнал (пусть тот же символ)
using Result = States;


enum States
{
    Z1,
    Z2,
    Z3,
    Z4,
    Z5
};


namespace finiteAutomaton
{
    class Program
    {
        static void Main(string[] args)
        {
            Automaton automaton = new Automaton();
            while (true)
            {
                char input;
                Console.WriteLine("Введите символ (a, b, c, d, e): ");
                if (char.TryParse(Console.ReadLine(), out input))
                    automaton.NextState(input);
            }
        }
    }
    
    class Automaton
    {
        // Карта переходов
        private Dictionary<Input, Result> transitions;

        // Текущее состояние
        private States state;

        // Таблица выходных сигналов
        private Dictionary<States, string> Y;
         


        public Automaton()
        { 
            // Начальное состояние
            state = States.Z1;

            Input test = new Input(States.Z1, 'a');

            transitions = new Dictionary<Input, Result>();
            transitions.Add(new Input(States.Z1, 'b'), States.Z4);
            transitions.Add(new Input(States.Z1, 'a'), States.Z3);
            transitions.Add(new Input(States.Z1, 'e'), States.Z3);
            transitions.Add(new Input(States.Z2, 'c'), States.Z1);
            transitions.Add(new Input(States.Z3, 'c'), States.Z2);
            transitions.Add(new Input(States.Z3, 'd'), States.Z4);
            transitions.Add(new Input(States.Z4, 'd'), States.Z3);
            transitions.Add(new Input(States.Z4, 'a'), States.Z2);

            // Вектор выходов для всех четырех состояний
            Y = new Dictionary<States, string>();
            Y.Add(States.Z1, "One");
            Y.Add(States.Z2, "Two");
            Y.Add(States.Z3, "One");
            Y.Add(States.Z4, "Two");
        }

        public void NextState(char inputChar)
        {
            Input inputTuple = new Input(state, inputChar);

            // Получаем новое состояние. в которое мы переходим
            state = transitions[inputTuple];
            Console.WriteLine("{0} --({1})--> {2}, Y = {3}", inputTuple.Item1, inputTuple.Item2, state, Y[state]);
        }
    }
}
