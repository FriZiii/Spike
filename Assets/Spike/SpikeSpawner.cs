using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    [Header("Refereces")]
    [SerializeField] private ChangeDirection direction;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject spikePrefab;
    List<GameObject> spikeList = new List<GameObject>();


    [Header("Spawn Point")]
    [SerializeField] private GameObject walllLeft;
    [SerializeField] private GameObject wallRight;

    private float camHeight;
    private float camWidth;

    private float leftSide;
    private float rightSide;

    private void Awake()
    {
        camHeight =  2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;

        rightSide = camWidth / 2f;
        leftSide = -rightSide;

        walllLeft.transform.position = new Vector3(leftSide + 0.5f, 0, 0);
        wallRight.transform.position = new Vector3(rightSide - 0.5f,0,0);

        SpawnSpikes();
    }

    private void Update()
    {
        if (direction.ChangeDir())
        {
            ClearSpikes();
            SpawnSpikes();
        }
    }

    private void SpawnSpikes()
    {
        for(int i = 0; i < Random.Range(1, 6); i++)
        {
            if (direction.movingLeft)
            {
                spikePrefab.transform.localScale = new Vector3(-0.7f, 0.7f, 0.7f);
                spikeList.Add(Instantiate(spikePrefab, RandomPosition(direction.movingLeft), Quaternion.identity));
            }
            else if (!direction.movingLeft)
            {
                spikePrefab.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                spikeList.Add(Instantiate(spikePrefab, RandomPosition(direction.movingLeft), Quaternion.identity));
            }
        }
    }
    
    private void ClearSpikes()
    {
        for(int i=0; i<spikeList.Count; i++)
        {
            Destroy(spikeList[i]);
        }
    }

    private Vector3 RandomPosition(bool movingLeft)
    {
        if (movingLeft)
        {
            return new Vector3(leftSide + 1, Random.Range(-3, 4) * 0.7f, 0);
        }
        else if (!movingLeft)
        {
            return new Vector3(rightSide - 1, Random.Range(-3, 4) * 0.7f, 0);
        }
        else
            return new Vector3(0, 0, 0);
    }
}
