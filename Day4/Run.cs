using System;
using day4;
public class Run
{
	public static void Main()
	{
		Programm programm = new Programm();
		Task t1 = programm.UpdateVar1();
        Task t2 = programm.UpdateVar2();
		
		Task t3 = programm.UpdateVar3();
		Task t4 = programm.UpdateVar4();
		List<Task> tasks = new List<Task> { t1, t2, t3, t4 };

        Task.Run(async () => await programm.TaskExecution(tasks)).Wait(); //use to call async function in sync environment

    }
	
}
