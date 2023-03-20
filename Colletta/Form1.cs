using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Colletta
{
    public partial class Form1 : Form 
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool first = true;
        Dictionary<Persona, Soldi> accounts;

        Persona p;
        Soldi s;

        private void Form1_Load(object sender, EventArgs e)
        {
            accounts = new Dictionary<Persona, Soldi>();
            if (first)
            {
                listView1.View = View.Details;
                listView1.FullRowSelect = true;
                first = false;

                listView1.Columns.Add("UTENTE", 250);
                listView1.Columns.Add("€", 50);
            }
        }

        public void Add()
        { 
            ListViewItem item = new ListViewItem(Txt_Nome.Text);
            item.SubItems.Add(Txt_quote.Text);
            listView1.Items.Add(item);
            accounts.Add(p, s);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p = new Persona(Txt_Nome.Text);
            Add();
            Txt_Nome.Clear();
            Txt_quote.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p = new Persona(listView1.SelectedItems[0].SubItems[0].Text);
            accounts.Remove(p);
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Txt_Nome.Text = listView1.SelectedItems[0].SubItems[0].Text;
            Txt_quote.Text = listView1.SelectedItems[0].SubItems[1].Text;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            SortedDictionary<Persona, Soldi> temprino = new SortedDictionary<Persona, Soldi>(accounts);
            accounts = new Dictionary<Persona, Soldi>(temprino);
            Update();
        }

        public void Update()
        {
            listView1.Items.Clear();
            foreach (KeyValuePair<Persona, Soldi> kvp in accounts)
            {
                string[] val = new string[] { Convert.ToString(kvp.Key.Nome)};
                ListViewItem item = new ListViewItem(val);
                listView1.Items.Add(item);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SortedDictionary<Persona, Soldi> temprino = new SortedDictionary<Persona, Soldi>(accounts);
            accounts = new Dictionary<Persona, Soldi>(temprino);
            Update(); 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<Persona, Soldi> kvp in accounts)
            {
                if (kvp.Value.Importo == s.Importo)
                {
                    MessageBox.Show(kvp.Key.ToString());
                }
            }
        }
    }
}
