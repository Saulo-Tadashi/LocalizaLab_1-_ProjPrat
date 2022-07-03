using System;

namespace DIO.Series
{
	class Program
	{
		static SeriesRepositorio repositorio = new SeriesRepositorio ();

		static void Main ( string[] args )
		{
			string opcaoUsuario = ObterOpcaoUsuario ();

			while ( opcaoUsuario.ToUpper() != "X" )
			{
				switch ( opcaoUsuario )
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSeries();
						break;
					case "3":
						//AtualizarSeries();
						break;
					case "4":
						//ExcluirSeries();
						break;
					case "5":
						//VisualizarSeries();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}
				
				opcaoUsuario = ObterOpcaoUsuario();
			}	

			Console.WriteLine ( "Obrigado por utilizar o serviço." );
			Console.WriteLine ();
		}

		private static string ObterOpcaoUsuario ()
		{
			Console.WriteLine();
			Console.WriteLine( "Primeiro projeto DIO - Localiza Lab - Sistema de Cadastro de Séries." );
			Console.WriteLine( "Informe a opção desejada:" );

			Console.WriteLine( "1 - Listar séries" );
			Console.WriteLine( "2 - Inserir nova série" );
			Console.WriteLine( "3 - Atualizar série" );
			Console.WriteLine( "4 - Excluir série" );
			Console.WriteLine( "5 - Visualizar série" );
			Console.WriteLine( "C - Limpar tela" );
			Console.WriteLine( "X - Sair" );
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
		
		private static void ListarSeries()
		{
			Console.WriteLine ( "Listar séries" );

			var lista = repositorio.Listar();

			if ( lista.Count == 0 )
			{
				Console.WriteLine ( "Nenhuma série cadastrada." );
				return;
			}

			foreach ( var serie in lista )
			{
				Console.WriteLine ( "#ID {0}: - {1}", serie.retornarId(), serie.retornarTitulo() );
			}
		}

		private static void InserirSeries()
		{
			Console.WriteLine ( "Inserir nova série" );

			foreach ( int i in Enum.GetValues ( typeof (Genero) ) )
			{
				Console.WriteLine ( "{0}-{1}", i, Enum.GetName ( typeof (Genero), i) );
			}

			Console.Write ( "Digite o gênero entre as opções acima: " );
			int entradaGenero = int.Parse ( Console.ReadLine () );

			Console.Write ( "Digite o Título da série: " );
			string entradaTitulo = Console.ReadLine();

			Console.Write ( "Digite o Ano do início da série: " );
			int entradaAno = int.Parse ( Console.ReadLine() );

			Console.Write ( "Digite a Descrição da série: " );
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie (
					id: repositorio.PegarProximoId(),
					genero: ( Genero ) entradaGenero,
					titulo: entradaTitulo,
					ano: entradaAno,
					descricao: entradaDescricao);

			repositorio.Inserir (novaSerie);
		}

		private static void AtualizarSeries ()
		{

		}

		private static void ExcluirSeries()
		{

		}

		private static void VisualizarSeries()
		{

		}
	}
}	
