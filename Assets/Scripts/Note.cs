using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Note
{
    public string content;
    public string noteDate;

    
    // Zkontroluje, zda date zadaný v note je stejný jako reálný date
    public bool CheckDate()
    {
        string currDate = System.DateTime.UtcNow.ToString("dd.MM.yyyy");
        return noteDate == currDate;


    }
}
