using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Dialogue3DText dialoguePrefab;

    private void Start()
    {
        
    }

    public void PlayDialogue(string text)
    {
        PrefabUtility.InstantiatePrefab(dialoguePrefab,transform).GetComponent<Dialogue3DText>().SetDialogueInfo(text, Dialogue3DTheme.Player);
    }
}
