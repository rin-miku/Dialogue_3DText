using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public static class CommonTools
{
    public static Vector3 GetRandomVector3()
    {
        return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }
}
