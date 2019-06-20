using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeobst : MonoBehaviour
{
    public GameObject[] obstprefab;
    //public float spawntime = 0.5f;
    private Vector2 screenlim;
    
    // Start is called before the first frame update
    void Start()
    {
        screenlim = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(Waves());
    }

    void spawncrap(int pref, int walldir)
    {
        GameObject t = Instantiate(obstprefab[pref]) as GameObject;
        //bomb position
        if(pref < 1)
        {
            t.transform.position = new Vector2(Random.Range(screenlim.x*6/5, -screenlim.x), screenlim.y * 2);
        }
        //wall position
        else
        {
            if (walldir == 0)
            {
                t.transform.position = new Vector2(-screenlim.x * 3/2, Random.Range(screenlim.y /2, screenlim.y * 6/5));
            }
            else
            {
                t.transform.position = new Vector2(screenlim.x * 3/2, Random.Range(screenlim.y /2, screenlim.y * 6/5));
            }
        }
        
    }
    
    IEnumerator Waves()
    {
        while (true)
        {
            float spawntime = Random.Range(0.1f, 2);
            Debug.Log(spawntime);
            //timer
            yield return new WaitForSeconds(spawntime);

            int pref = Random.Range(0, 5);
            int wallp = 0;
            if (pref > 1) {
                wallp = Random.Range(0, 2);
            }
            //if game started, start spawning
            if (FindObjectOfType<GManager>().playing()) {
                spawncrap(pref, wallp);
            }
        }
    }
}
