using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc4_SceneManager : MonoBehaviour {
    // Showing or hiding upgrade menu
    [SerializeField] GameObject upgradeMenu;
    public bool isShowUpgradesMenu = false;
    public RectTransform upgradeButton;

    // Enemy waves
    public Sc4_Waves[] enemyWaves;
    public Sc4_Enemy standard;
    public int nextWave;
    private float TBNextWave = 5f;
    private float waveCountDown;

    // Buffer Waves
    public Sc4_Enemy[] enemyTypes;
    

    // Enemy waves (counting)
    public Transform asteroidFol;
    private bool enemyAlive;

    // Enemy waves(spawnlocation)
    public Transform spawnLocation;

    // Enums
    public enum spawnStates { SPAWNING, WAITING, COUNTING }
    public spawnStates state = spawnStates.COUNTING;

	// Use this for initialization
	void Start () {
        waveCountDown = TBNextWave;
	}
	
	// Update is called once per frame
	void Update () {

        SpawnWaveSystem();

        IsShowUpgradesmenu();
	}
   
    private void BufferNewWave()
    {
        for(int i = 0; i < enemyTypes.Length; i++)
        {

        }
    }

    private void SpawnWaveSystem()
    {
        if (state == spawnStates.WAITING)
        {
            if (!IsEnemyAlive())
            {
                // TODO Begin new wave

                WaveCompleted();
                enemyAlive = false;
                Debug.Log("Wave completed");
            }
            else
            {
                enemyAlive = true;
            }
        }
        if (!enemyAlive)
        {
            if (waveCountDown <= 0)
            {
                if (state != spawnStates.SPAWNING)
                {
                    StartCoroutine(SpawnWave(enemyWaves[nextWave]));

                }
            }
            else
            {
                waveCountDown -= Time.deltaTime;
            }

        }
    }

    private void WaveCompleted()
    {
        Debug.Log("Wave Completed");
        state = spawnStates.COUNTING;
        if(nextWave + 1 > enemyWaves.Length - 1)
        {
            Debug.Log("Restart Round");
            nextWave = 0;
            waveCountDown = TBNextWave;
            return;
        }
        nextWave++;
        waveCountDown = TBNextWave;

    }

    private bool IsEnemyAlive()
    {
        if(asteroidFol.childCount != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator SpawnWave(Sc4_Waves wave)
    {
        Debug.Log("Spawning wave " + wave.index);
        state = spawnStates.SPAWNING;
        for (int i = 0; i < wave.enemyTypes.Length; i++)
        {


            Sc4_Enemy enemy = wave.enemyTypes[i];
            for (int j = 0; j < enemy.count; j++)
            {
                SpawnEnemy(enemy.trans);
                print("enemy.count = " + enemy.count);
                Debug.Log(enemy.name + " " + j);
                yield return new WaitForSeconds(1f / enemy.rate);
            }
        }
        state = spawnStates.WAITING;


        yield break;
    }

    private void SpawnEnemy(Transform enemy)
    {
        GameObject newEnemy = Instantiate(enemy.gameObject, Vector3.zero, Quaternion.identity, asteroidFol);
        newEnemy.GetComponent<RectTransform>().position = spawnLocation.position;
        Debug.Log("Enemy spawned " + enemy.name);
    }

    [System.Serializable]
    public class Sc4_Waves
    {
        public Sc4_Enemy[] enemyTypes;
        public int index;

    }

    [System.Serializable]
    public class Sc4_Enemy
    {
        public string name;
        public Transform trans;
        public float weight;

        public int count;
        public float rate;
    }

    


    private void IsShowUpgradesmenu()
    {
        if (isShowUpgradesMenu)
        {
            upgradeMenu.GetComponent<Animator>().SetBool("UpgradesMenuShow", true);
            upgradeButton.position = Vector3.MoveTowards(upgradeButton.position, new Vector3(-100, 28), 10f);
        }
        else
        {
            upgradeMenu.GetComponent<Animator>().SetBool("UpgradesMenuShow", false);
            upgradeButton.position = Vector3.MoveTowards(upgradeButton.position, new Vector3(97.8f, 28), 10f);
        }

    }

    public void ShowUpgradesMenu()
    {
        isShowUpgradesMenu = true;
    }

    public void HideUpgradeMenu()
    {
        isShowUpgradesMenu = false;
    }
}
