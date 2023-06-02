using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void DisplayShopList(List<Leader> LeaderList)
    {
        //declare a temporary gameobject
        GameObject tempObj;
        for (int i = 0; i < LeaderList.Count(); i++)
        {
            // what those statements below are doing: basically setting the sprite visible for the shop and initializing its position
            LeaderList[i].SetSpriteVisible(true);
            tempObj = Instantiate(LeaderList[i].getLeaderRep());
            tempObj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            tempObj.transform.position = new Vector3(-7.0f + 1.5f * (i), -3.0f, 0.0f);
        }
    }

    public static void DisplayTeamList(List<Leader> LeaderList)
    {
        GameObject tempObj;
        for (int i = 0; i < LeaderList.Count(); i++)
        {
            // what those statements below are doing: basically setting the sprite visible for the team and initializing its position
            LeaderList[i].SetSpriteVisible(true);
            tempObj = Instantiate(LeaderList[i].getLeaderRep());
            tempObj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            tempObj.transform.position = new Vector3(-4.0f + 2.5f * (i), 1.0f, 0.0f);
        }
    }
    public void BuyClicker()
    {
        string ClickedName = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(ClickedName);
        if (ClickedName == "Buy0"){
            ShopScript.GetTeamList().Add(ShopScript.GetShopList()[0]);
        }
        else if(ClickedName == "Buy1")
        {
            teamList.Add(shopList[1]);
        }
        else if (ClickedName == "Buy2")
        {
            teamList.Add(shopList[2]);
        }
        else if (ClickedName == "Buy3")
        {
            teamList.Add(shopList[3]);
        }
        else if (ClickedName == "Buy4")
        {
            teamList.Add(shopList[4]);
        }


    }
}