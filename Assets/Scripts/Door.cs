using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public bool Locked = false;
    public string SceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        RoomManager.AddDoor(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}
