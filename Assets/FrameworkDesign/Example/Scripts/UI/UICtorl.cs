using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace FrameworkDesign.Example
{

    public class UICtorl : MonoBehaviour
    {
        // Start is called before the first frame update

        private void OnEnable()
        {
            EventHandler.GameEndEvent += OnGameEndEvent;
        }
        private void OnDisable()
        {
            EventHandler.GameEndEvent -= OnGameEndEvent;

        }

        private void OnGameEndEvent()
        {
            transform.Find("Canvas/GamePassPanel").gameObject.SetActive(true);
        }

        void Start()
        {
            transform.Find("Canvas/GameStartPanel/Start").GetComponent<Button>().onClick.AddListener(() =>
            {
                transform.Find("Canvas/GameStartPanel").gameObject.SetActive(false);
                new StartGameCommand().Execute();
            });

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}