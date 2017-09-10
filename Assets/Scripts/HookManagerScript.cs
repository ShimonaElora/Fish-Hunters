using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookManagerScript : MonoBehaviour
{
    public int numberHooks;
    public int[] numberOfBaits;
    public GameObject[] baits;
    public GameObject[] hooks;

    private bool[,] active;

    int i, j;
    int activeHook;

    public static bool nextFish = true;

    // Use this for initialization
    void Start()
    {
        for (int k = 0; k < numberOfBaits.Length; k++)
        {
            baits[k].GetComponent<BaitScript>().initialCount = numberOfBaits[k];
        }
        active = new bool[numberHooks, 4];
        for (i = 0; i < numberHooks; i++)
        {
            hooks[i].SetActive(true);
            for (j = 0; j < 4; j++)
            {
                active[i, j] = false;
                hooks[i].GetComponentInChildren<FishSpawnScript>().activeBool[j] = false;
            }
        }
        j = 0;
    }

    // Update is called once per frame
    void Update()
    {
        while (nextFish)
        {
            j++;
            if (j >= 4) j = 0;
            nextFish = false;
            activeHook = Random.Range(0, numberHooks);
            hooks[activeHook].GetComponentInChildren<FishSpawnScript>().activeBool[j] = true;
        }
    }
}
