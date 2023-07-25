using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign.Example
{
    
    public class Game : MonoBehaviour
    {
        private void OnEnable()
        {
            EventHandler.GameStartEvent += OnGameStartEvent;
            //GameModel.KillCourt.OnValueChanged += OnKillOneEnemyEvent;    
        }
        private void OnDisable()
        {
            EventHandler.GameStartEvent -= OnGameStartEvent;
            //GameModel.KillCourt.OnValueChanged -= OnKillOneEnemyEvent;
        }

        //private void OnKillOneEnemyEvent(int killCount)
        //{
        //    if (killCount == 10)
        //        new PassGameCommand().Execute();
        //}
        private void OnGameStartEvent()
        {
            transform.Find("Enemys").gameObject.SetActive(true);
        }
    }

}