using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public partial class MainForm : Form
    {
        List<PictureBox> pictureBoxes;
        Memory memory;
        public MemorySettings MemSet { get; private set; }
        public MainForm()
        {
            InitializeComponent();
            MemSet = new MemorySettings();
            NewSettingsGame();
        }
        void NewSettingsGame() {
            if (pictureBoxes != null)
                for (int i = 0; i < pictureBoxes.Count; i++)
                    pictureBoxes[i].Dispose();
            pictureBoxes = new List<PictureBox>();
            memory = new Memory(CardsGenerator.GetDeck(
                MemSet.CardCount, MemSet.Level, MemSet.CollectionPath));
            GeneratePictureBoxes();
        }
        void NewGame() {
            memory.NewGame();
            label2.Text = memory.Score.ToString();
            ShowCards.RefreshUI(pictureBoxes, memory);
        }
        void GeneratePictureBoxes()
        {
            int top = 40;
            int left = 20;
            for (int i = 0; i < MemSet.CardCount; i++)
            {
                pictureBoxes.Add(new PictureBox());
                if (i % 4 == 0 && i!= 0 && MemSet.CardCount < 30 ||
                    i % 8 == 0 && i!= 0)
                {
                    left = 20;
                    top += 106;
                }
                pictureBoxes[i].Width = 100;
                pictureBoxes[i].Height = 100;
                pictureBoxes[i].Image = memory.Cards[i].Back;
                pictureBoxes[i].SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxes[i].Tag = i;
                pictureBoxes[i].Top = top;
                pictureBoxes[i].Left = left;
                pictureBoxes[i].Click += PictureBoxClick;
                Controls.Add(pictureBoxes[i]);
                left += 106;
            }
        }

        private void PictureBoxClick(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                PictureBox pictureBox = (PictureBox)sender;
                int i = Convert.ToInt32(pictureBox.Tag.ToString());
                pictureBox.Image = memory.Cards[i].Front;
                memory.OpenCard(i);
                label2.Text = memory.Score.ToString();
                timer1.Enabled = true;
                if (memory.IsGameOver()) {
                    DialogResult result = MessageBox.Show("Начать новую игру?", "Конец игры",MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                        NewGame();
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ShowCards.RefreshUI(pictureBoxes, memory);
            timer1.Enabled = false;
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void параметрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings setForm = new Settings(MemSet);
            DialogResult result = setForm.ShowDialog();
            if(result == DialogResult.Yes)
                NewSettingsGame();
        }
    }
}
