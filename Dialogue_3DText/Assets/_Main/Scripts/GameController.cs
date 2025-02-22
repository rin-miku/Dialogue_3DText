using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Dialogue3DText mitaDialogue;
    public Dialogue3DText playerDialogue;
    public float interval;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(DialogueTest());
        }
    }

    private IEnumerator DialogueTest()
    {
        mitaDialogue.SetDialogueInfo("哦，你已经醒了吗？");
        yield return new WaitForSeconds(interval);
        playerDialogue.SetDialogueInfo("你怎么突然就到这里来了？");
        yield return new WaitForSeconds(interval);
        playerDialogue.SetDialogueInfo("你刚刚还在我身边");
        yield return new WaitForSeconds(interval);
        mitaDialogue.SetDialogueInfo("不");
        yield return new WaitForSeconds(interval);
        mitaDialogue.SetDialogueInfo("你刚才在镜子前卡住了");
        yield return new WaitForSeconds(interval);
        mitaDialogue.SetDialogueInfo("我就先走开了");
        yield return new WaitForSeconds(interval);
        playerDialogue.SetDialogueInfo("那房间是怎么回事？");
        yield return new WaitForSeconds(interval);
        mitaDialogue.SetDialogueInfo("我修改了一下布局");
        yield return new WaitForSeconds(interval);
        mitaDialogue.SetDialogueInfo("这样对你来说方便些");
        yield return new WaitForSeconds(interval);
        playerDialogue.SetDialogueInfo("你没必要这样做的");
        yield return new WaitForSeconds(interval);
        playerDialogue.SetDialogueInfo("我其实都已经开始习惯了");
        yield return new WaitForSeconds(interval);
        mitaDialogue.SetDialogueInfo("我觉得这样会让你更舒服些。");
        yield return new WaitForSeconds(interval);
    }
}
