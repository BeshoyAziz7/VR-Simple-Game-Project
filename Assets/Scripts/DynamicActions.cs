using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DynamicActions : MonoBehaviour
{
    //variables
    int flag;
    bool rotatePressed;

    //Prefabs will be spawned in real time
    public GameObject RoomPrefab;
    public GameObject TablePrefab;

    //UI button GameObjects
    public Button spawnButton;
    public Button rotateButton;
    public Button destroyButton;

    public TMP_Text dynamicText;
    //UI Text to display dynamic text

    //MAC system students use this --> public TextMeshPro dynamicText; 

    // Start is called before the first frame update
    void Start()
    {
        //initialize variables
        flag = 0;
        rotatePressed = false;
        dynamicText.text = "";
        spawnButton.enabled = true; //spawn enabled

        rotateButton.enabled = false; //rotate disabled
        destroyButton.enabled = false; //destroy disabled
    }


    public void DropdownSelect(int index)
    {
        Debug.Log("Index of the Dropdown Menu options: " + index);

        if (index == 0) //reset the flag for default "Choose"
        {
            flag = 0; // set flag as 0
            dynamicText.text = ""; //null dynamic text
        }
        if (index == 1) //first option "Cube"
        {
            flag = 1; // set flag as 1
            dynamicText.text = "ROOM is chosen"; //display dynamic text
        }
        if (index == 2) //second option "Sphere"
        {
            flag = 2; // set flag as 2
            dynamicText.text = "TABLE is chosen"; //display dynamic text
        }
    }


    public void onSpawnButtonPress()
    {
        //check current flag value
        if (flag == 1)
        {
            Vector3 pos = new Vector3((float)-6.46, (float)19.85, (float)71.45); //Spawn Position of Cube (x,y,z)
            Quaternion rotation = RoomPrefab.transform.rotation; // Get the prefab's rotation
            Instantiate(RoomPrefab, pos, rotation);
        }

        if (flag == 2)
        {
            Vector3 pos = new Vector3(-29, 20, 61); //Spawn Position of Cube (x,y,z)
            Quaternion rotation = TablePrefab.transform.rotation; // Get the prefab's rotation
            Instantiate(TablePrefab, pos, rotation);

        }


        //disable Spawn and enable rotate and enable destroy
        spawnButton.enabled = false;
        rotateButton.enabled = true;
        destroyButton.enabled = true;
    }

    public void onRotateButtonPress()
    {
        rotatePressed = true; //start rotation
        rotateButton.enabled = false; //disable rotate button
    }

    public void onDestroyButtonPress()
    {
        //stop rotation
        rotatePressed = false;

        //destroy current Prefab
        GameObject currentPrefab = GameObject.FindGameObjectWithTag("currentPrefab");

        if (currentPrefab != null)
        {
            currentPrefab.SetActive(false);
        }

        //enable Spawn and disable rotate and disable destroy
        spawnButton.enabled = true;
        rotateButton.enabled = false;
        destroyButton.enabled = false;

        //set the Dynamic Text as Null
        dynamicText.text = "";
    }

    void Update()
    {
        if (rotatePressed) //if rotate button is pressed, start rotation
        {
            GameObject currentPrefab = GameObject.FindGameObjectWithTag("currentPrefab");
            if (currentPrefab != null)
            {
                currentPrefab.transform.Rotate(new Vector3(0, 20.0f, 0) * Time.deltaTime);
            }
        }
    }

  

}