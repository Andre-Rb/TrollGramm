using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pacman : MonoBehaviour
{

    public float delaiPacman = 10.0f;
    bool wait = false;
     Persistance levelInfo;


    public Transform player;
    NavMeshAgent agent;

    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        Debug.Log(FindObjectsOfType<Persistance>().Length);
        levelInfo = FindObjectOfType<Persistance>();
        StartCoroutine(Wait());
    }

    void Update()
    {
        if (wait)
        {
            agent.SetDestination(player.position);

        }
    }

    IEnumerator Wait()
    {
        while (true)
        {
            yield return new WaitForSeconds(delaiPacman);

            wait = true;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            levelInfo.AlreadyDiedScene02 = true;

            SceneManager.LoadScene("Scene02");
        }
    }
}
