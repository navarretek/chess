using System;
using System.Collections.Generic;
using System.Text;

namespace Global.Models
{
    public class MoveModel : PayloadModel
    {
        // Action
        public String Move;

        public MoveModel(string move, Guid userGuid, Guid matchGuid) : base(userGuid, matchGuid) 
        {
            Move = move;
        }

        public MoveModel()
        {
        }

        public override string ToString()
        {
            return $"User: {UserGuid.ToString()} - Match: {MatchGuid.ToString()} - Move: {Move} -";
        }
    }
}
