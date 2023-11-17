using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    public class MemorySettings
    {
        public List<CardCollection> Collections { get; private set; }
        public int CardCount { get; private set; }
        public int Level { get; private set; }
        public string CollectionPath { get; private set; }
        public int SelectedCollection { get; private set; }
        public MemorySettings()
        {
            Collections = new List<CardCollection>();
            for (int i = 0; i < 5; i++)
            {
                Collections.Add(CardCollectionsCreator.GetCardCollection(i));
            }
            CollectionPath = Collections[0].Path;
            SelectedCollection = 0;
            CardCount = 4;
            Level = 2;
        }
        public void SaveSettings(int count, int lvl, int id)
        {
            CardCount = count / 4 * 4;
            Level = lvl;
            SelectedCollection = id;
            CollectionPath = Collections[SelectedCollection].Path;
        }
    }
}
