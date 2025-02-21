using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public enum Dialogue3DTheme
{
    Default,
    Mita,
    Player,
    ChibiMita
}

public class Dialogue3DText : MonoBehaviour
{
    [Header("Dialogue")]
    public float showTime = 3f;
    public float waitFadeOutTime = 2f;
    public float waitDestroyTime = 0.5f;
    public bool lookOnPlayer = false;

    [Header("Symbol")]
    public GameObject symbolPrefab;
    public float fadeInInterval = 0.35f;
    public float jumpInterval = 0f;
    public float fadeOutInterval = 0.35f;

    private float sizeHeight = 3.3f;
    private float sizeWidth = 3.3f;
    private int symbolCount;
    private Transform globalDialogueRoot;
    private List<DialogueSymbol> symbolObjects = new List<DialogueSymbol>();

    void Start()
    {
        globalDialogueRoot = GameObject.Find("GlobalDialogueRoot").transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            SetDialogueInfo("雨是很少见？！雨是很少见？！", Dialogue3DTheme.Player);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {

        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            
        }

        if (lookOnPlayer)
        {
            // 计算从 UI 到玩家的方向向量
            Transform player = GameObject.Find("Player").transform;
            Vector3 direction = (player.position - transform.position).normalized;
            // 只在 Y 轴上旋转
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, lookRotation.eulerAngles.y, transform.eulerAngles.z);
        }
    }

    public void SetDialogueInfo(string text, Dialogue3DTheme theme)
    {
        int index = 0;
        symbolCount = text.Length - 1;
        symbolObjects.Clear();

        while (index <= symbolCount)
        {
            char c = text[index];

            DialogueSymbol symbol = PrefabUtility.InstantiatePrefab(symbolPrefab, transform).GetComponent<DialogueSymbol>();
            symbolObjects.Add(symbol);
            symbol.SetSymbol(c, theme);
            symbol.transform.localPosition = new Vector3(index * sizeWidth - symbolCount * sizeWidth * 0.5f, 0f, 0f);

            index++;
        }

        StartCoroutine(FadeInAnimation());
    }

    private IEnumerator FadeInAnimation()
    {
        foreach(DialogueSymbol symbol in symbolObjects)
        {
            symbol.FadeInAnimation();
            yield return new WaitForSeconds(fadeInInterval);
        }

        yield return new WaitForSeconds(showTime);

        StartCoroutine(JumpAnimation());
    }

    private IEnumerator JumpAnimation()
    {
        transform.parent = globalDialogueRoot.transform;
        foreach (DialogueSymbol symbol in symbolObjects)
        {
            symbol.JumpAnimation();
            yield return new WaitForSeconds(jumpInterval);
        }

        yield return new WaitForSeconds(waitFadeOutTime);

        StartCoroutine(FadeOutAnimation());
    }

    private IEnumerator FadeOutAnimation()
    {
        foreach (DialogueSymbol symbol in symbolObjects)
        {
            symbol.FadeOutAnimation();
            yield return new WaitForSeconds(fadeOutInterval);
        }

        yield return new WaitForSeconds(waitDestroyTime);

        Destroy(gameObject);
    }
}
