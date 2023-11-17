using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    class Memory
    {
       public List<Card> Cards { get; private set; }
       public int Score { get; private set; }
       int _open = -1;
        public Memory(List<Card> cards)
        {
            Cards = cards;
            Score = 0;
            Shuffle();
        }
        public bool IsGameOver() {
            foreach (Card c in Cards) {
                if (c.IsBack)
                    return false;
            }
            return true;
        }
        public void OpenCard(int pos)
        {
            if (Cards[pos].IsBack)
            {  
                Cards[pos].Reverce();
                if (_open == -1)
                {
                   _open = pos;
                }
                else
                {
                    if (!Check(pos, _open))
                    {
                        Cards[pos].Reverce();
                        Cards[_open].Reverce();
                        Score += 100;
                    }
                    else
                        Score -= 50;
                    _open = -1;
                }
            }
        }
        public bool Check(int pos, int pos2)
        {
            return Cards[pos].Id == Cards[pos2].Id;
        }
        public void NewGame()
        {
            for (int i = 0; i < Cards.Count; i++)
            {
                if (Cards[i].IsBack == false)
                    Cards[i].Reverce();
            }
            Score = 0;
            Shuffle();
        }
        void  Shuffle()
        {
            Random random = new Random();
            for (int i=0; i<Cards.Count;i++)
            {
                int x = random.Next(Cards.Count);
                Card temp = Cards[i];
                Cards[i] = Cards[x];
                Cards[x] = temp;
            }
        }
    }
}
