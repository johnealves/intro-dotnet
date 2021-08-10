using System;

namespace revisao
{
  class Program
	{
		static void Main(string[] args)
    {
			Aluno[] alunos = new Aluno[5];
			int indiceAluno = 0;
      string opcaoUsuario = obterOpcaoUsuario();

      while (opcaoUsuario.ToUpper() != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            //todo:adicionar aluno
						Console.WriteLine("Informe o nome do aluno:");
						Aluno aluno = new Aluno();
						aluno.Nome = Console.ReadLine();

						Console.WriteLine("Informe a nota do aluno:");

						if (decimal.TryParse(Console.ReadLine(), out decimal nota))
						{
							aluno.Nota = nota;
						}
						else 
						{
							throw new ArgumentException("O valor da nota deve ser um numero decimal");
						}

						alunos[indiceAluno] = aluno;
						indiceAluno++;

            break;
          case "2":
            //todo: listar alunos
						foreach(var a in alunos)
						{
							if (!string.IsNullOrEmpty(a.Nome))
							{
								Console.WriteLine($"Aluno: {a.Nome} - nota: {a.Nota}");
							}
						}
            break;
          case "3":
            //todo: listar media geral
						decimal notaTotal = 0;
						var numAlunos = 0;

						for (int i = 0; i < alunos.Length; i++)
						{
							if (!string.IsNullOrEmpty(alunos[i].Nome))
							{
								notaTotal = notaTotal + alunos[i].Nota;
								numAlunos++;
							}
						}

						var media = notaTotal / numAlunos;
						Conceito conceitoGeral;

						if (media <= 2)
						{
							conceitoGeral = Conceito.E;
						}
						else if (media <= 4)
						{
							conceitoGeral = Conceito.D;
						}
						else if (media <= 6)
						{
							conceitoGeral = Conceito.C;
						}
						else if (media <= 8)
						{
							conceitoGeral = Conceito.B;
						}
						else{
							conceitoGeral = Conceito.A;
						}



						Console.WriteLine($"Media da turma: {media} conceito: {conceitoGeral}");
            break;
          default:
						Console.WriteLine("Opção invalida, tente novamente");
						Console.WriteLine();
						opcaoUsuario = obterOpcaoUsuario();
            throw new ArgumentOutOfRangeException();
        }
        
				Console.WriteLine();
				opcaoUsuario = obterOpcaoUsuario();
      }
    }

    private static string obterOpcaoUsuario()
    {
			Console.WriteLine("---------------------------");
      Console.WriteLine("Informe a opção desejada:");
      Console.WriteLine("1 - Inserir novo aluno");
      Console.WriteLine("2 - Listar alunos");
      Console.WriteLine("3 - Calcular média geral");
      Console.WriteLine("X - sair");
      Console.WriteLine("---------------------------");

      string opcaousuario = Console.ReadLine();
      return opcaousuario;
    }
  }
}
