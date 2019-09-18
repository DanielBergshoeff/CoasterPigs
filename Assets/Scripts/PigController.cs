using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PigController : MonoBehaviour
{
    public Camera FirstPersonCam;
    public float InteractDistance = 2.0f;
    public KeyCode InteractionKey;

    public GameObject DoorPrompt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TurnOffPrompts();
        RaycastForward();
    }

    public void TurnOffPrompts()
    {
        DoorPrompt.SetActive(false);
    }

    public void RaycastForward()
    {
        RaycastHit hit;
        if (Physics.Raycast(FirstPersonCam.transform.position, FirstPersonCam.transform.forward, out hit, InteractDistance)) //Raycast forward with length InteractDistance
        {
            //If a door is hit
            if (hit.transform.tag == "Door")
            {
                DoorPrompt.SetActive(true);

                //If the interaction key is pressed
                if (Input.GetKeyDown(InteractionKey))
                {
                    Door door = hit.transform.GetComponent<Door>();
                    //If the door is not locked
                    if (!door.Locked)
                    {
                        //Load new scene and add turn
                        GameManager.TurnsUsed++;
                        Debug.Log(GameManager.TurnsUsed);
                        door.LoadScene();
                    }
                }
            }
        }
    }
}
