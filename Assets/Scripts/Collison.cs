using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collison : MonoBehaviour
{
    private MeshFilter playerFilter;
    [SerializeField] private GameObject obstPS;
    // Start is called before the first frame update
    void Start()
    {
        playerFilter=GetComponent<MeshFilter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("CubeObst Instance")|| other.CompareTag("SphereObst Instance") || other.CompareTag("PrismObst Instance"))
        {

            if (other.CompareTag(playerFilter.mesh.name))
            {
                //Debug.Log(other.gameObject.name);
                GameObject obstaclePS= Instantiate(obstPS, transform.position, Quaternion.identity);
                obstaclePS.GetComponent<ParticleSystemRenderer>().mesh=other.GetComponent<MeshFilter>().mesh;
                Destroy(obstaclePS,3f);
            }
            else
            {
                //Debug.Log("endgame");
            }
        }
    }
}
