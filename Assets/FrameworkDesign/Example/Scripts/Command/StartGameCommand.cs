using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace FrameworkDesign.Example
{

    public class StartGameCommand : ICommand
    {
        public void Execute()
        {
            EventHandler.CallGameStartEvent();
        }
    }
}