using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    class Card
    {
        public Image Front { get; private set; }
        public Image Back { get; private set; }
        public bool IsBack { get; private set; }
        public int Id { get; private set; }

        public Card (Image front, Image back, int id)
        {
            Front = front;
            Back = back;
            Id = id;
            IsBack = true;
        }
        public Card(Card card) {
            Front = card.Front;
            Back = card.Back;
            Id = card.Id;
            IsBack = card.IsBack;
        }
        public void Reverce ()
        {
            IsBack = !IsBack;
        }
    }
}
