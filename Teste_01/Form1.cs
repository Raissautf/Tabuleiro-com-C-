using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teste_01 {
	public partial class Form1 : Form {
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string[] datas = new string[] { "-1", "-2", "1", "2", "3" };
			Random r = new Random();

			txtValor.Text = datas[r.Next(datas.Length)];

		}

		private void txtValor_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
