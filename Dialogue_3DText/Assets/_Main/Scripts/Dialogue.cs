using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject dialoguePrefab;
    public Dialogue3DTheme theme;
    public bool lookOnPlayer;

    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (lookOnPlayer)
        {
            LookOnPlayerHandler();
        }
    }

    public void PlayDialogue(string text)
    {       
        Instantiate(dialoguePrefab, transform).GetComponent<Dialogue3DText>().SetDialogueInfo(text, theme);
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
}
