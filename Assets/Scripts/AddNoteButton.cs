using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddNoteButton : MonoBehaviour
{
    public InputField inputFieldPrefab;
    public NotesList notesList;


    // vytvoøí novou note
    public void AddNote()
    {
        Note note = new Note();
        notesList.AddNoteToList(note);
        var inputField = Instantiate(inputFieldPrefab);
        inputField.transform.SetParent(transform.parent.transform);
        inputField.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        inputField.note = note;
        inputField.SetInputFieldTextToContent();
    }
}
