using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private GameObject[] tiles = default;

    void Start()
    {
        StartCoroutine("RandomTile");
    }

    IEnumerator RandomTile()
    {
        time = Random.Range(1f, 3f);
        yield return new WaitForSeconds(time);
        NewTile();
        StartCoroutine("RandomTile");
    }

    void NewTile()
    {
        int activeTile = Random.Range(0, tiles.Length);

        switch (activeTile)
        {
            case 0:
                tiles[activeTile].SetActive(true);
                tiles[1].SetActive(false);
                tiles[2].SetActive(false);
                tiles[3].SetActive(false);
                break;
            case 1:
                tiles[0].SetActive(false);
                tiles[activeTile].SetActive(true);
                tiles[2].SetActive(false);
                tiles[3].SetActive(false);
                break;
            case 2:
                tiles[0].SetActive(false);
                tiles[1].SetActive(false);
                tiles[activeTile].SetActive(true);
                tiles[3].SetActive(false);
                break;
            case 3:
                tiles[0].SetActive(false);
                tiles[1].SetActive(false);
                tiles[2].SetActive(false);
                tiles[activeTile].SetActive(true);
                break;
        }
    }
}
