using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// The one and only class for the game. This controls everything.
/// 
/// Why.
/// </summary>
public class TheOneClass : MonoBehaviour
{

    // Variables
    #region
    // Public variables
    // Game Object references

    // Player object references
    public GameObject Lumi;
    public Rigidbody2D LumiProjectile;

    // Enemy Object references
    public GameObject FlyingGoblin;
    public GameObject FlyingShooter;
    public Rigidbody2D EnemyProjectile;

    // UI Object References
    // TODO: Add ui references

    // Actor Object attributes

    private int ActorHealth;

    public float LumiMovementSpeed;
    public float EnemyMovementSpeed;

    // Projectile addributes
    public float LumiProjSpeed;
    public float enemyProjSpeed;


    // Game boundaries
    public float xBoundMin, xBoundMax, yBoundMin, yBoundMax;





    // Private variables
    private bool _isLumi;
    private bool _isLumiProjectile;
    private bool _isEnemy;
    private bool _isEnemyProjectile;

    // component References
    private Rigidbody2D _rb2D;


    // projectile clones
    private Rigidbody2D lumiProjClone;

    #endregion


    // Unity functions
    #region

    // Use this for initialization
    private void Start()
    {
        // Initialize components
        _rb2D = GetComponent<Rigidbody2D>();

        // Sets default values for each of the _is... bools
        _isLumi = _isLumiProjectile = _isEnemy = _isEnemyProjectile = false;

        // Actor initialization
        // If the object this componenet is connected to is the player, initialize the player, null everything else
        if (this.gameObject.tag == "Lumi")
        {
            _isLumi = true;

            Lumi = this.gameObject;
        }

        else if (this.gameObject.tag == "Goblin")
        {
            _isEnemy = true;

            FlyingGoblin = this.gameObject;
        }

        else if (this.gameObject.tag == "Shooter")
        {
            _isEnemy = true;

            FlyingShooter = this.gameObject;

        }

        else if (this.gameObject.tag == "GameManager")
        {
            // Control the ui
        }

        else if (this.gameObject.tag == "LumiProjectile")
        {
            // initializes lumi projectile. Instantiates and fires within update
            _isLumiProjectile = true;

            LumiProjectile = this.gameObject.GetComponent<Rigidbody2D>();

        }
    }



    // Update is called once per frame
    private void Update()
    {
        if (_isLumi)
        {
            lumiAttributes();
        }
        else if (_isLumiProjectile)
        {
            lumiProjectileControl();
        }
    }

    private void FixedUpdate()
    {
        // Actor input Declaration
        // If the actor is Lumi
        if (_isLumi)
        {
            lumiPlayerInput();
        }

        // If it's an enemy
        else if (_isEnemy)
        {
            
        }


    }
    #endregion

    // Player Attributes
    #region
    private void lumiPlayerInput()
    {
        // input definition
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        bool firingProjectile = Input.GetButtonDown("Fire");

        // Define movement as vector 3
        Vector2 playerMovement = new Vector2(horizontalMovement, verticalMovement);

        // Initiate player movement
        _rb2D.velocity = playerMovement * LumiMovementSpeed;

        // clamps player movement between set bounds
        _rb2D.position = new Vector2(Mathf.Clamp(_rb2D.position.x, xBoundMin, xBoundMax), Mathf.Clamp(_rb2D.position.y, yBoundMin, yBoundMax));

        // Fires projectile
        if (firingProjectile)
        {
            lumiProjClone = LumiProjectile;
            Instantiate(lumiProjClone, transform.position, transform.rotation);
            lumiProjectileControl();
        }
    }

    private void lumiAttributes()
    {

    }

    // Player Projectile Control
    private void lumiProjectileControl()
    {
        lumiProjClone.velocity = transform.TransformDirection((Vector2.right * LumiProjSpeed) * Time.deltaTime);
    }

    #endregion

    // Enemy Attributes
    #region
    private void EnemyInput()
    {
        /*
        // input definition
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        // Define movement as vector 3
        Vector2 playerMovement = new Vector2(horizontalMovement, verticalMovement);

        // Initiate player movement
        _rb2D.velocity = playerMovement * LumiMovementSpeed;

        // clamps player movement between set bounds
        _rb2D.position = new Vector2(Mathf.Clamp(_rb2D.position.x, xBoundMin, xBoundMax), Mathf.Clamp(_rb2D.position.y, yBoundMin, yBoundMax));
        */
    }

    #endregion


    // Projectile collision detection
    #region


    #endregion



}
