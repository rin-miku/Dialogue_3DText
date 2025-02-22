using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Dialogue mitaDialogue;
    public Dialogue playerDialogue;
    public float interval;

    private void Start()
    {
        StartCoroutine(DialogueTest());
    }

    private IEnumerator DialogueTest()
    {
        playerDialogue.PlayDialogue("过去都是假的，回忆是一条没有尽头的路");
        yield return new WaitForSeconds(interval);
        mitaDialogue.PlayDialogue("我年纪还轻，阅历不深，但我发现");
        yield return new WaitForSeconds(interval);
        playerDialogue.PlayDialogue("美是完整无缺的，丑是残缺不全的。");
        yield return new WaitForSeconds(interval);
        mitaDialogue.PlayDialogue("幸福的家庭都是相似的，不幸的家庭各有各的不幸。");
        yield return new WaitForSeconds(interval);
        playerDialogue.PlayDialogue("一个人可以被毁灭，但不能被打败。");
        yield return new WaitForSeconds(interval);
        mitaDialogue.PlayDialogue("一个单身汉，拥有可观的财富，必定想找个妻子");
        yield return new WaitForSeconds(interval);
        playerDialogue.PlayDialogue("都云作者痴，谁解其中味？");
        yield return new WaitForSeconds(interval);
    }
}
