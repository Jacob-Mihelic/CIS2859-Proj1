using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] joe = new GameObject[1];
    public GameObject enemy;
    private bool wave;
    public int waveNum = 0;
    public bool spawning;
    private GameObject win;
    private TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        win = GameObject.FindWithTag("Finish");
        text = win.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        wave = EnemySearch();

        if (wave == true && spawning == false && waveNum <= 3)
        {
            StartCoroutine(Spawner());
        }

        if (waveNum > 3)
        {
            text.enabled = true;
        }
    }

    IEnumerator Spawner()
    {
        spawning = true;

        if (wave == true)
        {
            yield return new WaitForSeconds(3f);
            Summon(waveNum);
        }
        spawning = false;

    }

    bool EnemySearch()
    {
        var find = GameObject.FindWithTag("Enemy");

        if (find == null && spawning != true)
        {
            waveNum ++;
            return true;
        }
        else
        {
            return false;
        }
    }

    void Summon(int challenge)
    {
        for (int i = 0; i < challenge; i ++)
        {
            var position = new Vector3(Random.Range(-35.0f, 35.0f), 2.7f, Random.Range(-35.0f, 35.0f));
            enemy = Instantiate(joe[0], position, Quaternion.identity);
            var healthVal = enemy.GetComponent<EnemyAI>();
            healthVal.SetHealth(challenge);
        }
    }
}
