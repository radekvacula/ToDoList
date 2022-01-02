using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteButton : MonoBehaviour
{
    public Note note;
    public InputField inputFieldPrefab;
    public InputField inputFieldDate;


    //otevøe note content a umožní ho upravit
    public void OpenContent()
    {
        var inputField = Instantiate(inputFieldPrefab);
        inputField.transform.SetParent(transform.parent.transform);
        inputField.GetComponent<RectTransform>().localPosition = new Vector3(0,0,0);
        inputField.note = note;
        inputField.SetInputFieldTextToContent();
    }
}
