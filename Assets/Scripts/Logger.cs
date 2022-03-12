using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class Logger : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] bool showLogs;
    [SerializeField] string prefix;
    [SerializeField] Color prefixColor;
    private string hexColor;

    private void OnValidate()
    {
        hexColor = "#" + ColorUtility.ToHtmlStringRGB(prefixColor);
    }

    private void DoLog(Action<string> LogFunction, Object obj, object msg)
    {
#if UNITY_EDITOR
        if (!showLogs) { return; }
        LogFunction($"<color={hexColor}> {prefix} ({obj.name})</color>: {msg}");
#endif
    }

    public void Log(Object obj, object msg) => DoLog(Debug.Log, obj, msg);

    public void LogWarning(Object obj, object msg) => DoLog(Debug.LogWarning, obj, msg);

    public void LogError(Object obj, object msg) => DoLog(Debug.LogError, obj, msg);
}