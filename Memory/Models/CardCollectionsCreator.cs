using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    static class CardCollectionsCreator
    {
        static public CardCollection GetCardCollection(int id) {
            string path;
            switch (id) {
                case 1: path = "collections\\minions"; break;
                case 2: path = "collections\\christmas"; break;
                case 3: path = "collections\\pirates"; break;
                case 4: path = "collections\\halloween"; break;
                default: path = "collections\\fastfood"; break;
            }
            return new CardCollection(id, path);
        }
    }
}
