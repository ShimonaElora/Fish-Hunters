using UnityEngine;
using UnityEngine.UI;

public class HookManagerScript : MonoBehaviour
{
    public int numberHooks;
    public int[] numberOfBaits;
    public Transform[] baitSpawnPoints;
    public Text[] count;
    public GameObject[] baits;
    public GameObject[] hooks;
    public GameObject[] fishes;
    public int[] baitOrder;
    public GameObject[] baitInstantiated;
    private bool hasStarted;
    public static bool hasSetup;


    // Use this for initialization
    void Start()
    {
        hasSetup = false;
        hasStarted = false;
        baitInstantiated = new GameObject[numberHooks];
        for (int k = 0; k < numberHooks; k++)
        {
            baits[baitOrder[k] - 1].GetComponent<BaitScript>().initialCount = numberOfBaits[k];
            hooks[k].SetActive(true);
            baitInstantiated[k] = Instantiate(baits[baitOrder[k] - 1], baitSpawnPoints[k]);
            baitInstantiated[k].transform.SetParent(hooks[k].transform, false);
            baitInstantiated[k].GetComponent<BaitScript>().baitNumber = count[k];
        }
        hasSetup = true;
    }

    private void Update()
    {
        hasSetup = false;
        if (BaitSelectionScript.hasStarted && !hasStarted)
        {
            hasStarted = true;
            for (int k = 0; k < numberHooks; k++)
            {
                baits[baitOrder[k] - 1].GetComponent<BaitScript>().initialCount = numberOfBaits[k];
                hooks[k].SetActive(true);
                baitInstantiated[k] = Instantiate(baits[baitOrder[k] - 1], baitSpawnPoints[k]);
                baitInstantiated[k].transform.SetParent(hooks[k].transform, false);
                baitInstantiated[k].GetComponent<BaitScript>().baitNumber = count[k];
            }
        }
        hasSetup = true;

        if (GameoverScript.gameover)
        {
            hasStarted = false;
        }
    }
}
