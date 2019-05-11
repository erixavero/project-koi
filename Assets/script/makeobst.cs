using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeobst : MonoBehaviour
{
    public GameObject[] obstprefab;
    public float spawntime = 1.0f;
    private Vector2 screenlim;

    // Start is called before the first frame update
    void Start()
    {
        screenlim = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(Waves());
    }
    
    void spawnbomb()
    {
        GameObject t = Instantiate(obstprefab[0]) as GameObject;
        t.transform.position = new Vector2(Random.Range(screenlim.x, -screenlim.x), screenlim.y * 2);
    }

    void spawnwall()
    {
        GameObject t = Instantiate(obstprefab[1]) as GameObject;
        int kek = Random.Range(0, 2);
        Debug.Log(kek);
        if (kek%2 == 0)
        {
            t.transform.position = new Vector2(-screenlim.x, screenlim.y * 3 / 2);
        }
        else
        {
            t.transform.position = new Vector2(screenlim.x, screenlim.y * 3 / 2);
        }
    }

    IEnumerator Waves()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawntime);
            spawnbomb();
            spawnwall();
        }
    }
}
