using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    public GameObject fruit_PickUp, nest_pickUp;

    private float min_X = -4.5f, max_X = 4f, min_Y = -1.8f, max_Y = 1.6f;
    private float z_Pos = 5.8f;

    public List<GameObject> hearts;

    void Awake()
    {
        MakeInstance();
    }

    void Start()
    {
        InitHearts();

        Invoke("StartSpawning", 0.5f);
    }

    void InitHearts()
    {
        hearts[1].SetActive(false);
        hearts[2].SetActive(false);
        hearts[3].SetActive(false);
    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void StartSpawning()
    {
        StartCoroutine(SpawnPickUps());
    }

    public void CancelSpawning()
    {
        CancelInvoke("SpawnPickUps");
    }

    IEnumerator SpawnPickUps()
    {
        
        if (!fruit_PickUp.activeSelf && !nest_pickUp.activeSelf)
        {
            yield return new WaitForSeconds(Random.Range(0f, 0.5f));
            if (Random.Range(0, 10) >= 3)
            {
                float ran = Random.Range(min_X, max_X);
                print(ran);
                fruit_PickUp = Instantiate(fruit_PickUp, new Vector3(ran,
                    Random.Range(min_Y, max_Y), z_Pos), Quaternion.identity);
                fruit_PickUp.SetActive(true);
            }
            else
            {
                nest_pickUp = Instantiate(nest_pickUp, new Vector3(Random.Range(min_X, max_X),
                    Random.Range(min_Y, max_Y), z_Pos), Quaternion.identity);
                nest_pickUp.SetActive(true);
            }
        }

        Invoke("StartSpawning", 0f);
    }

    public void IncreaseHearts()
    {
        for (int i = 1; i < hearts.Count; i++)
        {
            if (!hearts[i].activeSelf)
            {
                hearts[i].SetActive(true);
                break;
            }
        }
    }
}
