using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DividersAndPrimes.Domain.Adapters;
using DividersAndPrimes.MathAdapter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DividersAndPrimes.MathConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = CreateBuilder();

            Start(builder);
        }

        static ServiceProvider CreateBuilder()
        {
            var config = GetConfiguration();

            var service = new ServiceCollection();
            
            var section = config.GetSection(nameof(MathAdapterConfiguration));
            var mathAdapterConfig = section.Get<MathAdapterConfiguration>();

            var builder = service.AddMathAdapter(mathAdapterConfig)
                .AddLogging()
                .AddMathAdapter(mathAdapterConfig)
                .BuildServiceProvider();

            return builder;

        }

        static IConfiguration GetConfiguration()
        {
            try
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                return builder.Build();
            }
            catch (Exception ex)
            {
                throw new Exception($"error loading appsettings.json. Description: {ex.Message}");
            }
        }

        static void Start(IServiceProvider services)
        {
            using (IServiceScope serviceScope = services.CreateScope())
            {
                IServiceProvider provider = serviceScope.ServiceProvider;

                IMathAdapter adapter = provider.GetRequiredService<IMathAdapter>();

                try
                {
                    Console.Write("Enter a number between 1 and 2,147,483,647: ");
                    int maxValue = int.Parse(Console.ReadLine());

                    Console.WriteLine("Entry Number: {0:D}", maxValue);

                    Console.Write("Dividing numbers: ");
                    IEnumerable<int> divisors = adapter.GetDivisors(maxValue).Result;
                    PrintList(divisors);
                    Console.WriteLine();

                    Console.Write("Prime numbers: ");
                    var primes = adapter.GetPrimes(maxValue).Result;
                    PrintList(primes);

                    Console.ReadKey();
                }
                catch (FormatException fx)
                {
                    Console.WriteLine("The value entered is not a number between 1 and 2,147,483,647");
                    Console.WriteLine(fx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void PrintList(IEnumerable<int> list)
        {
            foreach (int valor in list)
            {
                Console.Write("{0:D} ", valor);
            }
        }
    }
}
