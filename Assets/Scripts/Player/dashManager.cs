using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class dashManager : MonoBehaviour {
    //A ajouter au joueur (movement du dash a raffiner)

    private PointerToPos pointer;
    public delegate void SenderEventManager(object sender);
    public event SenderEventManager OnLoad;
    
    [SerializeField]
    Animator animator;
    [SerializeField]
    private float MaxDistance = 10f;

    [SerializeField]
    private float initSpeed = 30f;
    [SerializeField]
    private float speedFalloff = 2f;

    [SerializeField]
    private int dashCount = 1;
    private int maxDashCount;

    private bool ready = false;
    private bool dash = false;
    private bool canDash = false;
    bool aimsAtWall = false;
    private Vector3 direction;
    private Vector3 target;
    private float speed;
    private int wallHits = 0;
    private bool inWall;

    private bool isDashing = false;
    private float distance = 0f;

    public bool Ready
    {
        get
        {
            return ready;
        }

        private set
        {
            ready = value;
        }
    }

    public bool Dash
    {
        get
        {
            return dash;
        }

        private set
        {
            dash = value;
        }
    }

    public bool IsDashing
    {
        get
        {
            return isDashing;
        }
        private set
        {
            isDashing = value;
        }
    }

    public int DashCount
    {
        get
        {
            return dashCount;
        }

        set
        {
            dashCount = value;
        }
    }

    public int MaxDashCount
    {
        get
        {
            return maxDashCount;
        }

        set
        {
            maxDashCount = value;
        }
    }

    // Use this for initialization
    void Start ()
    {
        MaxDashCount = DashCount;
        
        pointer = Camera.main.GetComponent<PointerToPos>();
        pointer.OnFire += Pointer_OnDash;
        if (OnLoad != null)
            OnLoad.Invoke(this);
	}

    //Activé lorsque l'on arrete de maintenir le clic gauche, coeur de la gestion des règles du dash (quand peut-on dasher etc.)
    private void Pointer_OnDash(Object sender, WorldPointActionArgs args)
    {
        //Recuperation position cible et traitement pour limiter la distance et le plan.
        Vector3 diff = args.Position - transform.position;
        if (diff.magnitude > MaxDistance)
        {
            diff = diff.normalized * MaxDistance;
        }
        diff.y = 0;
        //variable pour raycast afin de determiner si l'on dash vers un mur
        RaycastHit hit = new RaycastHit();

        if (!IsDashing)
        {
            //Debug.DrawRay(transform.position, diff, Color.red, 10);
            if (Physics.Raycast(new Ray(transform.position, diff), out hit, 3f))
            {
                aimsAtWall = hit.collider.gameObject.tag == "wall";
            }
            else
            {
                aimsAtWall = false;
            }
            //test la possibilite de faire un dash
            if (Ready && DashCount > 0)
            {
                this.speed = initSpeed;
                this.DoDash(diff);
                


                //Test pour le sprite
                if (args.Position.x - transform.position.x > 0)
                {
                    this.animator.SetInteger("DashDirectionInt", -1);

                }
                else
                {
                    this.animator.SetInteger("DashDirectionInt", 1);
                    
                }
                this.dashCount--;
            }
            //if (inWall && aimsAtWall)
            //{
            //    this.Ready = false;
            //}
            //else if (this.Ready && this.DashCount > 0 )
            //{
            //    this.DashCount--;
            //}
            this.Dash = false;
            //Debug.Log(DashCount);
        }
        
    }

    //Permet d'indiquer au script que l'on souhaite executer un dash de origin vers target
    private void DoDash(Vector3 origin, Vector3 target)
    {
        this.DoDash(target - origin);

    }

    //Permet d'indiquer au script que l'onsouhaite executer un dash relatif au joueur défini par un vecteur
    private void DoDash(Vector3 path)
    {
        
        this.target = transform.position + path;
        this.direction = path.normalized;
        this.distance = path.magnitude;
        this.IsDashing = true;
        

    }

    //Appellé avec l'animation de charge, permet d'indiquer quand on peut dash
    public void ActivateDash()
    {
        
        this.Ready = true;
    }

    private void DashMove()
    {
        Vector3 toMove;
      
        if(this.distance < (direction * speed * Time.deltaTime).magnitude)
        {
            toMove = this.distance * direction;
            this.Ready = false;
            this.IsDashing = false;
            
        }
        else
        {
            toMove = direction * speed * Time.deltaTime;
            this.speed /= 1 + Time.deltaTime * speedFalloff;
            
            
        }

        transform.Translate(toMove);
        distance -= toMove.magnitude;
    }

    // Update is called once per frame
    void Update () {
        //Si peut Dash et click appuye, met Dash a true et prepare animator pour dash ou cancel dash
        if (!this.Dash && Input.GetButton("Fire1") == true && !IsDashing && DashCount > 0) 
        {
            animator.SetInteger("DashDirectionInt", 0);
            this.Dash = true;
            
        }
        this.animator.SetBool("DashBool", this.Dash);

        //si execute un dash alors bouge
        if (IsDashing)
        {
            
            this.DashMove();
            this.animator.SetBool("FinDash", false);
        }
        else
        {
            this.animator.SetBool("FinDash", true);
        }
        

    }

    //Gestion collisions

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.gameObject.tag == "wall")
        {
            this.inWall = true;
            //this.Ready = false;
            //this.IsDashing = false;
        }
        
    }
    private void OnCollisionExit(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "wall") 
        {
            this.inWall = false;
        }
    }
}
