using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtFreeze : MonoBehaviour
{
    public Transform CharacterMesh;
    public Transform personaje;

    public float ghostPositionY;
    public Transform ghostTransform;
    public Vector3 velocity = Vector3.zero;
    public float speed;

    public bool cam_colliison;
    private GameObject player;
    private GameObject playerpref;
    public bool salt = true;
    private Camera cam;
    bool call; static float t = 0.0f;

    void OnLeaveGround()
{
    // update Y for behavior 3
    ghostPositionY = CharacterMesh.position.y;

        

    }



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerpref = GameObject.Find("PlayerPref");
        cam = GameObject.Find("Camera").GetComponent<Camera>();
    }
    void Update() {
       
      

        if (salt)
        {
            ghostPositionY = CharacterMesh.position.y;

        }
        if (personaje&& !cam_colliison)
        {
            this.transform.parent = playerpref.transform.parent;
           
           
           
        }
        else
        {
            this.transform.parent = player.transform;
            speed = 0;
            salt = true;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (personaje)
        {
            if (!salt)
            {
                Vector3 characterViewPos = cam.WorldToViewportPoint(CharacterMesh.position  * Time.deltaTime);

                if (characterViewPos.y > 1.2f || characterViewPos.y < 0.3f)
                {
                    ghostPositionY = CharacterMesh.position.y;
                }
               
            }
            
            var desiredPosition = new Vector3(CharacterMesh.position.x, ghostPositionY, CharacterMesh.position.z);
            ghostTransform.position = Vector3.SmoothDamp(ghostTransform.position, desiredPosition, ref velocity, speed * Time.deltaTime);

        }
    }
}
