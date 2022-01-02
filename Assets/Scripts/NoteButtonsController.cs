using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NoteButtonsController : MonoBehaviour
{
    public NotesList notesList;
    public NoteButton noteButtonPrefab;


    private void Awake()
    {
        SaveManager.Instance.Load();
        ReloadNoteButtons();
    }



    public void ReloadNoteButtons()
    {

        //znièí pøedchoží buttony, aby nevznikaly duplikáty
        var noteButtons = GameObject.FindObjectsOfType<NoteButton>();
        foreach(var noteButton in noteButtons)
        {
            Destroy(noteButton.gameObject);
        }

        //zmìní velikost rectTransformu pro scrollování podle poètu tlaèítek
        int y = 700;
        RectTransform rt;
        rt = GetComponent<RectTransform>();
        int notesCount = notesList.notesList.Count;
        rt.sizeDelta = new Vector3(1080, (notesCount * 350) + 200);
        float rtSizeY = rt.sizeDelta.y;
        float additionalRTSizeY = 0;
        if (rtSizeY > 1917.5f)
        {
            additionalRTSizeY = (rtSizeY - 1917.5f) / 2;
        }
        y += (int)additionalRTSizeY;
        rt.localPosition = new Vector2(0, -rt.sizeDelta.y / 2);





        //vytvoøí nový button pro každou note

        foreach (Note note in notesList.notesList)
        {
            NoteButton noteButton = Instantiate(noteButtonPrefab);
            noteButton.transform.SetParent(transform);
            noteButton.transform.localPosition = new Vector3(0, y, 0);
            y -= 350;
            noteButton.note = note;

            string s = note.content;
            var wordsArray = s.Split();
            string buttonTitle;
            if (wordsArray.Length >= 3)
            {
                buttonTitle = wordsArray[0] + " " + wordsArray[1] + " " + wordsArray[2];
            }
            else if(wordsArray.Length == 2)
            {
                buttonTitle = wordsArray[0] + " " + wordsArray[1];
            }
            else if(wordsArray.Length == 1)
            {
                buttonTitle = wordsArray[0];
            }
            else
            {
                buttonTitle = "";
            }
            if(noteButton.note.CheckDate())
            {
                noteButton.GetComponent<Image>().color = Color.red;
            }


            noteButton.GetComponentInChildren<TMP_Text>().text = buttonTitle;
        }
        SaveManager.Instance.Save();
    }
}
