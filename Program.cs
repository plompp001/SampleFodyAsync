using System;
using System.Threading.Tasks;
using MethodBoundaryAspect.Fody.Sample;

namespace Sample
{
    class Program
    {
        //[DisableWeaving]

        static void Main(string[] args)
        {
            Console.WriteLine("Starting application");

            var runMe = new RunMe();

            runMe.RunAsyncAndGetNoError().Wait();
            runMe.RunAsyncAndAlsoGetNoError();

            // BOOM!!
            runMe.RunAsyncAndGetError().Wait();

            Console.WriteLine("Application stopping...");
            Console.ReadKey();
        }


        private class RunMe
        {
            [LogError]
            public async Task RunAsyncAndGetError()
            {
                try
                {
                    // Some async code...
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            [LogError]
            public Task RunAsyncAndGetNoError()
            {
                try
                {
                    return Task.CompletedTask;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            [LogError]
            public void RunAsyncAndAlsoGetNoError()
            {
                try
                {
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
