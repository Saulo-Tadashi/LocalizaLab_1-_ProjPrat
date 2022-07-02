using System;
using System.Collections.Generic;

using DIO.Series.Interfaces;

namespace DIO.Series
{
	public class SeriesRepositorio : IRepositorio < Serie >
	{
		private List < Serie > listaSerie = new List < Serie > ();

		public List < Serie > Listar () 
		{
			return listaSerie;
		}

		public Serie RetornarPorId ( int id ) 
		{
			return listaSerie [ id ];
		}

		public void Inserir ( Serie objeto ) 
		{
			listaSerie.Add ( objeto );
		}

		public void Excluir ( int id ) 
		{
			listaSerie [ id ].Excluir ();	
		}

		public void Atualizar ( int id, Serie objeto ) 
		{
			listaSerie [ id ] = objeto;
		}

		public int PegarProximoId () 
		{
			return listaSerie.Count;
		}	
	}
}
