using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObs : MonoBehaviour
{
    private Vector3 spawnPos;
    private int countOfSpawn;

    [SerializeField] private float timeBetweenObs, positionSpawnX;
    [SerializeField] private GameObject[] listObs, players,grounds,btnPanels;

    [HideInInspector]
    public int typeSpaw;
    public bool isSpawnChange=false;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        btnPanels[0].SetActive(true);
        Spawn();
    }

    private void Spawn()
    {
        switch (typeSpaw)
        {
            case 0:
                Instantiate(listObs[Random.Range(0, listObs.Length)], spawnPos, Quaternion.identity);
                break;
            case 1:
                if (!isSpawnChange)
                {
                    btnPanels[0].SetActive(false);

                    players[1].SetActive(true);
                    grounds[1].SetActive(true);
                    btnPanels[1].SetActive(true);
                    isSpawnChange = true;
                }
                spawnPos=transform.position;
                Instantiate(listObs[Random.Range(0, listObs.Length)], spawnPos, Quaternion.identity);
                spawnPos.x = 0f - positionSpawnX;
                Instantiate(listObs[Random.Range(0, listObs.Length)], spawnPos, Quaternion.identity);

                break;
            case 2:
                if (isSpawnChange)
                {
                    btnPanels[0].SetActive(false); 
                    btnPanels[1].SetActive(false);

                    players[1].SetActive(true);
                    grounds[1].SetActive(true);

                    players[2].SetActive(true);
                    grounds[2].SetActive(true);
                    btnPanels[2].SetActive(true);
                    isSpawnChange = false;
                }
                spawnPos = transform.position;
                Instantiate(listObs[Random.Range(0, listObs.Length)], spawnPos, Quaternion.identity);
                spawnPos.x = 0f - positionSpawnX;
                Instantiate(listObs[Random.Range(0, listObs.Length)], spawnPos, Quaternion.identity);
                spawnPos.x = 0f + positionSpawnX;
                Instantiate(listObs[Random.Range(0, listObs.Length)], spawnPos, Quaternion.identity);
                break;
        }
        Invoke("Spawn", timeBetweenObs);
        ChangeType();
        countOfSpawn++;
        Debug.Log(countOfSpawn);
    }

    public void ChangeType()
    {
        if (countOfSpawn < 5)
        {
            typeSpaw = 0;
        }
        else if (countOfSpawn < 10)
        {
            typeSpaw = 1;
        }
        else
        {
            typeSpaw = 2;
        }
    }
}
