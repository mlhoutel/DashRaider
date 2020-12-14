using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    dashManager dash;
    
    [SerializeField]
    private float speed = 7f;
    [SerializeField]
    private float speedX;
    [SerializeField]
    private float speedY;

    private bool KeyUp;
    private bool KeyDown;
    private bool KeyLeft;
    private bool KeyRight;
    private bool KeyReset;

    public KeyCode StringKeyUp = GameData.BindKeyUp;
    public KeyCode StringKeyDown = GameData.BindKeyDown;
    public KeyCode StringKeyLeft = GameData.BindKeyLeft;
    public KeyCode StringKeyRight = GameData.BindKeyRight;
    public KeyCode StringKeyReset = GameData.BindKeyReset;

    [SerializeField]
    private int probaWaitAnim = 400;
    // Use this for initialization
    void Start()
    {
        //Test des touches
        if (StringKeyUp == KeyCode.None) //StringKeyUp.ToString() == "None" || StringKeyUp==KeyCode.None)
        {
            StringKeyUp = KeyCode.Z;
        }

        if (StringKeyDown == KeyCode.None) //StringKeyDown.ToString() == "None" || StringKeyDown == KeyCode.None)
        {
            StringKeyDown = KeyCode.S;
        }

        if (StringKeyLeft == KeyCode.None) //StringKeyLeft.ToString() == "None" || StringKeyLeft == KeyCode.None)
        {
            StringKeyLeft = KeyCode.Q;
        }

        if (StringKeyRight == KeyCode.None) //StringKeyRight.ToString() == "None" || StringKeyRight == KeyCode.None)
        {
            StringKeyRight = KeyCode.D;
        }

        if (StringKeyUp == KeyCode.None) //StringKeyReset.ToString() == "None" || StringKeyUp == KeyCode.None)
        {
            StringKeyReset = KeyCode.R;
        }

        if (GameData.gameStarted)
        {
            this.transform.position = GameData.positionApparition;
        }
        else
        {
            GameData.positionApparition = this.transform.position;

        }

        //animator = GetComponent<Animator>();
        dash = GetComponent<dashManager>();
        speedX = 0;
        speedY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        StringKeyUp = GameData.BindKeyUp;
        StringKeyDown = GameData.BindKeyDown;
        StringKeyLeft = GameData.BindKeyLeft;
        StringKeyRight = GameData.BindKeyRight;
        StringKeyReset = GameData.BindKeyReset;


    /*
    KeyUp = Input.GetAxisRaw("Vertical") > 0;
    KeyDown = Input.GetAxisRaw("Vertical") < 0;
    KeyLeft = Input.GetAxisRaw("Horizontal") < 0;
    KeyRight = Input.GetAxisRaw("Horizontal") > 0;
    KeyReset = Input.GetKeyDown("space");
    */

    KeyUp = Input.GetKey(StringKeyUp);
        KeyDown = Input.GetKey(StringKeyDown);
        KeyLeft = Input.GetKey(StringKeyLeft);
        KeyRight = Input.GetKey(StringKeyRight);
        KeyReset = Input.GetKeyDown(StringKeyReset);

        if (KeyReset)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (!(dash.IsDashing || dash.Dash)) 
        {
            if ((KeyUp && KeyDown) || (!KeyUp && !KeyDown))
            {
                speedY = 0;
            }
            else if (KeyUp)
            {
                speedY = speed;
                animator.SetTrigger("DownUpMoveTrigger");
            }
            else if (KeyDown)
            {
                speedY = -speed;
                animator.SetTrigger("DownUpMoveTrigger");
            }

            if ((KeyLeft && KeyRight) || (!KeyLeft && !KeyRight))
            {
                speedX = 0;
            }
            else if (KeyRight)
            {
                speedX = speed;
                animator.SetTrigger("RightMoveTrigger");
            }
            else if (KeyLeft)
            {
                speedX = -speed;
                animator.SetTrigger("LeftMoveTrigger");
            }
        }
        else
        {
            speedX = 0;
            speedY = 0;
        }

        if (speedX == 0 && speedY == 0)
        {
            animator.SetBool("MoveBool", false);

            //Random vers l'animation wait
            if (Random.Range(0, probaWaitAnim) == 10)
            {
                animator.SetTrigger("WaitTrigger");
            }
        }
        else
        {
            animator.SetBool("MoveBool", true);
        }

        transform.Translate(speedX * Time.deltaTime, 0, speedY * Time.deltaTime);
    }
}
