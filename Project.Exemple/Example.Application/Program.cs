using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Application
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Vamos lá...");

            await MainAsync();

            Console.WriteLine($"FIM DA EXECUÇÃO EM {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff")}");

            Console.ReadLine();
        }

        static async Task MainAsync()
        {
            await Task.Delay(200);
            #region METODO 01 -> modo async step by step
            //var exemple01 = await Example01();
            //var exemple02 = await Example02();
            #endregion

            #region METODO 02 -> TASK RUN -> não determina o fim até os dois metodos retornaram

            //Task exemple01 = Task.Run(async () =>
            //{
            //    Console.WriteLine($"INICIANDO EM Exemplo 01: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff")}");
            //    await Example01();
            //});

            //Task exemple02 = Task.Run(async () =>
            //{
            //    Console.WriteLine($"INICIANDO EM EXEMPLO 02: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff")}");
            //    await Example02();
            //});

            //Task.WaitAll(exemple01, exemple02);

            #endregion

            #region METODO 03 -> Task Start -> roda em background mesmo o fim do app            
            //Task exemple01 = new Task(async () =>
            //{
            //    Console.WriteLine($"INICIANDO EM Exemplo 01: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff")}");
            //    await Example01();
            //});

            //Task exemple02 = new Task(async () =>
            //{
            //    Console.WriteLine($"INICIANDO EM EXEMPLO 02: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff")}");
            //    await Example02();
            //});

            //exemple01.Start();
            //exemple02.Start();

            //Task.WaitAll(exemple01, exemple02);

            #endregion

            #region METODO 04 -> paraleliza a operação necessária das tarefas.
            //Console.WriteLine($"INICIANDO EM: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff")}");
            Parallel.Invoke(
                    async () =>
                    {
                        Console.WriteLine($"INICIANDO EM Exemplo 01: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff")}");
                        await Example01();
                    },
                    async () =>
                    {
                        Console.WriteLine($"INICIANDO EM Exemplo 02: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff")}");
                        await Example02();
                    });
            #endregion
        }

        static async Task Example01()
        {
            Console.WriteLine($"Executando o metodo >>>>> EXAMPLE01 <<<<< TEMPO: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff")} THREAD: {Task.CurrentId.Value}");

            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(300);
                Console.WriteLine($"METODO 01 -> NUMERO: {i}");
            }

            await Task.Delay(10000);

            Console.WriteLine($"Retorno do metodo successo >>>>> EXAMPLE01 <<<<< EM: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff")}");
        }

        static async Task Example02()
        {
            Console.WriteLine($"Executando o metodo >>>>> EXAMPLE02 <<<<< TEMPO {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff")} THREAD: {Task.CurrentId.Value}");

            List<string> execution = new List<string>();

            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine($"METODO 02 -> NUMERO: {i}");
                execution.Add($"Numero da execução >>>> {i} <<<<<<");
            }

            await Task.Delay(10000);

            Console.WriteLine($"Retorno do metodo successo >>>>> EXAMPLE02 <<<<< EM: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff")}");
        }
    }
}
