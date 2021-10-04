using System;
using System.Collections.Generic;

namespace Task_manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> homeWork = new Queue<string>();
            homeWork.Enqueue("cooking");
            homeWork.Enqueue("cleaning");
            homeWork.Enqueue("washing");
            homeWork.Enqueue("garden keep");
            while (homeWork.Count > 0)
            {
                TaskSolver(homeWork);
            } 
        }
        public static Queue<string> TaskSolver(Queue<string> task)
        {
            task.Dequeue();
            return task;
        }
    }
}