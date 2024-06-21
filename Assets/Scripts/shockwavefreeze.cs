using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shockwavefreeze : MonoBehaviour
{
    private Animation Anim;
    private string mode;
    // Start is called before the first frame update
    void Start()
    {
        Anim = gameObject.GetComponent<Animation>();
        Anim.Play();
        StartCoroutine(ou());
    }

    IEnumerator ou()
    {
        if (gameObject.name == "shockwaveFreeze1(Clone)")
        {
            mode = "Freeze1";
            yield return new WaitForSeconds(0.55f);
            GameObject.Destroy(gameObject);
        }

        if (gameObject.name == "shockwaveFreeze2(Clone)")
        {
            mode = "Freeze2";
            yield return new WaitForSeconds(1f);
            GameObject.Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);
        if(collision.gameObject.tag != "PLAYER" && collision.gameObject.name != "CORE" && collision.gameObject.name != "shockwaveFreeze1(Clone)" && collision.gameObject.name != "shockwaveFreeze2(Clone)" && mode == "Freeze1")
        {
            wallManager lol = (wallManager)collision.gameObject.GetComponent(typeof(wallManager));
            if (lol != null)
            {
                collision.attachedRigidbody.constraints = RigidbodyConstraints2D.None;
                lol.BO();
            }
            else
            {
                print("ignored " + gameObject.name);
            }
        }
        if(collision.gameObject.tag == "PLAYER" && collision.gameObject.name != "CORE" && collision.gameObject.name != "shockwaveFreeze2(Clone)" && mode == "Freeze2")
        {
            PLAYERManager lol = (PLAYERManager)collision.gameObject.GetComponent(typeof(PLAYERManager));
            lol.AttractionToBH();

        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
