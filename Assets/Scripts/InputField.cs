using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputField : MonoBehaviour
{

    public TMP_InputField inputField;
    public TMP_InputField inputFieldDate;
    public Note note;
    public NotesList notesList;


    // nastaví obsah input fieldu na content
    public void SetInputFieldTextToContent()
    {
        inputField.text = note.content;
        inputFieldDate.text = note.noteDate;
        Debug.Log(note.CheckDate());
    }

    // potvrdí nový note content
    public void SubmitInputField()
    {
        note.content = inputField.text;
        note.noteDate = inputFieldDate.text;
        FindObjectOfType<NoteButtonsController>().ReloadNoteButtons();
        Destroy(gameObject);
    }
    //vymaže note 
    public void DeleteNote()
    {
        notesList.RemoveNoteFromList(note);
        FindObjectOfType<NoteButtonsController>().ReloadNoteButtons();
        Destroy(gameObject);
    }




}
