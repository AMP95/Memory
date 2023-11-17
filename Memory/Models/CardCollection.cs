using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    public class CardCollection
    {
        public int Id { get; private set; }
        public string Path { get; private set; }
        public Image Picture { get; private set; }
        public CardCollection(int id, string path)
        {
            Id = id;
            Path = path;
            Picture = Image.FromFile(path + "\\2.png");
        }
    }
}
