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
        mitaDialogue.SetDialogueInfo("Ŷ�����Ѿ�������");
        yield return new WaitForSeconds(interval);
        playerDialogue.SetDialogueInfo("����ôͻȻ�͵��������ˣ�");
        yield return new WaitForSeconds(interval);
        playerDialogue.SetDialogueInfo("��ոջ��������");
        yield return new WaitForSeconds(interval);
        mitaDialogue.SetDialogueInfo("��");
        yield return new WaitForSeconds(interval);
        mitaDialogue.SetDialogueInfo("��ղ��ھ���ǰ��ס��");
        yield return new WaitForSeconds(interval);
        mitaDialogue.SetDialogueInfo("�Ҿ����߿���");
        yield return new WaitForSeconds(interval);
        playerDialogue.SetDialogueInfo("�Ƿ�������ô���£�");
        yield return new WaitForSeconds(interval);
        mitaDialogue.SetDialogueInfo("���޸���һ�²���");
        yield return new WaitForSeconds(interval);
        mitaDialogue.SetDialogueInfo("����������˵����Щ");
        yield return new WaitForSeconds(interval);
        playerDialogue.SetDialogueInfo("��û��Ҫ��������");
        yield return new WaitForSeconds(interval);
        playerDialogue.SetDialogueInfo("����ʵ���Ѿ���ʼϰ����");
        yield return new WaitForSeconds(interval);
        mitaDialogue.SetDialogueInfo("�Ҿ�����������������Щ��");
        yield return new WaitForSeconds(interval);
    }
}
