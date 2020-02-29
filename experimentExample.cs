public class exampleExperiment : MonoBehaviour
{


    // CHANGE THESE AS NEEDED:
    float maxWidth = 0.1f; //minimum
    float minWidth = 0.3f; //maximum
    int numLengths = 10; //number of line lengths desired
    string fileName = "Results"; //name of file

    public float[] horLengths; //arrays of lengths
    public float[] vertLengths;
    int index = 1;


    // Start is called before the first frame update
    void Start()
    {
        horLengths = new float[numLengths];
        vertLengths = new float[numLengths];
        populateLenArray(horLengths); populateLenArray(vertLengths); // populate the arrays with random values within the desired range
        createStimuli(horLengths[0], vertLengths[0]); //generate initial stimuli
    }



    // Update is called once per frame
    void Update()
    {
        //on user input
        if (Input.GetKeyDown(KeyCode.S))
        {
            CreateText(); //write to file
            Destroy(GameObject.Find("horizontalStimulus").gameObject); //destroy previous stimuli
            Destroy(GameObject.Find("verticalStimulus").gameObject);
            createStimuli(horLengths[index], vertLengths[index]); //create stimuli for next trial 
            index++;
           
        }

        //if up is pressed, increase width of horizontal
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GameObject.Find("horizontalStimulus").gameObject.transform.localScale += new Vector3(0.01f, 0, 0);
        }

        //if down is pressed, decrease width of horizontal
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GameObject.Find("horizontalStimulus").gameObject.transform.localScale -= new Vector3(0.01f, 0, 0);
        }

    }


    // generate the line stimuli
    public void createStimuli(float length, float height)
    {
        //initialize horizontal line
        GameObject horizontalStimulus = GameObject.CreatePrimitive(PrimitiveType.Cube);
        horizontalStimulus.transform.position = new Vector3(0.745f, 0.78f, 1.244f); // initialize position
        horizontalStimulus.transform.localScale = new Vector3(length, 0.01f, 0.01f); // change its local scale in x y z format
        horizontalStimulus.GetComponent<Renderer>().material.color = Color.black; // initialize its color
        horizontalStimulus.name = "horizontalStimulus";
        //initialize vertical line
        GameObject verticalStimulus = GameObject.CreatePrimitive(PrimitiveType.Cube);
        verticalStimulus.transform.position = new Vector3(0.745f, 0.78f, 1.244f - height / 2); // initialize position
        verticalStimulus.transform.localScale = new Vector3(0.01f, 0.01f, height); // change its local scale in x y z format
        verticalStimulus.GetComponent<Renderer>().material.color = Color.black; // initialize its color    
        verticalStimulus.name = "verticalStimulus";



    }

    // Create a text file 
    // https://www.google.com/search?client=ubuntu&channel=fs&q=how+to+create+and+write+to+txt+file+unity&ie=utf-8&oe=utf-8#kpvalbx=_ykNYXt25JOuQggfuy4jwAw27
    void CreateText()
    {
        // file path
        string path = Application.dataPath + "/" + fileName + ".txt";
        //create file
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Results Log \n \n");
        }
        // Content of txt file
        string content = "Adjusted Horizontal length:" + GameObject.Find("horizontalStimulus").gameObject.transform.localScale.x + "\n" +
        "Actual Vertical length:" + GameObject.Find("verticalStimulus").gameObject.transform.localScale.z + "\n \n";

        File.AppendAllText(path, content);


    }


    void populateLenArray(float[] lengths)
    {
        for(int i = 0; i < numLengths; i++)
        {
            lengths[i] = Random.Range(minWidth, maxWidth);
        }
    }

}
