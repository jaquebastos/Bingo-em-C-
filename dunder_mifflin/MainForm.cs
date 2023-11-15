/*
 * Created by SharpDevelop.
 * User: rm20222930057
 * Date: 29/03/2023
 * Time: 13:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace dunder_mifflin
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			
			InitializeComponent();
			
		}
		string[] nome= new string[3];
		decimal[] valor= new decimal[3];
		string[] setores= new string[3];
		int cont = 0; 
		decimal total; 
		decimal media; 
		string[] dados_setores = new string[3];
		
		void Button1Click(object sender, EventArgs e)
		{
			nome[cont]= textBox1.Text; 
			valor[cont]= decimal.Parse(textBox2.Text);
			setores[cont]= comboBox1.Text; 
			
			richTextBox1.Text += nome[cont] + "\t" + valor[cont] + "\t" + setores[cont] + "\n";
			textBox1.Clear();
			textBox2.Clear();
			comboBox1.Text = "selecione o setor";
			
			//salvar 
			richTextBox1.SaveFile("Contribuições.txt", RichTextBoxStreamType.PlainText); 
		}
		void Button2Click(object sender, EventArgs e)
		{
			//listar
			listBox1.Items.Clear();
			for (int i=0; i < richTextBox1.Lines.Length -1; i++)
			{
				dados_setores = richTextBox1.Lines[i].Split('\t');
				if  (dados_setores[2] == comboBox2.Text)
				{
					listBox1.Items.Add (dados_setores[0] + "\t" + dados_setores[1] + "\t" + dados_setores[2] + "\n");
				}
			}
		}
		void Button3Click(object sender, EventArgs e)
		{
			total += decimal.Parse(dados_setores[1]);
			label4.Text = total.ToString();
			media = total/(richTextBox1.Lines.Length -1);
			label5.Text = media.ToString();
		}
		
	}
}
