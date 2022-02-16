using System.Collections;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    [SerializeField] private float minTime = 1f, maxTime = 3;
    [SerializeField] private Material[] materials = default;
    private int collisionCount = 0, newRandom = 0, oldRandom = 0;
    private Renderer myRenderer;
    private string myColor;

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        myRenderer.material = materials[Random.Range(0, materials.Length)];         //This line sets a material before the coroutine
        StartCoroutine(nameof(RandomMaterial));
    }

    private void Update()
    {
        if(transform.position.y <= -10f)
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator RandomMaterial()
    {
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        NewMaterial();
        StartCoroutine(nameof(RandomMaterial));
    }

    private void NewMaterial()
    {
        do  //This Do_While segment makes sure that newRandom doesn't have the same value twice in a row
        {
            oldRandom = newRandom;
            newRandom = Random.Range(0, materials.Length);
        } 
        while (oldRandom == newRandom);

        myRenderer.material = materials[newRandom];
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.CompareTag("Player") && collisionCount < 1)
    //    {
    //        collisionCount++;
    //        StopCoroutine(nameof(RandomMaterial));
    //        myColor = myRenderer.sharedMaterial.name;
    //        //SEND COLOR OF PLATFORM TO INCREASE OR DECREASE THE SCORE
    //        if (myColor == "Green")
    //        {
    //            print(myColor);     
    //        }
    //        Invoke(nameof(FallingPlatform), 2f);
    //    }
    //}

    private void FallingPlatform()
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
