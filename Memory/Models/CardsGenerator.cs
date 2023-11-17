using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    static class CardsGenerator
    {
        static  public List<Card> GetDeck (int n,string path,Image back)
        {
           List<Card> result = new List<Card>();
           string [] names =  Directory.GetFiles(path);

            n = Math.Abs(n);
            if (n > names.Length)
                n = names.Length;

            for (int i = 0; i < n; i++)
            {
                result.Add(new Card(Image.FromFile(names[i]), back, i));
                result.Add(new Card(Image.FromFile(names[i]), back, i));
            }
            return result;
        }
        static public List<Card> GetDeck(int count, int lvl, string path)
        {
            List<Card> result = new List<Card>();
            string[] names = Directory.GetFiles(path);
            if (count <= lvl*2)
            {
                lvl = count / 2;
            }
            string p = names[0];
            Image back = Image.FromFile(p);
            for (int i = 1; i <= lvl; i++)
            {
                for (int j = 0; j < count / lvl; j++)
                {
                    result.Add(new Card(Image.FromFile(names[i]), back, i));
                }
            }
            if (result.Count < count) {
                int diff = count - result.Count;
                for (int i = 0; i < diff; i++) {
                    result.Add(new Card(result[i]));
                }
            }
            return result;
        }
    }
    
}
