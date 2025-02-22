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
        playerDialogue.PlayDialogue("��ȥ���Ǽٵģ�������һ��û�о�ͷ��·");
        yield return new WaitForSeconds(interval);
        mitaDialogue.PlayDialogue("����ͻ��ᣬ����������ҷ���");
        yield return new WaitForSeconds(interval);
        playerDialogue.PlayDialogue("����������ȱ�ģ����ǲ�ȱ��ȫ�ġ�");
        yield return new WaitForSeconds(interval);
        mitaDialogue.PlayDialogue("�Ҹ��ļ�ͥ�������Ƶģ����ҵļ�ͥ���и��Ĳ��ҡ�");
        yield return new WaitForSeconds(interval);
        playerDialogue.PlayDialogue("һ���˿��Ա����𣬵����ܱ���ܡ�");
        yield return new WaitForSeconds(interval);
        mitaDialogue.PlayDialogue("һ��������ӵ�пɹ۵ĲƸ����ض����Ҹ�����");
        yield return new WaitForSeconds(interval);
        playerDialogue.PlayDialogue("�������߳գ�˭������ζ��");
        yield return new WaitForSeconds(interval);
    }
}
