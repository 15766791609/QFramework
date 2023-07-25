using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FrameworkDesign.Example
{
    public class Enemy : MonoBehaviour
    {
        public GameObject gameEndPanel;
      

        private void OnMouseDown()
        {
            Destroy(gameObject);
           new KillEnemyCommand().Execute();
        }
    }

}
