using System;
using System.Collections.Generic;

namespace GenericsAndLinq
{
    public interface IMarsupial
    {
        public List<IMarsupial> BabiesInPouch { get; set; }

        public IMarsupial TransformBabyToAdult();

        public List<IMarsupial> TransformBabyToAdult(bool allBabies);

        public List<string> FeedBabies(Diet food);
    }
}