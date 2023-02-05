using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Toninho;


public class FiniteEnemySpawner : MonoBehaviour, EventListener<GameEvent>
{
    public Vector3[] pos;
    public GameObject[] prefab;
    public float interval = 3.0f;
    public int instantiated_enemies = 0, dead_enemies = 0, max_enemies;
    public float enemy_speed;
    public string next_scene;

    void Start()
    {
        Debug.Log(pos);
    }

    void Update()
    {
        
    }

    public void begin (){
        InvokeRepeating("Spawn", 1, interval);
    }

    void Spawn(){
        int enemyIndex = Random.Range(0, prefab.Length);
        if(instantiated_enemies < max_enemies){
            Vector3 position = pos[Random.Range(0, pos.Length)];
            Quaternion rotation = Quaternion.identity;
            GameObject instance = Instantiate(prefab[enemyIndex], transform, false);
            instance.transform.localPosition = position;
            instance.transform.localRotation = rotation;

            instantiated_enemies++;
        }
    }

    public void OnEvent(GameEvent eventType) {
        if (eventType.EventName.Equals("PodeSpawnar")) {
            begin();
        }
        if (eventType.EventName.Equals("EnemyDeath")) {
            dead_enemies++;
            if(dead_enemies >= max_enemies){
                SceneManager.LoadScene(next_scene);
            }else{
                Debug.Log("falta matar "+(max_enemies-dead_enemies));
            }
        }
    }

    void OnEnable() {
        this.EventStartListening<GameEvent>();
    }

    void OnDisable() {
        this.EventStopListening<GameEvent>();
    }
}
