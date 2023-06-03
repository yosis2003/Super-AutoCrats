using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameLogic : MonoBehaviour
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

    // Start is called before the first frame update
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

        ListAdder();
        // Really what we want to do here is eventually
        // replace the following lines of code with a function that
        // randomly selects from complete list to then run these
        // functions on the elements selected
        /*
        teamList.Add(Obamna);
        teamList.Add(Supreme_Emperor);
        teamList.Add(CanadaBoi);
        */
        ListUpdater();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // RETURNS
    public List<Leader> GetShopList()
    {
        return shopList;
    }
    public List<Leader> GetTeamList()
    {
        return teamList;
    }
    // DELETES
    public void DeleteFromList(ref List<Leader> L, int index)
    {
        L[index].SetSpriteVisible(false);
        L[index] = null;
    }

    // Manual Initialization
    void ListAdder()
    {
        shopList.Add(Obamna);
        shopList.Add(Supreme_Emperor);
        shopList.Add(CanadaBoi);
    }

    public static void UpdateShopList(List<Leader> LeaderList)
    {
        for (int i = 0; i < LeaderList.Count(); i++)
        {
            if (LeaderList[i] != null)
            {
                LeaderList[i].SetSpriteVisible(true);
                LeaderList[i].getLeaderRep().transform.position = new Vector3(-7.0f + 1.5f * (i), -3.0f, 0.0f);
                LeaderList[i].getLeaderRep().transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            }
        }
    }

    public static void UpdateTeamList(List<Leader> LeaderList)
    {
        for (int i = 0; i < LeaderList.Count(); i++)
        {
            if (LeaderList[i] != null)
            {
                LeaderList[i].SetSpriteVisible(true);
                LeaderList[i].getLeaderRep().transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                LeaderList[i].getLeaderRep().transform.position = new Vector3(-4.0f + 2.5f * (i), 1.0f, 0.0f);
            }
        }
    }
    void ListUpdater()
    {
        GameLogic.UpdateShopList(shopList);
        GameLogic.UpdateTeamList(teamList);
    }

    public void BuyClicker()
    {
        string ClickedName = EventSystem.current.currentSelectedGameObject.name;
        if (ClickedName == "Buy0"){
            if (shopList[0] != null)
            {
                teamList.Add(shopList[0]);
                DeleteFromList(ref shopList, 0);
                ListUpdater();
            }
        }
        else if(ClickedName == "Buy1")
        {
            if (shopList[1] != null)
            {
                teamList.Add(shopList[1]);
                DeleteFromList(ref shopList, 1);
                ListUpdater();
            }
        }
        else if (ClickedName == "Buy2")
        {
            if (shopList[2] != null)
            {
                teamList.Add(shopList[2]);
                DeleteFromList(ref shopList, 2);
                ListUpdater();
            }
        }
        else if (ClickedName == "Buy3")
        {
            if (shopList[3] != null)
            {
                teamList.Add(shopList[3]);
                DeleteFromList(ref shopList, 3);
                ListUpdater();
            }
        }
        else if (ClickedName == "Buy4")
        {
            if (shopList[4] != null)
            {
                teamList.Add(shopList[4]);
                DeleteFromList(ref shopList, 4);
                ListUpdater();
            }
        }
    }
}

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
        //attributes for our leaders are set here in this constructor
        name = leaderType;
        leaderRepresentative = leaderObject;
        initialHealth = initH;
        initialDamage = initD;
        currHealth = initialHealth;
        currDamage = initialDamage;
    }
    public void SetSpriteVisible(bool visible)
    {
        //if it finds an actual sprite under leaderRepresentative, it sets it visible
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

    public void setLeaderRep(GameObject newLeaderRep)
    {
        leaderRepresentative = newLeaderRep;
    }
}