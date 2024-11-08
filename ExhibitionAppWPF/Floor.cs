using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExhibitionAppWPF
{
	public class Floor
	{
		public int FloorNumber { get; set; }
		public List<Hall> Halls { get; set; }
	}
}
