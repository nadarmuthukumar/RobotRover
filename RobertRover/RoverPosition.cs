using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertRover
{
    //Enum to get Direction
    enum Directions
    {
        N = 1,  //North
        S = 2,  //South
        E = 3,  //East
        W = 4   //West
    }

    public class RoverPosition : IRoverPosition
    {
        // Only L and R moving directions are valid
        char[] movingDirection = new char[] { 'L', 'R' };

        // Contains cordination woth Direction
        public Dictionary<string, int> cordinateWithDirection = new Dictionary<string, int>();

        public RoverPosition()
        {
            // Set default cordination and direction
            cordinateWithDirection.Add("X", 10);
            cordinateWithDirection.Add("Y", 10);
            cordinateWithDirection.Add("D", Convert.ToInt32(Directions.N));
        }

        // [3 3 N] 
        // [x y D]
        // R1R9L2R9L2R9
        // [4 3 E] [11 7 S] [13 7 E] [13 8 N]
        public string Move(string commands)
        {
            string finalPosition = string.Empty;
            // Validation to check input should not be empty
            if (string.IsNullOrEmpty(commands))
            {
                return "Provide input command";
            }
            // Validation to check input should not be incomplete
            if (commands.Length % 2 != 0)
            {
                return "Incomplete command given";
            }

            for (int i = 1; i < commands.Length; i = i + 2)
            {
                // Validation to check moving direction should be only L / R
                if (!movingDirection.Contains(commands[i - 1]))
                {
                    return "Invalid moving direction";
                }
                // Validation to check input step should be proper
                if (!Char.IsDigit(commands, i))
                {
                    return "Invalid Moving step";
                }

                try
                {
                    SetPosition(commands[i - 1], Convert.ToInt32(commands[i].ToString()));
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }

            finalPosition = "[";
            foreach (var item in cordinateWithDirection)
            {
                if (item.Key == "D")
                {
                    switch (item.Value)
                    {
                        case 1:
                            finalPosition += " N";
                            break;
                        case 2:
                            finalPosition += " S";
                            break;
                        case 3:
                            finalPosition += " E";
                            break;
                        case 4:
                            finalPosition += " W";
                            break;
                        default:
                            break;
                    }
                }
                else
                    finalPosition += " " + item.Value;
            }
            finalPosition += " ]";
            return finalPosition;
        }

        public void SetPosition(char movingDirection, int steps)
        {
            if ((movingDirection == 'R' && cordinateWithDirection["D"] == 1) || (movingDirection == 'L' && cordinateWithDirection["D"] == 2))
            {
                cordinateWithDirection["X"] = cordinateWithDirection["X"] + steps;
                cordinateWithDirection["D"] = Convert.ToInt32(Directions.E);
            }
            else if ((movingDirection == 'R' && cordinateWithDirection["D"] == 2) || (movingDirection == 'L' && cordinateWithDirection["D"] == 1))
            {
                if (cordinateWithDirection["X"] - steps < 0)
                    throw new Exception("Impermissible Movement");
                cordinateWithDirection["X"] = cordinateWithDirection["X"] - steps;
                cordinateWithDirection["D"] = Convert.ToInt32(Directions.W);
            }
            else if ((movingDirection == 'R' && cordinateWithDirection["D"] == 3) || (movingDirection == 'L' && cordinateWithDirection["D"] == 4))
            {
                // If final Y cordinator is less than 0 then it will be improper move
                if (cordinateWithDirection["Y"] - steps < 0)
                    throw new Exception("Impermissible Movement");
                cordinateWithDirection["Y"] = cordinateWithDirection["Y"] - steps;
                cordinateWithDirection["D"] = Convert.ToInt32(Directions.S);
            }
            else if ((movingDirection == 'R' && cordinateWithDirection["D"] == 4) || (movingDirection == 'L' && cordinateWithDirection["D"] == 3))
            {
                // If final Y cordinator is less than 0 then it will be improper move
                cordinateWithDirection["Y"] = cordinateWithDirection["Y"] + steps;
                cordinateWithDirection["D"] = Convert.ToInt32(Directions.N);
            }

        }

    }

}