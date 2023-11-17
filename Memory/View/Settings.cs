using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public partial class Settings : Form
    {
        List<PictureBox> pictures;
        MemorySettings memset;
        int selectedPicture;
        public Settings(MemorySettings settings)
        {
            InitializeComponent();
            memset = settings;
            pictures = new List<PictureBox>();
            SetView();
        }
        private void SetView() {
            trackBar1.Value = memset.CardCount;
            label4.Text = memset.CardCount.ToString();
            trackBar2.Value = memset.Level;
            label5.Text = memset.Level.ToString();
            int top = 220;
            int left = 20;
            for (int i = 0; i < 5; i++)
            {
                pictures.Add(new PictureBox());
                pictures[i].Width = 100;
                pictures[i].Height = 100;
                pictures[i].Top = top;
                pictures[i].Left = left;
                pictures[i].Image = memset.Collections[i].Picture;
                pictures[i].SizeMode = PictureBoxSizeMode.Zoom;
                pictures[i].Tag = i;
                Controls.Add(pictures[i]);
                pictures[i].Click += PictureBoxClick;
                left += 106;
            }
            SetPBSelection(memset.SelectedCollection);
        }
        private void SetPBSelection(int id) {
            foreach (PictureBox pb in pictures)
                pb.BorderStyle = BorderStyle.None;
            pictures[id].BorderStyle = BorderStyle.FixedSingle;
        }
        private void PictureBoxClick(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            selectedPicture = Convert.ToInt32(pictureBox.Tag.ToString());
            SetPBSelection(selectedPicture);
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label4.Text = (trackBar1.Value/ 4 * 4).ToString();
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label5.Text = trackBar2.Value.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены?", "Новая игра", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                memset.SaveSettings(trackBar1.Value, trackBar2.Value, selectedPicture);
                DialogResult = DialogResult.Yes;
            }
            else
            {
                DialogResult = DialogResult.No;
            }
        }
    }
}
