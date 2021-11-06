using System;
using System.Threading;

class Program 
{
  public static int gemasPorAbyss = 350;
  public static bool possuiBencao = true;

  public static void Main (string[] args) 
  {
    Manager(false);
  }

  public static void Manager(bool pularTempo = true)
  {
    if (pularTempo)
      Thread.Sleep(3000);
    Console.Clear();
    string mensagemPrincipal = "Bem-vindo à calculadora de Wishes do Genshin, aqui são suas opções:\n\nCalcular Wishes(1)\nConfigurações (2)\nInformações (3)\nSair (Qualquer tecla)";
    
    Console.WriteLine (mensagemPrincipal);
    string informacao = Console.ReadLine();
    if (informacao == "1")
    {
      Calcular();
    }
    else
    if (informacao == "2")
    {
      Configurar();
    }
    else
    if (informacao == "3")
    {
      Informar();
    }
    else
    {
      Console.WriteLine("Adiós :)");
    }
  }

  public static void Calcular()
  {
    Console.Clear();
    Console.WriteLine("Insira a data desejada no formato DD/MM/AAAA:\nPs: lembrando que é a data final que você deseja utilizar os wishes, não a data atual!");
    string resposta = Console.ReadLine();
    string[] valores = resposta.Split('/');
    DateTime dataAtual = new DateTime(1,1,1);

    try
    {
      if (valores.Length == 3)
      {
        dataAtual = new DateTime(int.Parse(valores[2]),
                                 int.Parse(valores[1]),
                                 int.Parse(valores[0]));
      }
      DateTime dataFinal = new DateTime(dataAtual.Year, dataAtual.Month, dataAtual.Day);
      if (DateTime.Now < dataFinal.Date)
      {
        dataAtual = DateTime.Now;
        int gemasBencao = 0;
        int gemasAbismo = 0;
        int gemasDiario = 0;
        int gemasPaimon = 0;
        while (dataAtual < dataFinal.Date)
        {
          dataAtual = dataAtual.AddDays(1);
          if (possuiBencao)
            gemasBencao += 90;
          gemasDiario += 60;
          if (dataAtual.Day == 1)
          {
            gemasAbismo += gemasPorAbyss;
            gemasPaimon += 800;
          }
          else
          if (dataAtual.Day == 16)
          {
            gemasAbismo += gemasPorAbyss;
          }
        }
        string respostaFinal = "Missões diárias: " + gemasDiario;
        if (gemasBencao > 0)
          respostaFinal += "\nBenção: " + gemasBencao;
        if (gemasAbismo > 0)
          respostaFinal += "\nAbismo: " + gemasAbismo;
        if (gemasPaimon > 0)
          respostaFinal += "\nBarganhas paimon: " + gemasPaimon;

        Console.WriteLine(respostaFinal);
        int gemasFinais = gemasBencao + gemasDiario + gemasPaimon + gemasAbismo;
        Console.WriteLine("\nGemas Finais: "+ gemasFinais);
        Console.WriteLine("\nWishes Finais: "+gemasFinais/160);
        Console.WriteLine("\n\n Pressione qualquer tecla para voltar ao gerenciador!");
        Console.ReadLine();
        Manager();
      }
      else
      {
        Console.WriteLine("Data inválida! Retornando ao programa principal!");
        Manager();
      }
    }
    catch 
    { 
      Console.WriteLine("Data inválida! Retornando ao programa principal!");
      Manager();
    }
  }

  public static void Configurar()
  {
    Console.Clear();
    Console.WriteLine("Insira quantas gemas por abismo você consegue adquirir:");
    
    string resposta = Console.ReadLine();
    int valor = 0;
    
    if (int.TryParse(resposta, out valor))
    {
      gemasPorAbyss = valor;
    }
    else
    {
       Console.WriteLine("Nenhuma valor detectado, continuará sendo "+ gemasPorAbyss);
    }

    Console.WriteLine("Você possui benção no período? (S/N)");
    resposta = Console.ReadLine();
    if (resposta != null && resposta.ToUpper() == "S")
    {
      possuiBencao = true;
      Console.WriteLine("Resposta Computada!");
    }
    else
    if
    (resposta != null && resposta.ToUpper() == "N")
    {
      possuiBencao = false;
      Console.WriteLine("Resposta Computada!");
    }
    else
    {
      Console.WriteLine("Resposta inválida, continuará sendo "+possuiBencao);
    }
    
    Manager();
  }

  public static void Informar()
  {
    Console.Clear();
    Console.WriteLine("Essa é uma calculadora de Wishes do Genshin que leva em consideração gemas recebidas por missões diárias, benção, gemas mensais através das barganhas da Paimon e também o abismo, mas não leva em consideração eventos pois é impossível de calcular!\nInsira qualquer tecla para voltar :)");
    Console.ReadLine();
    Manager(false);
  }
}