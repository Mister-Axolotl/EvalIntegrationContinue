using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riddle
{
    public class Riddle
    {
        private readonly int _secretNumber;
        private readonly int _min;
        private readonly int _max;

        public Riddle(int min = 1, int max = 100)
        {
            _min = min;
            _max = max;
            var random = new Random();
            _secretNumber = random.Next(_min, _max + 1);
        }

        public string Guess(string input)
        {
            if (!int.TryParse(input, out int number))
                return "Veuillez entrer un nombre valide.";

            if (number < _min || number > _max)
                return $"Veuillez deviner un nombre entre {_min} et {_max}.";

            if (number < _secretNumber)
                return "Plus haut !";

            if (number > _secretNumber)
                return "Plus bas !";

            return "Correct !";
        }
    }
}