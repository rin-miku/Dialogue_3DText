using System.Collections;
using System.Collections.Generic;
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
    public float waitDestroyTime = 2f;
    public bool lookOnPlayer;
    public Dialogue3DTheme theme;

    [Header("Symbol")]
    public GameObject symbolPrefab;
    public float fadeInInterval = 0.05f;
    public float jumpInterval = 0f;
    public float fadeOutInterval = 0.05f;

    private float sizeHeight = 3.3f;
    private float sizeWidth = 3.3f;
    private Transform globalDialogueRoot;
    private Transform playerTransform;
    private Transform dialogueRoot;

    private void Start()
    {
        globalDialogueRoot = GameObject.Find("GlobalDialogueRoot").transform;
        playerTransform = GameObject.Find("Player").transform;
        dialogueRoot = transform.GetChild(0);
    }

    private void Update()
    {
        if (lookOnPlayer)
        {
            LookOnPlayerHandler();
        }
    }

    private void LookOnPlayerHandler()
    {
        Vector3 direction = playerTransform.position - transform.position;

        if (direction.magnitude < 0.01f) return;

        Quaternion targetRotation = Quaternion.LookRotation(-direction);
        targetRotation.x = 0;
        targetRotation.z = 0;

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);
    }

    public void SetDialogueInfo(string text)
    {
        int index = 0;
        int symbolCount = text.Length - 1;
        List<DialogueSymbol> dialogueSymbolList = new List<DialogueSymbol>();

        while (index <= symbolCount)
        {
            char c = text[index];

            DialogueSymbol symbol = Instantiate(symbolPrefab, dialogueRoot).GetComponent<DialogueSymbol>();
            dialogueSymbolList.Add(symbol);
            symbol.SetSymbol(c, theme);
            symbol.transform.localPosition = new Vector3(index * sizeWidth - symbolCount * sizeWidth * 0.5f, 0f, 0f);

            index++;
        }

        StartCoroutine(FadeInAnimation(dialogueSymbolList));
    }

    private IEnumerator FadeInAnimation(List<DialogueSymbol> dialogueSymbolList)
    {
        foreach (DialogueSymbol symbol in dialogueSymbolList)
        {
            symbol.FadeInAnimation();
            yield return new WaitForSeconds(fadeInInterval);
        }

        yield return new WaitForSeconds(showTime);

        StartCoroutine(JumpAnimation(dialogueSymbolList));
    }

    private IEnumerator JumpAnimation(List<DialogueSymbol> dialogueSymbolList)
    {
        foreach (DialogueSymbol symbol in dialogueSymbolList)
        {
            symbol.transform.parent = globalDialogueRoot.transform;
            symbol.JumpAnimation();
            yield return new WaitForSeconds(jumpInterval);
        }

        yield return new WaitForSeconds(waitFadeOutTime);

        StartCoroutine(FadeOutAnimation(dialogueSymbolList));
    }

    private IEnumerator FadeOutAnimation(List<DialogueSymbol> dialogueSymbolList)
    {
        foreach (DialogueSymbol symbol in dialogueSymbolList)
        {
            symbol.FadeOutAnimation();
            yield return new WaitForSeconds(fadeOutInterval);
        }

        yield return new WaitForSeconds(waitDestroyTime);

        foreach (DialogueSymbol symbol in dialogueSymbolList)
        {
            Destroy(symbol.gameObject);
        }
    }
}
