using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAI : MonoBehaviour
{
    PlayerMovement player;
    Animator anim;
    public float speed = 25f;
 
    public float nearCheck = 3f;
    // Use this for initialization
    void Start()
    {
        player = GameManager.instance.player;
        anim = GetComponent<Animator>();
		anim.speed = Mathf.Clamp(Random.value,0.8f,1f);
        StartCoroutine("CheckPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 localForward = transform.worldToLocalMatrix.MultiplyVector(transform.forward);
        transform.Translate(localForward * speed * Time.deltaTime);
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 5, Color.yellow);

    }
    IEnumerator CheckPlayer()
    {
        while (true)
        {
            if (isPlayerNear())
            {
				//Debug.Log("Corree!"+Time.frameCount);
				anim.SetBool("Run",true);
                if (!Physics.Raycast(transform.position, player.gameObject.transform.TransformDirection(Vector3.forward), 5))
                {
					transform.rotation = Quaternion.Lerp(transform.rotation,player.transform.rotation,Mathf.Clamp(Random.value,0.6f,1f));
                    
                }
            }else{
			
				anim.SetBool("Run",false);
			}
            yield return new WaitForSeconds(3f);
        }
    }

    bool isPlayerNear()
    {
        return (Vector3.Distance(transform.position, player.gameObject.transform.position) <= nearCheck);
    }

    public void die(){
        Debug.Log(gameObject.name + " me morii aaah");
        GameManager.instance.haunted+=1;
        Instantiate(Resources.Load("Particles/Blood"),transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
