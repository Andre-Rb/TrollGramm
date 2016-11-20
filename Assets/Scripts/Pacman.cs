using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pacman : MonoBehaviour
{

    public float delaiPacman = 10.0f;
    bool wait = false;
    public Persistance Persistance;


    public Transform player;
    NavMeshAgent agent;

    void Start()
    {

        agent = GetComponent<NavMeshAgent>();

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
            SceneManager.LoadScene("Scene02");
            Persistance.AlreadyDiedScene02 = true;
        }
    }
}
