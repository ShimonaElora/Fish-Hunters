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

    // Use this for initialization
    void Start()
    {
        baitInstantiated = new GameObject[numberHooks];
        for (int k = 0; k < numberOfBaits.Length; k++)
        {
            baits[baitOrder[k]].GetComponent<BaitScript>().initialCount = numberOfBaits[k];
            Debug.Log(baits[baitOrder[k] - 1].ToString() + " " + baits[baitOrder[k]].GetComponent<BaitScript>().initialCount.ToString());
            hooks[k].SetActive(true);
            baitInstantiated[k] = Instantiate(baits[baitOrder[k] - 1], baitSpawnPoints[k]);
            baitInstantiated[k].transform.SetParent(hooks[k].transform, false);
            baitInstantiated[k].GetComponent<BaitScript>().baitNumber = count[k];
        }
    }
}
