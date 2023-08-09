using UnityEditor;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IncludeMissingObjects : EditorWindow
{
    private static List<int> missingScriptObject = new List<int>();
    static int index = -1;
    private GameObject prefab;

    [MenuItem("Tools/���Ҷ�ʧ����")]
    private static void OpenWindow()
    {
        GetWindow<IncludeMissingObjects>("��ѯ��ʧ��������");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("������ʧ��������"))
        {
            FindObjects();
            index = -1;
            SelectObject();
        }
        if (GUILayout.Button("ѡ����һ����ʧ��������"))
        {
            SelectObject();
        }
        GUILayout.BeginHorizontal("HelpBox");

        //Ԥ���������
        prefab = EditorGUILayout.ObjectField("Prefab", prefab, typeof(GameObject), false) as GameObject;
        GUILayout.Space(10);
        
        if (GUILayout.Button("���"))
        {
            CheckPrefab();
        }
        GUILayout.EndHorizontal();

    }

    private void FindObjects()
    {
        GameObject[] rootObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        missingScriptObject.Clear();

        foreach (GameObject rootObject in rootObjects)
        {
            FindObjectsRecursive(rootObject);
        }
    }

    /// <summary>
    /// �ж��Ƿ�����������ʧ
    /// </summary>
    /// <param name="gameObject"></param>
    private void FindObjectsRecursive(GameObject gameObject)
    {
        Component[] components = gameObject.GetComponents<Component>();

        foreach (Component component in components)
        {
            if (component == null)
            {
                missingScriptObject.Add(gameObject.GetInstanceID());
            }
        }

        //Ѱ���������еĵ��ļ�
        Transform transform = gameObject.transform;
        int childCount = transform.childCount;
        if (childCount > 0)
        {
            for (int i = 0; i < childCount; i++)
            {
                Transform childTransform = transform.GetChild(i);
                FindObjectsRecursive(childTransform.gameObject);
            }
        }
    }

    [InitializeOnLoadMethod]
    private static void RegisterHierarchy()
    {
        EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyWindowItemOnGUI;
    }
    private static void UnRegisterHierarchy()
    {
        EditorApplication.hierarchyWindowItemOnGUI -= OnHierarchyWindowItemOnGUI;
    }
    private static void OnHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
    {
        GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        if (gameObject != null && ArrayContainsGameObjectID(gameObject.GetInstanceID()))
        {
            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.normal.textColor =new Color(0.6f,0.4f,0.3f,1);
            EditorGUI.DrawRect(selectionRect, new Color(0.9f, 0.9f, 0.9f, 1f));
            EditorGUI.LabelField(selectionRect, gameObject.name, style);
        }
    }

    private static bool ArrayContainsGameObjectID(int ID)
    {
        foreach (int gameObjectID in missingScriptObject)
        {
            if (ID == gameObjectID)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// ѡ����һ������
    /// </summary>
    private static void SelectObject()
    {
        if (missingScriptObject.Count == 0) return;
        if (index < missingScriptObject.Count - 1)
            index++;
        else index = 0;
        // ����Ŀ������
        GameObject targetObject = EditorUtility.InstanceIDToObject(missingScriptObject[index]) as GameObject;
            if (targetObject != null)
            {
                // ������ѡ��Ŀ������
                EditorGUIUtility.PingObject(targetObject);
                Selection.activeGameObject = targetObject;
            }
    }



    /// <summary>
    /// ���Ԥ�����Ƿ�ʧ����
    /// </summary>
    private void CheckPrefab()
    {
        if (prefab == null)
        {
            EditorUtility.DisplayDialog("��ʾ", "�����Ҫ����Ԥ����", "ok");
            return;
        }

        Component[] components = prefab.GetComponents<Component>();

        foreach (Component component in components)
        {
            if (component == null)
            {
                EditorUtility.DisplayDialog("������ʾ","��Ԥ������ڴ��붪ʧ","ok");
                Debug.Log("Ԥ���嶪ʧ����: " + prefab.gameObject.name);
                return;
            }
        }
        Debug.Log("Ԥ��������: " + prefab.gameObject.name);

    }

}
