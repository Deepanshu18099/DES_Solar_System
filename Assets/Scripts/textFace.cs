using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFace : MonoBehaviour
{
    private GameObject mainCamera;
    private GameObject[] texts;
    private Vector3 Position;

    void Start()
    {
        // Get the game object tagged "MainCamera"
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        // Get all the texts tagged with "Text" in the complete game
        texts = GameObject.FindGameObjectsWithTag("Text");

        // Print the size of this array
        Debug.Log("Number of Texts: " + texts.Length);

        // Give all these same text as their parent name
        foreach (GameObject text in texts)
        {
            text.GetComponent<TextMesh>().text = text.transform.parent.name;
        }
    }

    void LateUpdate()
    {
        // Face all the text to the main camera, set text transform to look at the main camera
        // Also, align the text to the main camera, keeping them face-up
        foreach (GameObject text in texts)
        {
            text.transform.LookAt(text.transform.position + mainCamera.transform.rotation * Vector3.forward,
                                  mainCamera.transform.rotation * Vector3.up);

            // now move the text little above the current positione
            // Have relative position that increament to distance with camera, in direction of text.transform.up
            Position = text.transform.parent.position;
             
            //  transform position upward based on radius of parent plannet
            text.transform.position = Position + text.transform.up  * 15f;

            // Debug.Log("For Plannet: " + text.transform.parent.name + " Transform : " + text.transform.parent.localScale.x * 1.2f);


           // Nice, also add relative font size to camera distance, which keeps the text size same, which change in camera distance
            text.GetComponent<TextMesh>().fontSize = Mathf.RoundToInt(5 * Mathf.Sqrt((text.transform.position - mainCamera.transform.position).magnitude)/text.transform.parent.localScale.x);



            

        }
    }
}