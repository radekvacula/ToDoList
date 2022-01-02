using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Notes List", menuName = "ScriptableObjects/NotesList")]

public class NotesList : ScriptableObject
{
    public List<Note> notesList = new List<Note>();


    // pøidá do listu novou note
    public void AddNoteToList(Note note)
    {
        if(!notesList.Contains(note))
        {
            notesList.Add(note);
        }
    }

    // odstraní z listu note
    public void RemoveNoteFromList(Note note)
    {

        if (notesList.Contains(note))
        {
            notesList.Remove(note);
        }
    }
}
