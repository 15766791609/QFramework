using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CounterApp;

namespace CounterAPp.Editor
{

    public class EditorCounterApp : EditorWindow
    {
        [MenuItem("EditorConterApp/Open")]
        static void Open()
        {
            var window = GetWindow<EditorCounterApp>();
            window.position = new Rect(100, 100, 400, 600);
            window.titleContent = new GUIContent(nameof(EditorCounterApp));
            window.Show(); 
        }

        private void OnGUI()
        {
            if(GUILayout.Button("+"))
            {
                new AddCountCommand().Execute();
            }

            GUILayout.Label(CounterModel.Instance.count.Value.ToString());

            if (GUILayout.Button("-"))
            {
                new SubCountCommand().Execute();
            }
        }
    }

}