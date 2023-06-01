using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
        GameObject tempObj;
        for(int i = 0; i < LeaderList.Count(); i++)
        {
            LeaderList[i].SetSpriteVisible(true);
            tempObj = Instantiate(LeaderList[i].getLeaderRep());
            tempObj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            tempObj.transform.position = new Vector3(-7.0f + 1.5f*(i), -3.0f, 0.0f);
        }
    }

    public static void DisplayTeamList(List<Leader> LeaderList)
    {
        GameObject tempObj;
        for (int i = 0; i < LeaderList.Count(); i++)
        {
            LeaderList[i].SetSpriteVisible(true);
            tempObj = Instantiate(LeaderList[i].getLeaderRep());
            tempObj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            tempObj.transform.position = new Vector3(-4.0f + 2.5f * (i), 1.0f, 0.0f);
        }
    }
}