using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PurchaseDefenders : MonoBehaviour
{
    [SerializeField] private GoldTracker goldPouch;
    [SerializeField] private List<Transform> archerSpawnPoints;
    [SerializeField] private List<Transform> CatapultSpawnPoints;

    [SerializeField] private GameObject archerPrefab;
    [SerializeField] private GameObject catapultPrefab;

    [SerializeField] private TMP_Text priceText;

    private int archerLevel;

    // Start is called before the first frame update
    void Start()
    {
        archerLevel = 1;
        priceText.text = (archerLevel * 50).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBuyArcherClicked()
    {
        if(archerSpawnPoints.Count <= 0)
        {
            Debug.Log("Maximum number of archers purchased");
            return;
        }

        if(goldPouch.GetGold() < (50*archerLevel))
        {
            Debug.Log("You are poor!");
            return;
        }

        goldPouch.UseGold(50 * archerLevel);
        archerLevel++;
        Instantiate(archerPrefab, archerSpawnPoints[0].position, archerSpawnPoints[0].rotation);
        archerSpawnPoints.RemoveAt(0);
        priceText.text = (archerLevel * 50).ToString();

    }
}
