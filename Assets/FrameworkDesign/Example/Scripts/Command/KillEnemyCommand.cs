using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign.Example
{

    public class KillEnemyCommand : ICommand
    {
        public void Execute()
        {
            GameModel.Instance.KillCourt.Value++;
            if (GameModel.Instance.KillCourt.Value == 10)
                EventHandler.CallGameEndEvent();
        }

    }
}