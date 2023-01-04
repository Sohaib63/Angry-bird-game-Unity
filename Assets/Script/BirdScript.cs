using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour
{
    /*public Rigidbody2D rb;
    public SpringJoint2D springJoint;
    public bool isPressed;
    */

    // public string Scene_Name;
    private Vector3 initialPos;
    public AudioClip startSound;
    public AudioClip throwSound;
    public AudioClip stretchSound;

    private int birdSpeed;
    private bool isBirdFired;
    private float birdWaitingTime;
    
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    public AudioManager audioManager;

    // public void Start(){
    //     AudioSource.PlayClipAtPoint(startSound, transform.position);
    // }

    public void Start()
    {
        print("Score: " + ScoreBoard.GetInstance().getScore());
        initialPos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        AudioManager.instance.PlayMySound("start");
    }
    public void OnMouseDown()
    {
        spriteRenderer.color = Color.red;
        AudioSource.PlayClipAtPoint(stretchSound, transform.position);
        AudioSource.PlayClipAtPoint(throwSound, transform.position);

    }
    public void OnMouseUp()
    {
        spriteRenderer.color = Color.white;
        rigidBody2D.gravityScale = 1;

        Vector3 distance = initialPos - transform.position;
        Vector3 force = distance * 500;
        rigidBody2D.AddForce(force);
        isBirdFired=true;
        ScoreBoard.GetInstance().AddAttempt();
        //audioManager.PlayMySound("Throw");'

    }

    public void OnMouseDrag()
    {
        Vector2 mousePose = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position =new Vector2(mousePose.x, mousePose.y);
        
        //audioManager.PlayMySound("stretch");
    }

    public void Update()
    {
        if (isBirdFired && rigidBody2D.velocity.magnitude < 0.2)
        {
            birdWaitingTime=birdWaitingTime+Time.deltaTime;
        }
        if (birdWaitingTime > 0.5)
        {
            BirdReload();
        }

        if (transform.position.x > 13.30 || transform.position.x < -12.30 || transform.position.y > 5.89 || transform.position.y < -6.36)
        {
            //SceneManager.LoadScene("Level_1");
            BirdReload();
        }

          
        if (GameObject.FindGameObjectsWithTag("monster").Length == 0)
        {
            LevelManager.instance.LoadNextLevel();
        }

    }

    public void BirdReload()
    {
        rigidBody2D.transform.position = initialPos;
        rigidBody2D.velocity = new Vector2(0, 0);
        rigidBody2D.angularVelocity = 0;
        rigidBody2D.gravityScale = 0;
        rigidBody2D.transform.rotation = Quaternion.identity;
        isBirdFired = false;
        birdWaitingTime = 0;
    }

    /*public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        springJoint = GetComponent<SpringJoint2D>();
    }
    public void Update()
    {
        if (isPressed)
        {
            rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (transform.position.x > 14.67 || transform.position.x < -13.61 || transform.position.y > 5.89 || transform.position.y < -6.36)
        {
            SceneManager.LoadScene("Level_1");
        }
    }

    private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }
    private void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;
        StartCoroutine(Release());
    }

    public IEnumerator Release()
    {
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpringJoint2D>().enabled = false;
    }
    */
}
