using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class GameLogic : MonoBehaviour
{
    Button[] buyButtonArray = null;
    Button[] sellButtonArray = null;
    Button[] swapButtonArray = null;
    static Leader[] swappingArray = {null, null};
    int gold = 10;
    static int prevSwapIndex = 0;


    List<Leader> teamList = new List<Leader>();
    List<Leader> shopList = new List<Leader>();
    List<Leader> completeList = new List<Leader>();


    //GameObject Obama;
    //GameObject Xi;
    //GameObject Trudeau;


    Leader Obamna;
    Leader Supreme_Emperor;
    Leader CanadaBoi;

    // Start is called before the first frame update
    void Start()
    {
        ResetGold();
        BuyButtonArrayInit(ref buyButtonArray);
        SellButtonInit();
        SwapButtonInit();

        CompleteListAdder();

        ShopListRandomizer();

        ListUpdater();

    }
    // Update is called once per frame
    void Update()
    {
        LeaderPositioner();
        ButtonDeleter();
        StatManager(shopList);
        StatManager(teamList);
        CreateSellButton();
        CreateSwapButton();
        if(swappingArray[0] != null)
        {
            Debug.Log("This is element 0 " + swappingArray[0].getName());
        }
        if (swappingArray[1] != null)
        {
            Debug.Log("This is element 1 " + swappingArray[1].getName());
        }

    }

    public void CompleteListAdder()
    {
        Obamna = new Leader("Obama", (GameObject)Instantiate(Resources.Load("Obama Prefab")), 10, 7);
        Supreme_Emperor = new Leader("Xi", (GameObject)Instantiate(Resources.Load("Xi Prefab")), 6, 12);
        CanadaBoi = new Leader("Trudeau", (GameObject)Instantiate(Resources.Load("Trudeau Prefab")), 4, 12);

        completeList.Add(Obamna);
        completeList.Add(Supreme_Emperor);
        completeList.Add(CanadaBoi);
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

        for (int i = 0; i < shopList.Count; i++)
        {
            Vector3 buttonCoords;
            buttonCoords = buyButtonArray[i].transform.position;
            buttonCoords.y += 1.15f;
            if (shopList[i] != null)
            {
                shopList[i].getLeaderRep().transform.position = buttonCoords;
            }
        }
    }

    public void ButtonDeleter()
    {
        for (int i = 0; i < buyButtonArray.Length; i++)
        {
            if (i >= shopList.Count)
            {
                buyButtonArray[i].gameObject.SetActive(false);
            }
            else if (shopList[i] == null)
            {
                buyButtonArray[i].gameObject.SetActive(false);
            }
        }
    }
    // DELETES
    public void DeleteFromList(ref List<Leader> L, int index)
    {
        if (L[index] != null)
        {
            Destroy(L[index].getLeaderRep());
            L[index] = null;
        }
    }
    public void ClearLeaders(ref List<Leader> L)
    {
        for (int i = 0; i < L.Count; i++)
        {
            DeleteFromList(ref L, i);
        }
        L.Clear();
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
    public void BuyButtonArrayInit(ref Button[] buyButtonArray)
    {
        buyButtonArray = Resources.FindObjectsOfTypeAll<Button>()
            .Where(button => button.CompareTag("Buy Button"))
            .ToArray();
    }
    public void ListUpdater()
    {
        GameLogic.UpdateShopList(shopList);
        GameLogic.UpdateTeamList(teamList);
    }
    public void BuyClicker()
    {
        if (gold > 0)
        {

            string clickedName = EventSystem.current.currentSelectedGameObject.name;
            int buttonIndex = int.Parse(clickedName.Replace("Buy", ""));

            if (buttonIndex < shopList.Count && shopList[buttonIndex] != null)
            {
                teamList.Add(shopList[buttonIndex]);
                if (shopList[buttonIndex] != null)
                {
                    shopList[buttonIndex].SetSpriteVisible(false);
                    shopList[buttonIndex] = null;
                }
                gold -= 3;
                UpdateGold();
                ListUpdater();
            }
            CreateSellButton();
            CreateSwapButton();
        }

    }
    public void StatManager(List<Leader> L)
    {
        //Shop List
        for (int i = 0; i < L.Count; i++)
        {
            if (L[i] != null)
            {
                GameObject leaderRep = L[i].getLeaderRep();
                if (leaderRep != null)
                {
                    GameObject statsPrefab = leaderRep.transform.Find("Stats")?.gameObject;
                    if (statsPrefab != null)
                    {
                        GameObject HealthSprite = statsPrefab.transform.Find("Health Sprite")?.gameObject;
                        GameObject AttackSprite = statsPrefab.transform.Find("Attack Sprite")?.gameObject;
                        GameObject HealthText = statsPrefab.transform.Find("Health Text")?.gameObject;
                        GameObject AttackText = statsPrefab.transform.Find("Attack Text")?.gameObject;

                        TextMesh HPText = HealthText.GetComponent<TextMesh>();
                        if (HPText != null)
                        {
                            HPText.text = L[i].getCurrHP().ToString();
                        }

                        TextMesh DMGText = AttackText.GetComponent<TextMesh>();
                        if (DMGText != null)
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
                shopList.Add(new Leader("Obama", (GameObject)Instantiate(Resources.Load("Obama Prefab")), 10, 7));
            }
            else if (completeList[value].getName() == "Trudeau")
            {
                shopList.Add(new Leader("Trudeau", (GameObject)Instantiate(Resources.Load("Trudeau Prefab")), 4, 12));
            }
            else if (completeList[value].getName() == "Xi")
            {
                shopList.Add(new Leader("Xi", (GameObject)Instantiate(Resources.Load("Xi Prefab")), 6, 12));
            }
        }
    }
    public void StartNextRound()
    {
        Roll();
        ResetGold();
    }

    public void Roll()
    {
        if (gold > 0)
        {
            gold -= 1;
            UpdateGold();
            ClearLeaders(ref shopList);
            // Sets all buttons to active
            buyButtonArray = Resources.FindObjectsOfTypeAll<Button>()
                .Where(button => button.CompareTag("Buy Button"))
                .ToArray();

            for (int i = 0; i < buyButtonArray.Length; i++)
            {
                if (buyButtonArray[i].gameObject.activeSelf == false)
                {
                    buyButtonArray[i].gameObject.SetActive(true);
                }
            }
            // Randomizes the Shop
            ShopListRandomizer();
            // Displays all the sprites and moves everything to the correct location
            ListUpdater();
        }

    }

    public void UpdateGold()
    {
        GameObject.Find("Gold").GetComponent<TextMesh>().text = gold.ToString();
    }
    public void ResetGold()
    {
        gold = 10;
        UpdateGold();
    }
    public void SellClicker ()
    {
        sellButtonArray = FindObjectsOfType<Button>()
        .Where(button => button.CompareTag("Sell Button"))
        .ToArray();
        swapButtonArray = FindObjectsOfType<Button>()
        .Where(button => button.CompareTag("Swap Button"))
        .ToArray();
        string clickedName = EventSystem.current.currentSelectedGameObject.name;
        int buttonIndex = int.Parse(clickedName.Replace("Sell", ""));

        if (buttonIndex < teamList.Count && teamList[buttonIndex] != null)
        {
            Destroy(teamList[buttonIndex].getLeaderRep());
            //teamList[buttonIndex] = null;
            teamList.RemoveAt(buttonIndex);
            gold += 1;
            UpdateGold();
            sellButtonArray[buttonIndex].gameObject.SetActive(false);
            swapButtonArray[buttonIndex].gameObject.SetActive(false);
        }
        sellButtonArray[sellButtonArray.Length - 1].gameObject.SetActive(false);
        swapButtonArray[swapButtonArray.Length - 1].gameObject.SetActive(false);
    }
    public void CreateSellButton()
    {
        sellButtonArray = Resources.FindObjectsOfTypeAll<Button>()
    .Where(button => button.CompareTag("Sell Button"))
    .ToArray();

        for (int i = 0; i < teamList.Count; i++)
        {
            if (teamList[i] != null)
            {
                sellButtonArray[i].gameObject.SetActive(true);
                Vector3 buttonCoords = teamList[i].getLeaderRep().transform.position;
                buttonCoords.y -= 1.15f;
                buttonCoords.x -= 0.3f;
                sellButtonArray[i].transform.position = buttonCoords;
            }
            else
                sellButtonArray[i].gameObject.SetActive(false);
        }
    }
    public void SellButtonInit()
    {
        sellButtonArray = Resources.FindObjectsOfTypeAll<Button>()
        .Where(button => button.CompareTag("Sell Button"))
        .ToArray();
        foreach (Button sellButton in sellButtonArray)
        {
            sellButton.gameObject.SetActive(false);
        }

    }
    public void CreateSwapButton()
    {
        swapButtonArray = Resources.FindObjectsOfTypeAll<Button>()
    .Where(button => button.CompareTag("Swap Button"))
    .ToArray();

        for (int i = 0; i < teamList.Count; i++)
        {
            if (teamList[i] != null)
            {
                swapButtonArray[i].gameObject.SetActive(true);
                Vector3 buttonCoords = teamList[i].getLeaderRep().transform.position;
                buttonCoords.y -= 1.15f;
                buttonCoords.x += 0.3f;
                swapButtonArray[i].transform.position = buttonCoords;
            }
            else
                swapButtonArray[i].gameObject.SetActive(false);
        }
    }
    public void SwapButtonInit()
    {
        swapButtonArray = Resources.FindObjectsOfTypeAll<Button>()
        .Where(button => button.CompareTag("Swap Button"))
        .ToArray();
        foreach (Button swapButton in swapButtonArray)
        {
            swapButton.gameObject.SetActive(false);
        }

    }

    public void SwapClicker()
    {
        string clickedName = EventSystem.current.currentSelectedGameObject.name;
        int buttonIndex = 0; //= int.Parse(clickedName.Replace("Swap", ""));

        if (clickedName == "Swap0")
        {
            buttonIndex = 0;
        }
        else if (clickedName == "Swap1")
        {
            buttonIndex = 1;
        }
        else if (clickedName == "Swap2")
        {
            buttonIndex = 2;
        }

        if (buttonIndex < teamList.Count && teamList[buttonIndex] != null)
        {
            if (swappingArray[0] == null)
            {
                swappingArray[0] = teamList[buttonIndex];
                prevSwapIndex = buttonIndex;
            }
            else
            {
                swappingArray[1] = teamList[buttonIndex];
                if (teamList[prevSwapIndex].getName() == teamList[buttonIndex].getName())
                {
                    teamList[buttonIndex].incHP(); //works  
                    teamList[buttonIndex].incDMG(); //works

                    sellButtonArray = FindObjectsOfType<Button>()
                    .Where(button => button.CompareTag("Sell Button"))
                    .ToArray();
                    swapButtonArray = FindObjectsOfType<Button>()
                    .Where(button => button.CompareTag("Swap Button"))
                    .ToArray();

                    Destroy(teamList[prevSwapIndex].getLeaderRep());
                    //teamList[buttonIndex] = null;
                    teamList.RemoveAt(prevSwapIndex);
                    sellButtonArray[prevSwapIndex].gameObject.SetActive(false);
                    swapButtonArray[prevSwapIndex].gameObject.SetActive(false);

                    sellButtonArray[sellButtonArray.Length - 1].gameObject.SetActive(false);
                    swapButtonArray[swapButtonArray.Length - 1].gameObject.SetActive(false);
                }
                else
                {
                    Leader tempLeader = teamList[buttonIndex];
                    teamList[buttonIndex] = teamList[prevSwapIndex];
                    teamList[prevSwapIndex] = tempLeader;
                }
                swappingArray[0] = null;
                swappingArray[1] = null;
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
    public void incHP()
    {
        currHealth += 1;
    }
    public void incDMG()
    {
        currDamage += 1;
    }
}