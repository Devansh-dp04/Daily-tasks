using System;
using System.Threading.Tasks;

namespace day4 {
    public class Programm
    {

        
        public async Task UpdateVar1()
        {
            await Task.Delay(1000);//awaits execution for 1sec
            Console.WriteLine("Executing Task1");
            

        }
        public async Task UpdateVar2()
        {
            await Task.Delay(3000);//awaits execution for 3sec
            
            Console.WriteLine("Executing task2");
            
        }
        public async Task UpdateVar3()
        {
            await Task.Delay(2000);//awaits execution for 2sec
            
            Console.WriteLine("Executing task3");

        }
        public async Task UpdateVar4()
        {
            await Task.Delay(5000);//awaits execution for 5sec
            
            Console.WriteLine("Executing task4");

        }

        public async Task TaskExecution(List<Task> tasks)
        {

            Task firstfinished = await Task.WhenAny(tasks.ToArray());
            Console.WriteLine($"The first task completed");
            tasks.Remove(firstfinished);
            Console.WriteLine($"Executing remaining tasks");
            int count = tasks.Count;
            while (count > 0)
            {
                Task remaining =await Task.WhenAny(tasks.ToArray());
                tasks.Remove(remaining);
                count--;



            }
        }
        

    }

}

