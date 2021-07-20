using Microsoft.Extensions.DependencyInjection;
using System;

namespace NetCore_DI
{
  class Program
  {
    static void Main(string[] args)
    {
      //Console.WriteLine("Hello World!");

      //var controller = new Controller();
      //string resultado = controller.Ola("Albert");
      //Console.WriteLine(resultado);

      //var controller = new Controller(new RecepcaoService());
      //string resultado = controller.Ola("Albert");

      using (ServiceProvider container = RegistrarServices())
      {
        // recupera os serviços necessários de acordo com a controller informada.
        var controller = container.GetRequiredService<Controller>();
        // invoca o método.
        var resultado = controller.Ola("Albert");
        // tudo pronto! só exibir o resultado.
        Console.WriteLine(resultado);
      }

      Console.ReadLine();
    }

    /// <summary>
    /// Registra os serviços que serão utilizados pelo programa.
    /// </summary>
    /// <returns><see cref="ServiceProvider"/></returns>
    static ServiceProvider RegistrarServices()
    {
      /*
      Singleton: Um objeto do serviço é criado e fornecido para todas as requisições. Assim, todas as requisições obtém o mesmo objeto;
      Escope: Um objeto do serviço é criado para cada requisição. Dessa forma, cada requisição obtém uma nova instância do serviço;
      Transient: Um objeto do serviço é criado toda a vez que um objeto for requisitado;
      Instance: Você é responsável por criar um objeto do serviço. O framework de DI então usa esse instância em um modo Singleton;
      */

      var services = new ServiceCollection();
      services.AddSingleton<IRecepcaoService, RecepcaoService>();
      services.AddTransient<Controller>();

      return services.BuildServiceProvider();
    }
  }
}
