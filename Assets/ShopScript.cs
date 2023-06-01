using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Leader
{
    const float LEGAL_MAX = 50;
    float initialHealth;
    float currHealth;
    float initialDamage;
    float currDamage;
    string name;
    GameObject leaderRepresentative;

    public Leader(string leaderType, GameObject leaderObject, float initH, float initD)
    {
        name = leaderType;
        leaderRepresentative = leaderObject;
        initialHealth = initH;
        initialDamage = initD;
        currHealth = initialHealth;
        currDamage = initialDamage;
    }
    public void SetSpriteVisible(bool visible)
    {
        SpriteRenderer spriteRenderer = leaderRepresentative.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = visible;

            //Realistically this should not be part of things, this is initializing
            //the position of the sprite and is a quick fix that should be replaced
            //by a function that does this independantly of displaying the sprite.
            leaderRepresentative.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
}

public class ShopScript : MonoBehaviour
{
    List<Leader> team;
    List<Leader> shop;
    GameObject Obama;
    List<Leader> completeList = new List<Leader>();

    Leader Obamna;

    void Start()
    {
        Obama = GameObject.Find("Obama");
        Obamna = new Leader("Obama", Obama, 10, 7);

        completeList.Add(Obamna);

        //Technically we dont want to be showing things
        //from the complete list, we will eventually replace
        //this with shop however for now we are working with complete list
        completeList[0].SetSpriteVisible(true);
    }

    void petLoader()
    {

    }
}

