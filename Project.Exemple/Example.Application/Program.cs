using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Application
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vamos lá...");

            MainAsync().Wait();

            Console.WriteLine("FIM DA EXECUÇÃO");

            Console.ReadLine();
        }

        static async Task MainAsync()
        {
            #region METODO 01 -> modo async step by step
            //var exemple01 = await Example01();
            //var exemple02 = await Example02();
            #endregion

            #region METODO 02 -> TASK RUN -> não determina o fim até os dois metodos retornaram
            //Task exemple01 = Task.Run(async () => await Example01());
            //Task exemple02 = Task.Run(async () => await Example02());

            //Task.WaitAll(exemple01, exemple02);

            #endregion

            #region METODO 03 -> Task Start -> roda em background mesmo o fim do app
            //Task exemple01 = new Task(async () => await Example01());
            //Task exemple02 = new Task(async () => await Example02());

            //exemple01.Start();
            //exemple02.Start();

            //Task.WaitAll(exemple01, exemple02);

            #endregion

            #region METODO 04 -> paraleliza a operação necessária das tarefas.            
            Parallel.Invoke(
                    async () => await Example01(),
                    async () => await Example02());
            #endregion
        }

        static async Task<string> Example01()
        {
            Console.WriteLine("Executando o metodo >>>>> EXAMPLE01 <<<<<");

            await Task.Delay(10000);

            Console.WriteLine("Retorno do metodo successo >>>>> EXAMPLE01 <<<<<");


            return "FIM >>>>> Example01 <<<<<";
        }

        static async Task<List<string>> Example02()
        {
            Console.WriteLine("Executando o metodo >>>>> EXAMPLE02 <<<<<");
            List<string> execution = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(300);

                execution.Add($"Numero da execução >>>> {i} <<<<<<");
            }

            await Task.Delay(10000);

            Console.WriteLine("Retorno do metodo successo >>>>> EXAMPLE02 <<<<<");

            return execution;
        }
    }
}
