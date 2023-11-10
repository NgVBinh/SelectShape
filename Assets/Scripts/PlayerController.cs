using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Mesh[] playerMeshs;

    private MeshFilter playerMesh;

    [HideInInspector]
    public int tempMeshIndex = 0;

    private int countOfMeshs;

    private Animation playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerMesh = GetComponent<MeshFilter>();
        playerAnim = GetComponent<Animation>();
        countOfMeshs = playerMeshs.Length;
    }

    public void ChangeShape()
    {
        if (tempMeshIndex + 1 < countOfMeshs)
        {
            tempMeshIndex++;
        }
        else
        {
            tempMeshIndex = 0;
        }

        Invoke("ApplyMesh", 0.7f);
        ChangePlayerAnim();
    }

    private void ApplyMesh()
    {
        playerMesh.mesh = playerMeshs[tempMeshIndex];
    }

    private void ChangePlayerAnim()
    {
        switch (tempMeshIndex)
        {
            case 0:
                playerAnim.Play("sphereToCube_Anim");
                break;
            case 1:
                playerAnim.Play("cubeToPrism_Anim");
                break;
            case 2:
                playerAnim.Play("prismToSphere_Anim");
                break;
        }
    }

}
