using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

    public static SaveManager Instance { get; set; }

    public static SaveState state;

    public NotesList notesList;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;

        Debug.Log(Helper.Serialize<SaveState>(state));
    }


    // Ud�l� nov� save
    public void Save()
    {
        state.notesList = notesList.notesList;
        PlayerPrefs.SetString("save", Helper.Serialize<SaveState>(state));
    }


    // Nahraje p�edchoz� save
    public void Load()
    {
        if(PlayerPrefs.HasKey("save"))
        {
            state = Helper.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
            notesList.notesList = state.notesList;
        }
        else
        {
            state = new SaveState();
            Save();
            Debug.Log("no save file found, creating a new one!");
        }
    }

}
