using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertRover
{
    public interface IRoverPosition
    {
        string Move(string commands);
        void SetPosition(char movingDirection, int steps);
    }
}
