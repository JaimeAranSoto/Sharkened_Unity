using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class GameManager : MonoBehaviour
{

    public PlayerMovement player;
    public int time = 60;
    public int haunted = 0;
    // Use this for initialization
    void Start()
    {
        StartCoroutine("Substract");
    }

    // Update is called once per frame

    IEnumerator Substract()
    {
        while (time > 0)
        {
            time--;
            yield return new WaitForSeconds(1f);
        }
    }

    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.


    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

    }
    //Update is called every frame.
    void Update()
    {

    }
}