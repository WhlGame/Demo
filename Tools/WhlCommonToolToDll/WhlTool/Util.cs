using UnityEngine;

public static class Util
{

    /// <summary>
    /// 设置Layer
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="layer"></param>
    public static void SetLayerInChildren(Transform transform, int layer)
    {
        transform.gameObject.layer = layer;
        for (int i = 0; i < transform.childCount; ++i)
            SetLayerInChildren(transform.GetChild(i), layer);
    }
    /// <summary>
    /// 设置Layer
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="layerName"></param>
    public static void SetLayerInChildren(Transform transform, string layerName)
    {
        SetLayerInChildren(transform, LayerMask.NameToLayer(layerName));
    }
    /// <summary>
    /// 查找子物体
    /// </summary>
    /// <param name="tr"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Transform SearchTransform(Transform tr, string name)
    {
        if (tr.name == name)
            return tr;
        foreach (var t in tr.GetComponentsInChildren<Transform>(true))
        {
            if (t == tr)
                continue;
            var ret = SearchTransform(t, name);
            if (ret != null)
                return ret;
        }
        return null;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="forward"></param>
    /// <returns></returns>
    static public Quaternion LookRotation(Vector3 forward)
    {
        if (forward.sqrMagnitude <= 0f)
        {
            Debuger.GameLogWarning("Look rotation viewing vector is zero!");
            return Quaternion.identity;
        }

        return Quaternion.LookRotation(forward);
    }
    /// <summary>
    /// 去掉(Clone)
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    static public string GetWithoutClone(string src)
    {
        if (!src.Contains("(Clone)"))
            return src;

        return src.Substring(0, src.IndexOf("(Clone)"));
    }
    /// <summary>
    /// 手动清除GC
    /// </summary>
    static public void GCCollect()
    {

        System.GC.Collect();
        System.GC.Collect();
        Resources.UnloadUnusedAssets();
        System.GC.Collect();
        System.GC.Collect();
    }
    /// <summary>
    /// float to int
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static int Ftoi(float val)
    {
        float temp = val;
        return (int)temp;
    }

    /// <summary>
    /// double to int
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static int DtoI(double val)
    {
        double tempD = val;
        float tempF = (float)tempD;
        return (int)tempF;
    }
    /// <summary>
    /// 获取iOSVersion
    /// </summary>
    /// <returns></returns>
    public static float GetiOSVersion()
    {
#if !UNITY_EDITOR && UNITY_IPHONE
		var version = -1f;
		string versionString = SystemInfo.operatingSystem.Replace("iPhone OS ", "");
		float.TryParse(versionString.Substring(0, 1), out version);
		
		return version;
#else
        return -1f;
#endif
    }
}
