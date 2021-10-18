namespace GenericsAndLinq
{
    public class Whale : Mammal, IAquatic, IJumpable
    {
        public Whale(Sex sex, string name, double weight, Diet diet, bool isHungry, int maxTimeUnderWater, int jumpingHeight)
              : base(sex, name, weight, diet, isHungry)
        {
            MaxTimeUnderwater = maxTimeUnderWater;
            JumpingHeight = jumpingHeight;
        }

        public int MaxTimeUnderwater { get; set; }
        public int JumpingHeight { get; set; }

        public string Jump()
        {
            return "How high?";
        }

        public string Jump(int height)
        {
            if (height < 0)
            {
                return "That's diving, not jumping.";
            }
            else if (height == 0)
            {
                return "You mean keep swimming?";
            }
            else if (height > JumpingHeight)
            {
                return "I cannot jump that high.";
            }
            else
            {
                return $"Okay, I will jump {height} meters up.";
            }
        }

        public string Sing()
        {
            return "OoooooooooOOOOOOH";
        }
    }
}