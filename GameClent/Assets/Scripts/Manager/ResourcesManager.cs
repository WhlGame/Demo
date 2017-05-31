using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : Singleton<ResourcesManager>
{

    [SerializeField]
    private List<string> loadedObjectsPath = new List<string>();
    [SerializeField]
    private List<Object> loadedObjects = new List<Object>();
    private Dictionary<string, Object> loadedObjectDic = new Dictionary<string, Object>();
    public Object LoadObject(string path)
    {
        Object go = null;
        if (loadedObjectDic.ContainsKey(path))
        {
            go = loadedObjectDic[path];
        }
        else
        {
            go = Resources.Load(path);
            loadedObjectDic.Add(path, go);
            loadedObjects.Add(go);
            loadedObjectsPath.Add(path);
        }
        if (go == null)
        {
            Debuger.GameLogError(string.Format("Object at {0} is null!", path));
        }
        return go;
    }

}
