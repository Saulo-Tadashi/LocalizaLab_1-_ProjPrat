using System;

namespace DIO.Series
{
	class Program
	{
		static SeriesRepositorio repositorio = new SeriesRepositorio ();

		static void Main ( string[] args )
		{
			string opcaoUsuario;

			do
			{
				opcaoUsuario = ObterOpcaoUsuario();
				switch ( opcaoUsuario )
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSeries();
						break;
					case "3":
						AtualizarSeries();
						break;
					case "4":
						ExcluirSeries();
						break;
					case "5":
						VisualizarSeries();
						break;
					case "C":
						Console.Clear();
						break;
					case "X":
						break;

					default:						
						Console.WriteLine( "Por favor, selecione uma das opções acima." );
						break;
				}

				Console.Clear();
			}while ( opcaoUsuario.ToUpper() != "X" );

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
		
		private static Serie ReceberEntradaSerie(int indice)
		{
			if( indice < 0 )
				indice = repositorio.PegarProximoId();

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
					id: indice,
					genero: ( Genero ) entradaGenero,
					titulo: entradaTitulo,
					ano: entradaAno,
					descricao: entradaDescricao);

			return novaSerie;
		}

		private static bool ReceberIndiceSerie (out int indiceSerie, string msg)
		{
			Console.Write( "Digite o Id da série para {0}: ", msg);
			indiceSerie = int.Parse( Console.ReadLine() );

			return (indiceSerie > -1 && indiceSerie < repositorio.Listar().Count());
		}

		private static void ListarSeries()
		{
			Console.WriteLine ( "Listar séries" );

			var lista = repositorio.Listar();

			if ( lista.Count == 0 )
			{
				Console.WriteLine ( "Nenhuma série cadastrada." );
			}
			else
			{
				foreach ( var serie in lista )
				{
					if( serie.retornarExcluido() )
						Console.WriteLine ( "#ID {0}: - Excluído", serie.retornarId() );
					else
						Console.WriteLine ( "#ID {0}: - {1}", serie.retornarId(), serie.retornarTitulo() );
				}
			}
			Console.WriteLine( Environment.NewLine + "Pressione Enter para continuar" );
			Console.ReadLine();
		}

		private static void InserirSeries()
		{
			Console.WriteLine ( "Inserir nova série" );

			repositorio.Inserir ( ReceberEntradaSerie(-1) );
		}

		private static void AtualizarSeries ()
		{
			if( ReceberIndiceSerie(out int indiceSerie, "atualização" ) )
				repositorio.Atualizar( indiceSerie, ReceberEntradaSerie( indiceSerie ) );
			else
				Console.WriteLine( "Indice inválido.");
		}

		private static void ExcluirSeries()
		{
			if( ReceberIndiceSerie(out int indiceSerie, "exclusão" ) )
				repositorio.Excluir( indiceSerie );
			else
				Console.WriteLine( "Indice inválido.");
		}

		private static void VisualizarSeries()
		{
			if( ReceberIndiceSerie(out int indiceSerie, "visualização" ) )
				Console.WriteLine( repositorio.RetornarPorId( indiceSerie ) );
			else
				Console.WriteLine( "Indice inválido.");

			Console.WriteLine( Environment.NewLine + "Pressione Enter para continuar" );
			Console.ReadLine();
		}
	}
}	
