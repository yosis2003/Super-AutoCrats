using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameLogic : MonoBehaviour
{
    Button[] buttonArray = null;

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
        
        ButtonArrayInit(ref buttonArray);
        Obama = GameObject.Find("Obama");
        Xi = GameObject.Find("Xi");
        Trudeau = GameObject.Find("Trudeau");





        // Really what we want to do here is eventually
        // replace the following lines of code with a function that
        // randomly selects from complete list to then run these
        // functions on the elements selected
        //THESE ARE THE BASE INITIALIZATIONS WITH ALL THE STATS THAT WE NEED TO HAVE
        Obamna = new Leader("Obama", Obama, 10, 7);
        Supreme_Emperor = new Leader("Xi", Xi, 6, 12);
        CanadaBoi = new Leader("Trudeau", Trudeau, 4, 12);

        CompleteListAdder();
        // Really what we want to do here is eventually
        // replace the following lines of code with a function that
        // randomly selects from complete list to then run these
        // functions on the elements selected

        ShopListRandomizer();
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
    public void CompleteListAdder()
    {
        completeList.Add(Obamna);
        completeList.Add(Supreme_Emperor);
        completeList.Add(CanadaBoi);
    }
    // Update is called once per frame
    void Update()
    {
        LeaderPositioner();
        ButtonDeleter();
        StatManager(shopList);
        StatManager(teamList);
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

    public void LeaderPositioner()
    {

        for (int i = 0; i < buttonArray.Length; i++)
        {
            Vector3 buttonCoords;
            buttonCoords = buttonArray[i].transform.position;
            buttonCoords.y += 1.15f;
            if (shopList[i] != null)
            {
                shopList[i].getLeaderRep().transform.position = buttonCoords;
            }
        }
    }
    public void ButtonDeleter()
    {
        for (int i = 0; i < buttonArray.Length; i++)
        {
            if (shopList[i] == null)
            {
                buttonArray[i].gameObject.SetActive(false);
            }
        }
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
    void ButtonArrayInit(ref Button[] buttonArray)
    {
        buttonArray = FindObjectsOfType<Button>();
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
    public void StatManager(List<Leader> L)
    { 
        //Shop List
        for(int i = 0; i < L.Count; i++)
        {
            if(L[i] != null)
            {
                GameObject leaderRep = L[i].getLeaderRep();
                if(leaderRep != null)
                {
                    GameObject statsPrefab = leaderRep.transform.Find("Stats")?.gameObject;
                    if(statsPrefab != null)
                    {
                        GameObject HealthSprite = statsPrefab.transform.Find("Health Sprite")?.gameObject;
                        GameObject AttackSprite = statsPrefab.transform.Find("Attack Sprite")?.gameObject;
                        GameObject HealthText = statsPrefab.transform.Find("Health Text")?.gameObject;
                        GameObject AttackText = statsPrefab.transform.Find("Attack Text")?.gameObject;

                        TextMesh HPText = HealthText.GetComponent<TextMesh>();
                        if(HPText != null)
                        {
                            HPText.text = L[i].getCurrHP().ToString();
                        }

                        TextMesh DMGText = AttackText.GetComponent<TextMesh>();
                        if(DMGText != null)
                        {
                            DMGText.text = L[i].getCurrDMG().ToString();
                        }
                    }
                }
            }
        }
        //Team List
    }
    public void ShopListRandomizer()
    {
        System.Random randInt = new System.Random();
        
        shopList.Clear();
        for (int i = 0; i < 3; i++)
        {
            int value = randInt.Next(0, 3);
            if (completeList[value].getName() == "Obama")
            {
                shopList.Add(new Leader("Obama", Obama, 10, 7));
            }
            else if(completeList[value].getName() == "Trudeau")
            {
                shopList.Add(new Leader("Trudeau", Trudeau, 4, 12));
            }
            else if (completeList[value].getName() == "Xi")
            {
                shopList.Add(new Leader("Xi", Xi, 6, 12));
            }
            Debug.Log(completeList[value].getName());
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

    public float getCurrDMG()
    {
        return currDamage;
    }
    public float getCurrHP()
    {
        return currHealth;
    }
    public float getInitDMG()
    {
        return initialDamage;
    }
    public float getInitHP()
    {
        return initialHealth;
    }
    public string getName()
    {
        return name;
    }
    /*
    // For Research Purposes
    public void SetHealthText()
    {
        GameObject health = leaderRepresentative.transform.Find("Stats Prefab/Health")?.gameObject;
        if (health != null)
        {
            Text healthText = health.GetComponentInChildren<Text>();
            SpriteRenderer healthSpriteRenderer = health.GetComponentInChildren<SpriteRenderer>();
            if (healthText != null && healthSpriteRenderer != null)
            {
                healthText.text = currHealth.ToString(); // Set the text to the current health value

                // Set the position of the text to match the position of the health sprite renderer within the Canvas
                RectTransform healthTextRectTransform = healthText.GetComponent<RectTransform>();
                RectTransform healthCanvasRectTransform = healthSpriteRenderer.GetComponentInParent<Canvas>().GetComponent<RectTransform>();
                healthTextRectTransform.anchoredPosition = healthCanvasRectTransform.InverseTransformPoint(healthSpriteRenderer.transform.position);
            }
        }
    }
    */
}