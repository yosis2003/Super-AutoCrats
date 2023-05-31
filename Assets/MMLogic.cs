using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MMLogic: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startSinglePlayer()
    {
        SceneManager.LoadScene("Single Player");
    }
    public void startMultiplayer()
    {
        SceneManager.LoadScene("Multiplayer");
    }
    public void startGallery()
    {
        SceneManager.LoadScene("Gallery");
    }
}
