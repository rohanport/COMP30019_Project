﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallFall
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var program = new BallFall_Game())
                program.Run();
        }
    }
}
