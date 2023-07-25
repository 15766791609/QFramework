using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace FrameworkDesign.Example
{

    public static class EventHandler
    {
        public static Action GameStartEvent;
        public static void CallGameStartEvent()
        {
            GameStartEvent?.Invoke();
        }


        public static Action GameEndEvent;
        public static void CallGameEndEvent()
        {
            GameEndEvent?.Invoke();
        }

    }
}