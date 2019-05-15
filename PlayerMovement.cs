using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody rb;
	private Vector3 movement;
	public float movementSpeed;
    public Animator anim;
	public bool hitted;
    private Vector3 currentPosition;
    public PlayerHealth playerHealth;

    public GameObject sword;

    public GameObject escudoParticles;
    public GameObject explosionParticles;
    public Transform explosionPoint;
    public GameObject panelOpcionKeyboard1, panelOpcionKeyboard2, panelOpcionController;
    public OpenDoorDetection openDoorDetection;
    public GameObject gameController;
    public SceneController sceneController;

    public bool pickedUpblue;
    public bool pickedUpOrange;
    public GameObject armaAzul, armaNaranja;

    public GameObject orangeOrbe, blueOrbe;


    public AudioSource soundsPlayer;

    public bool canMove;

    public float timeToMove;

    public bool enemyDetected;

    public int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 1f;

    public bool comboSuccess;
    public bool combo2Success;

    public bool comboAvailable;
    public int currentClicks;
    public bool canAttack;

    public bool blocking;

    public bool isDead;
    public bool canBluePickUp;
    public bool canOrangePickUp;

    public SkipTutorial skipTutorial;

    private Vector3 lastMovement;
    public Transform spellPosition;
    public GameBehav gameBehav;

    // Use this for initialization
    void Start()
    {
        
        gameController = GameObject.FindGameObjectWithTag("SceneController");
        sceneController = gameController.GetComponent<SceneController>();
        gameBehav = gameController.GetComponent<GameBehav>();
        Debug.Log("La escena actual es la numero: " + sceneController.CheckCurrentScene());

        if (sceneController.CheckCurrentScene() == 3)
        {
            canAttack = true;
            sword.SetActive(true);
        }
        else
        {
            canAttack = false;
            sword.SetActive(false);
        }

        Physics.IgnoreLayerCollision(9, 10);
        Physics.IgnoreLayerCollision(10, 10);
        soundsPlayer = GetComponent<AudioSource>();
        playerHealth = GetComponent<PlayerHealth>();
        rb = this.GetComponent<Rigidbody>();
        movementSpeed = 20f;
        anim = this.GetComponent<Animator>();
        Physics.gravity = new Vector3(0f, -50f, 0f);


    }

    private void Update()
       
    {
        PickUpSword();
        if (this.gameObject.tag == "Player")
        {
            if (Time.time - lastClickedTime > maxComboDelay)
            {
                noOfClicks = 0;
            }
            if (blocking == false)
            {
                OnClick();
            }
            
            Blocking();
        }

        


        if (this.gameObject.tag == "Player2")
        {
            if (Time.time - lastClickedTime > maxComboDelay)
            {
                noOfClicks = 0;
            }
            if (blocking == false)
            {
                OnClick();
            }

            Blocking();
        }

    }
    void Blocking()
    {
        if ((PlayerPrefs.GetInt("optionSelected") == 1))
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button5) && this.gameObject.tag == "Player")
            {
                Debug.Log("Escudo Player");
                anim.SetBool("blocking", true);
                blocking = true;
                movementSpeed = 5f;
                escudoParticles.SetActive(true);
            }
            else if (Input.GetKeyUp(KeyCode.Joystick1Button5) && this.gameObject.tag == "Player")
            {
                anim.SetBool("blocking", false);
                blocking = false;
                movementSpeed = 20f;
                escudoParticles.SetActive(false);
            }


            if (Input.GetKeyDown(KeyCode.Joystick2Button5) && this.gameObject.tag == "Player2")
            {
                anim.SetBool("blocking", true);
                blocking = true;
                movementSpeed = 5f;
                escudoParticles.SetActive(true);
            }

            else if (Input.GetKeyUp(KeyCode.Joystick2Button5) && this.gameObject.tag == "Player2")
            {
                anim.SetBool("blocking", false);
                blocking = false;
                movementSpeed = 20f;
                escudoParticles.SetActive(false);
            }
        }
        if ((PlayerPrefs.GetInt("optionSelected") == 2))
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && this.gameObject.tag == "Player")
            {
                Debug.Log("Escudo Player");
                anim.SetBool("blocking", true);
                blocking = true;
                movementSpeed = 5f;
                escudoParticles.SetActive(true);
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift) && this.gameObject.tag == "Player")
            {
                anim.SetBool("blocking", false);
                blocking = false;
                movementSpeed = 20f;
                escudoParticles.SetActive(false);
            }


            if (Input.GetKeyDown(KeyCode.KeypadEnter) && this.gameObject.tag == "Player2")
            {
                anim.SetBool("blocking", true);
                blocking = true;
                movementSpeed = 5f;
                escudoParticles.SetActive(true);
            }

            else if (Input.GetKeyUp(KeyCode.KeypadEnter) && this.gameObject.tag == "Player2")
            {
                anim.SetBool("blocking", false);
                blocking = false;
                movementSpeed = 20f;
                escudoParticles.SetActive(false);
            }
        }

    }
    void PickUpSword()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) && canBluePickUp && this.gameObject.tag == "Player" || Input.GetKeyDown(KeyCode.F) && canBluePickUp && this.gameObject.tag == "Player")
        {
            if (skipTutorial.mandoSelected)
            {
                panelOpcionKeyboard1.SetActive(false);
            }
            sword.SetActive(true);

            Destroy(blueOrbe);
            openDoorDetection.pickedUpBlue = true;
            canAttack = true;

        }

        if (Input.GetKeyDown(KeyCode.Joystick2Button1) && canOrangePickUp && this.gameObject.tag == "Player2" || Input.GetKeyDown(KeyCode.Keypad1) && canOrangePickUp && this.gameObject.tag == "Player2")
        {
            if (skipTutorial.mandoSelected)
            {
                panelOpcionKeyboard2.SetActive(false);
            }
            sword.SetActive(true);
 
            Destroy(orangeOrbe);
            openDoorDetection.pickedUpOrange = true;
            canAttack = true;
        }
    }
    void OnClick()
    {
        if (noOfClicks == 0)
        {
            ResetAll();
        }
        if (PlayerPrefs.GetInt("optionSelected") == 1)
        {
            //Record time of last button click
            if (canAttack && this.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                lastClickedTime = Time.time;
                noOfClicks++;
                if (noOfClicks == 1)
                {
                    anim.SetBool("Attack1", true);
                }

                //limit/clamp no of clicks between 0 and 3 because you have combo for 3 clicks
                noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
            }

            else if (canAttack && this.gameObject.tag == "Player2" && Input.GetKeyDown(KeyCode.Joystick2Button0))
            {
                lastClickedTime = Time.time;
                noOfClicks++;
                if (noOfClicks == 1)
                {
                    anim.SetBool("Attack1", true);
                }

                //limit/clamp no of clicks between 0 and 3 because you have combo for 3 clicks
                noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
            }
        }
        if (PlayerPrefs.GetInt("optionSelected") == 2)
        {
            //Record time of last button click
            if (canAttack && this.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
            {
                lastClickedTime = Time.time;
                noOfClicks++;
                if (noOfClicks == 1)
                {
                    anim.SetBool("Attack1", true);
                }

                //limit/clamp no of clicks between 0 and 3 because you have combo for 3 clicks
                noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
            }

            else if (canAttack && this.gameObject.tag == "Player2" && Input.GetKeyDown(KeyCode.Keypad0))
            {
                lastClickedTime = Time.time;
                noOfClicks++;
                if (noOfClicks == 1)
                {
                    anim.SetBool("Attack1", true);
                }

                //limit/clamp no of clicks between 0 and 3 because you have combo for 3 clicks
                noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {


        if (PlayerPrefs.GetInt("optionSelected") == 1)
        {
            if (this.gameObject.tag == "Player" && canMove && !isDead)
            {
                float hor = Input.GetAxisRaw("Joystick1HorizontalAxis");
                float ver = Input.GetAxisRaw("Joystick1VerticalAxis");
                movement = new Vector3(ver, 0f, hor * -1);
                movement = movement.normalized;
            }



            if (this.gameObject.tag == "Player" && !canMove || isDead)
            {
                movement = new Vector3(0, 0, 0);
            }

            if (this.gameObject.tag == "Player2" && canMove && !isDead)
            {
                float hor = Input.GetAxisRaw("Joystick2HorizontalAxis");
                float ver = Input.GetAxisRaw("Joystick2VerticalAxis");
                movement = new Vector3(ver, 0f, hor * -1);
                movement = movement.normalized;
            }


            if (this.gameObject.tag == "Player2" && !canMove || isDead)
            {
                movement = new Vector3(0, 0, 0);
            }
        }
        if (PlayerPrefs.GetInt("optionSelected") == 2)
        {
            if (this.gameObject.tag == "Player" && canMove && !isDead)
            {
                float hor = Input.GetAxisRaw("Horizontal");
                float ver = Input.GetAxisRaw("Vertical");
                movement = new Vector3(ver, 0f, hor * -1);
                movement = movement.normalized;
            }



            if (this.gameObject.tag == "Player" && !canMove || isDead)
            {
                movement = new Vector3(0, 0, 0);
            }

            if (this.gameObject.tag == "Player2" && canMove && !isDead)
            {
                float hor = Input.GetAxisRaw("Horizontal1");
                float ver = Input.GetAxisRaw("Vertical1");
                movement = new Vector3(ver, 0f, hor * -1);
                movement = movement.normalized;
            }


            if (this.gameObject.tag == "Player2" && !canMove || isDead)
            {
                movement = new Vector3(0, 0, 0);
            }
        }





        if (movement != Vector3.zero)
        {
            anim.SetBool("running", true);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.3F);
        }
        else
        {
            anim.SetBool("running", false);
        }
            transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

        

    }





    public void CheckIfCanMove()
    {
        if (comboSuccess || combo2Success)
        {
            canMove = false;
            ImAttacking();
            Debug.Log("No puedes moverte!");
        }

        else if (!comboSuccess || !combo2Success)
        {
            canMove = true;
            anim.SetBool("Attack2", false);
            anim.SetBool("Attack3", false);
            anim.SetBool("Attack1", false);
            Debug.Log("A correrr!!");
            noOfClicks = 0;
        }

    }
    public void ImAttacking()
    {
        canMove = false;
    }
    public void ComboAvailable()
    {
        comboAvailable = true;
    }

    public void ComboUnavailable()
    {
        comboAvailable = false;
        anim.SetBool("comboSuccess", false);
    }

    public void CheckCurrentNumberOfClicks ()
    {
 
        currentClicks = noOfClicks;
        ActivateAnimations();
        Debug.Log(noOfClicks);
    }

    public void ActivateAnimations()
    {
        if (noOfClicks == 0)
            ResetAll();
        if (noOfClicks >= 2 && comboAvailable)
        {

            comboSuccess = true;
            anim.SetBool("Attack2",true);
            anim.SetBool("comboSuccess", true);
        }

        if (noOfClicks == 3 && comboAvailable)
        {
            anim.SetBool("combo2Success", true);
            anim.SetBool("Attack2",true);
            anim.SetBool("Attack3",true);
            combo2Success = true;
        }

    }

    public void ResetAll()
    {
        anim.SetBool("comboSuccess", false);
        anim.SetBool("combo2Success", false);
        anim.SetBool("Attack1", false);
        anim.SetBool("Attack2", false);
        anim.SetBool("Attack3", false);
        canMove = true;
        noOfClicks = 0;

        
    }
    public IEnumerator CantAttack()
    {
        canAttack = false;
        yield return new WaitForSeconds(1f);
        canAttack = true;
    }

    public void FinishComboSuccess()
    {
        comboSuccess = false;
    }
    public void FinishCombo2Success()
    {
        combo2Success = false;
    }

    public void CastEffect()
    {
        GameObject explosion =  Instantiate(explosionParticles, explosionPoint.position, explosionPoint.rotation);
        Destroy(explosion, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.tag == "Player" && other.tag == "armarioAzul")
        {
            if (!skipTutorial.mandoSelected)
            {
                panelOpcionKeyboard1.SetActive(true);
            }
            if (skipTutorial.mandoSelected)
            {
                panelOpcionController.SetActive(true);
            }

            canBluePickUp = true;
        }


        if (this.gameObject.tag == "Player2" && other.tag == "armarioNaranja")
        {
            if (!skipTutorial.mandoSelected)
            {
                panelOpcionKeyboard2.SetActive(true);
            }
            if (skipTutorial.mandoSelected)
            {
                panelOpcionController.SetActive(true);
            }
            canOrangePickUp = true;
        }

    }

    private void OnTriggerStay(Collider other)
    {

        if (this.gameObject.tag == "Player" && other.tag == "armarioAzul")
        {
            if (!skipTutorial.mandoSelected)
            {
                panelOpcionKeyboard1.SetActive(true);
            }
            if (skipTutorial.mandoSelected)
            {
                panelOpcionController.SetActive(true);
            }
            canBluePickUp = true;
        }
        if (this.gameObject.tag == "Player2" && other.tag == "armarioNaranja")
        {
            if (!skipTutorial.mandoSelected)
            {
                panelOpcionKeyboard2.SetActive(true);
            }
            if (skipTutorial.mandoSelected)
            {
                panelOpcionController.SetActive(true);
            }
            canOrangePickUp = true;
        }
    }

       


    private void OnTriggerExit(Collider other)
    {
        if (this.gameObject.tag == "Player" && other.tag == "armarioAzul")
        {
            if (!skipTutorial.mandoSelected)
            {
                panelOpcionKeyboard1.SetActive(false);
            }
            if (skipTutorial.mandoSelected)
            {
                panelOpcionController.SetActive(false);
            }
            canBluePickUp = false;
        }

        if (this.gameObject.tag == "Player2" && other.tag == "armarioNaranja")
        {

            if (!skipTutorial.mandoSelected)
            {
                panelOpcionKeyboard2.SetActive(false);
            }
            if (skipTutorial.mandoSelected)
            {
                panelOpcionController.SetActive(false);
            }
            canOrangePickUp = false;

        }
    }

    public void ResetClicks()
    {
        noOfClicks = 0;
    }
}














