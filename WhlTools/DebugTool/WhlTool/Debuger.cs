using System;

public class Debuger
{
    /// <summary>
    /// 打印消息程序集，分为游戏中，UI和网络
    /// </summary>
    public enum LogType
    {
        Game,
        UI,
        Network,
    }
    private static bool logEnable = true;
    public static bool LogEnable
    {
        get
        {
            return logEnable;
        }
        private set
        {
            logEnable = value;
        }
    }
    /// <summary>
    /// 设置是否打印信息
    /// </summary>
    /// <param name="enbale"></param>
    public static void SetLogEnable(bool enbale)
    {
        logEnable = enbale;
    }
    public static void Break()
    {
        if (LogEnable)
            UnityEngine.Debug.Break();
    }

    public static void ClearDeveloperConsole()
    {
        if (LogEnable)
            UnityEngine.Debug.ClearDeveloperConsole();
    }
    public static void DebugBreak()
    {
        if (LogEnable)
            UnityEngine.Debug.DebugBreak();
    }


    public static void LogException(Exception exception, UnityEngine.Object context)
    {
        if (LogEnable)
        {
            UnityEngine.Debug.LogException(exception);
        }
    }

    public static void GameLog(object msg, UnityEngine.Object context = null)
    {
        Log(LogType.Game, msg, context);
            
    }
    public static void GameLogWarning(object msg, UnityEngine.Object context = null)
    {
        LogWarning(LogType.Game, msg, context);

    }
    public static void GameLogError(object msg, UnityEngine.Object context = null)
    {
        LogError(LogType.Game, msg, context);

    }

    public static void UILog(object msg, UnityEngine.Object context = null)
    {
        Log(LogType.UI, msg, context);

    }
    public static void UILogWarning(object msg, UnityEngine.Object context = null)
    {
        LogWarning(LogType.UI, msg, context);

    }
    public static void UILogError(object msg, UnityEngine.Object context = null)
    {
        LogError(LogType.UI, msg, context);

    }

    public static void NetLog(object msg, UnityEngine.Object context = null)
    {
        Log(LogType.Network, msg, context);

    }
    public static void NetLogWarning(object msg, UnityEngine.Object context = null)
    {
        LogWarning(LogType.Network, msg, context);

    }
    public static void NetLogError(object msg, UnityEngine.Object context = null)
    {
        LogError(LogType.Network, msg, context);

    }
    private static void Log(LogType logType, object msg, UnityEngine.Object context = null)
    {
        if (LogEnable)
        {
            if (context == null)
            {
                UnityEngine.Debug.Log(string.Format("[{0}]:",logType) + msg);
            }
            else
            {
                UnityEngine.Debug.Log(string.Format("[{0}]:",logType) + msg, context);
            }
        }
    }
    private static void LogError(LogType logType, object msg, UnityEngine.Object context = null)
    {
        if (LogEnable)
        {
            if (context == null)
            {
                UnityEngine.Debug.LogError(string.Format("[{0}]:",logType) + msg);
            }
            else
            {
                UnityEngine.Debug.LogError(string.Format("[{0}]:",logType) + msg, context);
            }
        }
    }
    private static void LogWarning(LogType logType, object msg, UnityEngine.Object context = null)
    {
        if (LogEnable)
        {
            if (context == null)
            {
                UnityEngine.Debug.LogWarning(string.Format("[{0}]:",logType) + msg);
            }
            else
            {
                UnityEngine.Debug.LogWarning(string.Format("[{0}]:",logType) + msg, context);
            }
        }
    }
}

