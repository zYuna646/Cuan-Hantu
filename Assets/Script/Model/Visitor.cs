using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visitor 
{
    // Start is called before the first frame update
    public string Type { get; set; }
    public bool Gender { get; set; }

    public Visitor(string type = "Haunted",bool gender = true)
    {
        Type = type;
        Gender = gender;
    }
}
