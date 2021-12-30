using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Actions
{
    public interface IAction
    {
        ActionType PlayerAction(Party friends, Party enemies);

        ActionType ComputerAction(Party friends, Party enemies);
    }
}
