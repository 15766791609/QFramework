using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign
{

    public class ICOExample : MonoBehaviour
    {
        void Start()
        {
            var container = new IOCCOntainer();

            container.Register(new BluetoothManager());

            var bluetoothManager = container.Get<BluetoothManager>();

            bluetoothManager.Connect();
        }

        public class BluetoothManager
        {
            public void Connect()
            {
                Debug.Log("Success");
            }
        }
    }
}