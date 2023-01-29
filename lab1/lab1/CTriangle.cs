using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class CTriangle
    {
        private double firstSide = 0;
        public double FirstSide 
        {
            get
            {
                return firstSide;
            }

            set
            {
                firstSide = value;
            }
        }

        private double secondSide = 0;
        public double SecondSide
        {
            get
            {
                return secondSide;
            }

            set
            {
                secondSide = value;
            }
        }

        private double thirdSide = 0;
        public double ThirdSide
        {
            get
            {
                return thirdSide;
            }

            set
            {
                thirdSide = value;
            }
        }

        private String type = "";

        public String GetTypeTriangle()
        {
            
            if (firstSide == SecondSide && SecondSide == ThirdSide)
            {
                type = "равносторонний";
            }
            else if (firstSide == SecondSide || SecondSide == ThirdSide || firstSide == ThirdSide)
            {
                type = "равнобедренный";
            }
            else 
            {
                type = "обычный";
            }

            return type;
        }

        public bool IsTriangle()
        {
            try
            {
                return (checked(firstSide + SecondSide) > ThirdSide) && (checked(firstSide + ThirdSide) > SecondSide) && (checked(SecondSide + ThirdSide) > firstSide);
            }
            catch
            {
                return false;
            }
        }
    }
}
