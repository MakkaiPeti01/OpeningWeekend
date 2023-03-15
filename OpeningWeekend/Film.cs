using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpeningWeekend
{
    class Film
    {
		//eredetiCim;magyarCim;bemutato;forgalmazo;bevel;latogato

		private string eredetiCim;

		public string EredetiCim
		{
			get { return eredetiCim; }
		}

		private string magyarCim;

		public string MagyarCim
		{
			get { return magyarCim; }
		}

		private DateTime bemutato;

		public DateTime Bemutato
		{
			get { return bemutato; }
		}

		private string forgalmazo;

		public string Forgalmazo
		{
			get { return forgalmazo; }
		}

		private int bevetel;

		public int Bevetel
		{
			get { return bevetel; }
		}

		private int latogato;

		public int Latogato
		{
			get { return latogato; }
		}

		public Film(string eredetiCim, string magyarCim, DateTime bemutato, string forgalmazo, int bevetel, int latogato)
		{
			this.eredetiCim = eredetiCim;
			this.magyarCim = magyarCim;
			this.bemutato = bemutato;
			this.forgalmazo = forgalmazo;
			this.bevetel = bevetel;
			this.latogato = latogato;
		}
	}
}
