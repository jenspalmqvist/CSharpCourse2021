using System.Collections.Generic;

namespace GenericsAndLinq
{
    public interface IMonotreme
    {
        public int NumberOfEggs { get; set; }

        public List<IMonotreme> HatchEggs(List<string> names, List<Sex> sexes);
    }
}