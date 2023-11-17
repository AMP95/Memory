using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    static class ShowCards
    {
        static public void RefreshUI (List<PictureBox> PB, Memory memory)
        {
            for (int i =0; i<PB.Count;i++)
            {
                if (memory.Cards[i].IsBack)
                    PB[i].Image = memory.Cards[i].Back;
                else
                    PB[i].Image = memory.Cards[i].Front;
            }
        }
    }
}
