using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class experimentExample : MonoBehaviour
{

    float horizontalLength = 0.15f;
    float verticalHeight = 0.15f;
    
    
    // Start is called before the first frame update
    void Start()
    {
     createStimuli(horizontalLength, verticalHeight);
    }

    
    
    // Update is called once per frame
    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.S)){
            Destroy(GameObject.Find ("horizontalStimulus").gameObject);
            Destroy(GameObject.Find ("verticalStimulus").gameObject);
            createStimuli(horizontalLength, verticalHeight);
            // Write to text file           
           // System.IO.File.WriteAllText("C:/media/lab3dipa/hdd1/Program Files/unity3d/Projects/Illusion Room/TextFiles/textfile.txt", "hi" + ", " + "bye");
            // https://answers.unity.com/questions/130311/create-text-file.html
            
            
        }
    }
    
    
    // generate the line stimuli
    public void createStimuli(float length, float height){
    //initialize horizontal line
        GameObject horizontalStimulus = GameObject.CreatePrimitive(PrimitiveType.Cube);
        horizontalStimulus.transform.position = new Vector3(0.745f, 0.78f, 1.244f); // initialize position
        horizontalStimulus.transform.localScale = new Vector3(length, 0.01f, 0.01f); // change its local scale in x y z format
        horizontalStimulus.GetComponent<Renderer>().material.color = Color.black; // initialize its color
        horizontalStimulus.name = "horizontalStimulus";
    //initialize vertical line
        GameObject verticalStimulus = GameObject.CreatePrimitive(PrimitiveType.Cube);
        verticalStimulus.transform.position = new Vector3(0.745f, 0.78f, 1.244f - height/2); // initialize position
        verticalStimulus.transform.localScale = new Vector3(0.01f, 0.01f, height); // change its local scale in x y z format
        verticalStimulus.GetComponent<Renderer>().material.color = Color.black; // initialize its color    
        verticalStimulus.name = "verticalStimulus";
        

    
    }
    
    // Create a text file 
    // https://www.google.com/search?client=ubuntu&channel=fs&q=how+to+create+and+write+to+txt+file+unity&ie=utf-8&oe=utf-8#kpvalbx=_ykNYXt25JOuQggfuy4jwAw27
    void CreateText(){
        // file path
        string path =  Application.dataPath + "/Results.txt";
        //create file
        if(!File.Exists(path)){
            File.WriteAllText(path, "Results Log \n \n");
        }
    
    }
   
}
