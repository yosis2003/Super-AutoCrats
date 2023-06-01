using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ShopScript : MonoBehaviour
{
    List<Leader> team;
    List<Leader> shop;
    GameObject Obama;
    List<Leader> completeList = new List<Leader>();

    Leader Obamna;

    void Start()
    {
        Obama = new GameObject("Obama");
        Obamna = new Leader("Obama", Obama, 10, 7);
    }

    void petLoader()
    {

    }
}

