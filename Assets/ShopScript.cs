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
        }
    }

    public GameObject getLeaderRep()
    {
        return leaderRepresentative;
    }
}

public class ShopScript : MonoBehaviour
{
    List<Leader> teamList = new List<Leader>();
    List<Leader> shopList = new List<Leader>();
    List<Leader> completeList = new List<Leader>();

    GameObject Obama;
    GameObject Xi;
    GameObject Trudeau;

    
    Leader Obamna;
    Leader Supreme_Emperor;
    Leader CanadaBoi;

    void Start()
    {
        // Really what we want to do here is eventually
        // replace the following lines of code with a function that
        // randomly selects from complete list to then run these
        // functions on the elements selected
        Obama = GameObject.Find("Obama");
        Xi = GameObject.Find("Xi");
        Trudeau = GameObject.Find("Trudeau");

        // Really what we want to do here is eventually
        // replace the following lines of code with a function that
        // randomly selects from complete list to then run these
        // functions on the elements selected
        Obamna = new Leader("Obama", Obama, 10, 7);
        Supreme_Emperor = new Leader("Xi", Xi, 6, 12);
        CanadaBoi = new Leader("Trudeau", Trudeau, 4, 12);

        // Really what we want to do here is eventually
        // replace the following lines of code with a function that
        // randomly selects from complete list to then run these
        // functions on the elements selected
        shopList.Add(Obamna);
        shopList.Add(Supreme_Emperor);
        shopList.Add(CanadaBoi);

        // Really what we want to do here is eventually
        // replace the following lines of code with a function that
        // randomly selects from complete list to then run these
        // functions on the elements selected
        teamList.Add(Obamna);
        teamList.Add(Supreme_Emperor);
        teamList.Add(CanadaBoi);

        GameLogic.DisplayShopList(shopList);
        GameLogic.DisplayTeamList(teamList);
    }

    void petLoader()
    {

    }
}

