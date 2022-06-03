using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public class Player2DControl : MonoBehaviour
{
    enum ProjectAxis { onlyX = 0 };
    ProjectAxis projectAxis = ProjectAxis.onlyX;
    [SerializeField]
    private float speed = 150;
    [SerializeField]
    private float addForce = 7;
    [SerializeField]
    private KeyCode leftButton = KeyCode.A;
    [SerializeField]
    private KeyCode rightButton = KeyCode.D;
    [SerializeField]
    private KeyCode downButton = KeyCode.S;
    [SerializeField]
    private KeyCode addForceButton = KeyCode.Space;
    [SerializeField]
    private bool isFacingRight = true;



    private Vector3 Move2D;
    private Vector3 direction;
    private float vertical;
    private float horizontal;
    private Rigidbody2D body;
    private float rotationY;
    private bool jump;
    private Animator anim;
    private int _playerObject, _platformObject;
    private bool _jumpDown = false;
    void Start()
    {
        _playerObject = LayerMask.NameToLayer("Player");
        _platformObject = LayerMask.NameToLayer("Platform");
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        body.freezeRotation = true;
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.transform.tag == "ground")
        {
            anim.SetBool("isJump", false);
            body.drag = 10;
            jump = true;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.transform.tag == "ground")
        {
            body.drag = 0;
            jump = false;
            anim.SetBool("isJump", true);
        }
    }

    void FixedUpdate()
    {
        PlatformJump();
        if (Move2D.y > 0) vertical = 1;
        else if (Input.GetKey(downButton) || Move2D.y < 0) vertical = -1; else vertical = 0;

        if (Input.GetKey(leftButton) || Move2D.x < 0) horizontal = -1;
        else if (Input.GetKey(rightButton) || Move2D.x > 0) horizontal = 1; else horizontal = 0; 

        body.AddForce(direction * body.mass * speed);

        if (Mathf.Abs(body.velocity.x) > speed / 100f)
        {
            body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * speed / 100f, body.velocity.y);
        }
        if (projectAxis == ProjectAxis.onlyX)
        
        {
            if ((Input.GetKey(addForceButton) || Move2D.y > 0) && jump)
            {
                body.velocity = new Vector2(0, addForce);
            }
        }

        if (projectAxis == ProjectAxis.onlyX)
        {
            direction = new Vector2(horizontal, 0);
        }
        else
        {
            if (Input.GetKeyDown(addForceButton)) speed += addForce; else if (Input.GetKeyUp(addForceButton)) speed -= addForce;
            direction = new Vector2(horizontal, vertical);
        }

        if (horizontal > 0 && !isFacingRight) Flip(); else if (horizontal < 0 && isFacingRight) Flip();
    }
    private void PlatformJump()
    {
        if (body.velocity.y > 0||_jumpDown)
        {
            Physics2D.IgnoreLayerCollision(_playerObject, _platformObject, true);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(_playerObject, _platformObject, false);
        }

        if (Input.GetKeyDown(downButton)){
            StartCoroutine("PlatformIgnor");
        }
    }
    private IEnumerator PlatformIgnor()
    {
        _jumpDown = true;
        Physics2D.IgnoreLayerCollision(_playerObject, _platformObject, true);
        yield return new WaitForSeconds(0.7f);
        Physics2D.IgnoreLayerCollision(_playerObject, _platformObject, false);
        _jumpDown = false;
    }

    void Flip()
    {
        if (projectAxis == ProjectAxis.onlyX)
        {
            isFacingRight = !isFacingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    void Update()
    {
       
        if (horizontal !=0)
        {
            anim.SetBool("isRun", true);
        }
        else
            anim.SetBool("isRun", false);

       
    }
}