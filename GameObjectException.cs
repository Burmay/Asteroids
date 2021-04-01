using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class GameObjectException : Exception
    {
        public GameObjectException()
        {
            Console.WriteLine("Сгенерирована ебота. Убедистесь, что ваши руки растут не из жопы");
        }
    }
}
