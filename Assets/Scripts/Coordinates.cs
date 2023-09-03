using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways] //in play and edit mode 
public class Coordinates : MonoBehaviour
{

    TextMeshPro label; //text variable
    Vector2Int coordinates = new Vector2Int(); // tile coordinate 

    void Awake()
    {
        label = GetComponent<TextMeshPro>(); // get text 
    }
    
    void Update()
    {
        if(!Application.isPlaying) //code run only in edit mode  
        {
          DisplayCoordinates();//displays coordinates within class/label
          UpdateObjectName();//give tile coordinate name 
        }
        
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x); //get tile coordinate rounded up to whole number 
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z); //get tile coordinate rounded up to whole number
        label.text = coordinates.x + "," + " " + coordinates.y; // display coords
    }

    void UpdateObjectName() //name tile after its coordinate
    {
        transform.parent.name = coordinates.ToString(); // turn coordinate into string for name 
    }  
}
