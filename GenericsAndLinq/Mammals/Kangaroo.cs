using System;
using System.Collections.Generic;

namespace GenericsAndLinq
{
    public class Kangaroo : Mammal, IMarsupial, IJumpable
    {
        public Kangaroo(Sex sex, string name, double weight, Diet diet, bool isHungry, int jumpingHeight, List<IMarsupial> babiesInPouch) : base(sex, name, weight, diet, isHungry)
        {
            if (sex == Sex.Male)
            {
                throw new ArgumentException("Male kangaroos do not have pouches.");
            }
            JumpingHeight = jumpingHeight;
            if (!babiesInPouch.TrueForAll(baby => baby is Kangaroo))
            {
                throw new ArgumentException("Wrong kind of marsupial!");
            }
            BabiesInPouch = babiesInPouch;
        }

        public Kangaroo(Sex sex, string name, double weight, Diet diet, bool isHungry, int jumpingHeight) : base(sex, name, weight, diet, isHungry)
        {
            JumpingHeight = jumpingHeight;
        }

        public List<IMarsupial> BabiesInPouch { get; set; }
        public int JumpingHeight { get; set; }

        public override string Feed(Diet food)
        {
            if (food == Diet.Milk && BabiesInPouch.Count > 0)
            {
                return "Thank you for feeding my baby!";
            }
            else if (food != Diet)
            {
                return "I don't like this food!";
            }
            else if (!IsHungry)
            {
                return "I don't want to eat right now.";
            }
            else
            {
                return "Yum! Thank you!";
            }
        }

        public List<string> FeedBabies(Diet food)
        {
            List<string> response = new List<string>();

            foreach (var baby in BabiesInPouch)
            {
                if (food != Diet.Milk)
                {
                    response.Add("My baby can't eat this.");
                }
                else if ((baby as Mammal).IsHungry)
                {
                    response.Add("Thank you for feeding my baby!");
                }
                else
                {
                    response.Add("My baby is not hungry right now.");
                }
            }
            return response;
        }

        public string Jump()
        {
            return "How high?";
        }

        public string Jump(int height)
        {
            if (height < 0)
            {
                return "That's digging, not jumping.";
            }
            else if (height == 0)
            {
                return "You mean stand still?";
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

        public IMarsupial TransformBabyToAdult()
        {
            if (BabiesInPouch is null || BabiesInPouch.Count < 1)
            {
                throw new ArgumentException("No babies to transform!");
            }
            IMarsupial grownUpBaby = BabiesInPouch[0];
            BabiesInPouch.RemoveAt(0);
            (grownUpBaby as Kangaroo).Diet = Diet.Herbivore;
            return grownUpBaby;
        }

        public List<IMarsupial> TransformBabyToAdult(bool allBabies)
        {
            List<IMarsupial> grownUpBabies = new List<IMarsupial>();
            if (BabiesInPouch is null || BabiesInPouch.Count < 1)
            {
                throw new ArgumentException("No babies to transform!");
            }
            for (int i = 0; i < BabiesInPouch.Count; i++)
            {
                (BabiesInPouch[i] as Kangaroo).Diet = Diet.Herbivore;
                grownUpBabies.Add(BabiesInPouch[i]);
            }
            BabiesInPouch.Clear();
            return grownUpBabies;
        }
    }
}