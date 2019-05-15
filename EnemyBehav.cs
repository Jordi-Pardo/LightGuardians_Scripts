using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehav : MonoBehaviour {
    public Animator anim;
    public NavMeshAgent enemy;
   // public Transform player, player2;
    public List<Transform> targets = new List<Transform>();
    public float distance;
    public float MAXDISTANCE = 8f;
    public GameObject laser;
    public Transform spawnPointLaser;
    public float speed;
    public List<GameObject> generadores = new List<GameObject>();
    public List<GameObject> pointsToBack = new List<GameObject>();
    public GameObject generador1, generador2;
    public GameObject pointToBack1, pointToBack2;

    public PlayerHealth playerHealth, playerHealth2;
    public PlayerMovement playerMovement, playerMovement2;
    public CapsuleCollider capsuleCollider;
    public EnemyHealth enemyHealth;
    public GameObject player1Object, player2Object;
    public int num;
    public int numGenerador;
    public bool energyCharged;
    private void Awake()
    {
        if (this.gameObject.tag == "Shajhor")
        {
            generador1 = GameObject.FindGameObjectWithTag("Generador1");
            generador2 = GameObject.FindGameObjectWithTag("Generador2");
            generadores.Add(generador1);
            generadores.Add(generador2);

            pointToBack1 = GameObject.FindGameObjectWithTag("pointToBack1");
            pointToBack2 = GameObject.FindGameObjectWithTag("pointToBack2");
            pointsToBack.Add(pointToBack1);
            pointsToBack.Add(pointToBack2);
        }
        enemyHealth = this.GetComponent<EnemyHealth>();
        anim = this.GetComponent<Animator>();

        player1Object = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(player1Object);
        player2Object = GameObject.FindGameObjectWithTag("Player2");
        Debug.Log(player2Object);
        if (player1Object != null && player2Object == null)
        {
            targets.Add(player1Object.transform);
            Debug.Log(player1Object.tag);
            playerHealth = targets[0].GetComponent<PlayerHealth>();
            playerMovement = targets[0].GetComponent<PlayerMovement>();
        }
        if (player1Object == null && player2Object != null)
        {
            targets.Add(player2Object.transform);
            Debug.Log(player2Object.tag);
            playerHealth2 = targets[0].GetComponent<PlayerHealth>();
            playerMovement2 = targets[0].GetComponent<PlayerMovement>();
        }
        if (player2Object != null && player1Object !=null)
        {
            targets.Add(player1Object.transform);
            Debug.Log(player1Object.tag);
            playerHealth = targets[0].GetComponent<PlayerHealth>();
            playerMovement = targets[0].GetComponent<PlayerMovement>();

            targets.Add(player2Object.transform);
            playerHealth2 = targets[1].GetComponent<PlayerHealth>();
            playerMovement2 = targets[1].GetComponent<PlayerMovement>();
            Debug.Log(player2Object.tag);

        }


        


        // targets.Add(GameObject.FindGameObjectWithTag("Player").transform);
        //targets.Add(GameObject.FindGameObjectWithTag("Player2").transform);


        enemy = this.GetComponent<NavMeshAgent>();

        capsuleCollider = this.gameObject.GetComponent<CapsuleCollider>();









    }
    // Use this for initialization
    void Start() {
        Physics.IgnoreLayerCollision(9, 9);
        speed = 50f;

        num = Random.Range(0, targets.Count);
        Debug.Log(num);

        numGenerador = Random.Range(0,generadores.Count);
        Debug.Log(numGenerador);

        if (this.gameObject.tag == "Shajhor")
        {
            enemy.enabled = true;
            if (numGenerador == 0)
            {
                enemy.SetDestination(generadores[0].transform.position);
            }
            if (numGenerador == 1)
            {
                enemy.SetDestination(generadores[1].transform.position);
            }
        }



    }


    // Update is called once per frame
    public void Update() {
        if (this.gameObject.tag == "Shajher")
        {
            MAXDISTANCE = 50;
        }
        if (this.gameObject.tag == "Shajhor")
        {
            MAXDISTANCE = 30;
        }

        if (!enemyHealth.isDead && this.gameObject.tag != "Shajhor")

        {
            if (player1Object != null)
            {
                if (num == 0 && !playerHealth.isDead)
                {
                    distance = Vector3.Distance(targets[0].transform.position, this.transform.position);

                    if (distance < MAXDISTANCE)
                    {
                        enemy.enabled = false;
                        anim.SetBool("Attack", true);
                        this.gameObject.transform.LookAt(targets[0]);


                    }
                    if (distance > MAXDISTANCE)
                    {
                        anim.SetBool("Attack", false);
                        enemy.enabled = true;

                        enemy.SetDestination(targets[0].transform.position);
                        
                    }
                }
                else if (num == 0 && playerHealth.isDead)
                {
                    num = 1;

                    Debug.Log("numero cambiado a 1");
                }


            }

            if (player2Object != null)
            {
                if (num == 1 && !playerHealth2.isDead)
                {
                    distance = Vector3.Distance(targets[1].transform.position, this.transform.position);

                    if (distance < MAXDISTANCE)
                    {
                        enemy.enabled = false;
                        anim.SetBool("Attack", true);
                        this.gameObject.transform.LookAt(targets[1]);


                    }
                    if (distance > MAXDISTANCE)
                    {
                        anim.SetBool("Attack", false);
                        enemy.enabled = true;

                        enemy.SetDestination(targets[1].transform.position);
                        
                    }
                }
                if (num == 1 && playerHealth2.isDead)
                {
                    num = 0;
                }
                if (num == 0 && !playerHealth2.isDead)
                {
                    distance = Vector3.Distance(targets[0].transform.position, this.transform.position);

                    if (distance < MAXDISTANCE)
                    {
                        enemy.enabled = false;
                        anim.SetBool("Attack", true);
                        this.gameObject.transform.LookAt(targets[0]);


                    }
                    if (distance > MAXDISTANCE)
                    {
                        anim.SetBool("Attack", false);
                        enemy.enabled = true;
                        enemy.SetDestination(targets[0].transform.position);
                        
                    }
                }
            }
        
        }

      
            else if (enemyHealth.isDead)
            {
                enemy.enabled = false;

                capsuleCollider.enabled = false;


               
                StartCoroutine("ActionTime", 3f);
            }
        

        }
        IEnumerator ActionTime(float time)
        {
            yield return new WaitForSeconds(time);
            DestroyObject(this.gameObject);
        }

    public void CastEffect()
    {
        GameObject laserObject = Instantiate(laser, spawnPointLaser.position, spawnPointLaser.rotation);     

        Destroy(laserObject,3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.tag == "Shajhor" && other.tag == "generador")
        {
            anim.SetBool("Action", true);
            this.transform.LookAt(other.gameObject.transform.position);
            StartCoroutine(Wait(2f));
        }
    }

    public IEnumerator Wait (float num)
    {
        yield return new WaitForSeconds(num);
        anim.SetBool("Action", false);
        energyCharged = true;
        if (numGenerador == 1)
        {
            enemy.SetDestination(pointToBack1.transform.position);
        }

        if ( numGenerador == 0)
        {
            enemy.SetDestination(pointToBack2.transform.position);
        }

    }



}


