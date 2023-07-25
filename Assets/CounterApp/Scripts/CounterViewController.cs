using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using FrameworkDesign;

namespace CounterApp
{

    public class CounterViewController : MonoBehaviour
    {
        public Button Add;
        public Button Sub;
        private void OnEnable()
        {
            CounterModel.Instance.count.OnValueChanged += OnCountChanger;
        }
        private void OnDisable()
        {
            CounterModel.Instance.count.OnValueChanged -= OnCountChanger;

        }

        private void OnCountChanger(int newCount)
        {
            transform.Find("CountText").GetComponent<Text>().text = newCount.ToString();
        }

        void Start()
        {
            //UpdateView();
            OnCountChanger(CounterModel.Instance.count.Value);
            //Add.onClick.AddListener(() => { CounterModel.Count++; UpdateView(); });
            //Sub.onClick.AddListener(() => { CounterModel.Count--; UpdateView(); });
            Add.onClick.AddListener(() => 
            {
                //CounterModel.count.Value++;
                new AddCountCommand().Execute();
            });
            Sub.onClick.AddListener(() => 
            {
                //CounterModel.count.Value --;
                new SubCountCommand().Execute();
            });
        }

        //private void UpdateView()
        //{
        //    transform.Find("CountText").GetComponent<Text>().text = CounterModel.Count.ToString();
        //}

    }

    public  class CounterModel: Singleton<CounterModel>
    {
        private CounterModel() { }
        public BindableProperty<int> count = new BindableProperty<int>()
        {
            Value = 0
        };


        //public static Action<int> OnCountChanger;
        //public static int Count
        //{
        //    get
        //    {
        //        return count;
        //    }
        //    set
        //    {
        //        if(value!= count)
        //        {
        //            count = value;
        //            OnCountChanger?.Invoke(value);
        //        }
        //    }
        //}
    }
}