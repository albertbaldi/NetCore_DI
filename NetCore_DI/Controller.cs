using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore_DI
{
  public class Controller
  {
    private readonly IRecepcaoService recepcaoService;

    public Controller(IRecepcaoService recepcaoService)
    {
      //se a dependência não for injetada, levanta uma exceção de argumento nulo.
      this.recepcaoService = recepcaoService ?? throw new ArgumentNullException(nameof(recepcaoService));
    }

    /// <summary>
    /// Este método irá consumir o método "Saudacao" do serviço. 
    /// </summary>
    /// <param name="nome">O nome para realizar o cumprimento.</param>
    /// <returns>Texto de cumprimento.</returns>
    public string Ola(string nome) => this.recepcaoService.Saudacao(nome);

    //public string Ola(string nome)
    //{
    //  var service = new RecepcaoService();
    //  return service.Saudacao(nome);
    //}
  }
}
