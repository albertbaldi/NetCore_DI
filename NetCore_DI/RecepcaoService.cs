using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore_DI
{
  public class RecepcaoService : IRecepcaoService
  {
    public string Saudacao(string nome) => $"Olá, {nome}";
  }
}
