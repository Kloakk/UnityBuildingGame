using UnityEngine;
using System.Collections;
using System;

public class Build : MonoBehaviour
{

    public Camera fpsCam;
    public GameObject newBlock;
    public GameObject previewBlock;
    



    void Start()
    {
        Debug.Log("Building Script Loaded.");
        
    }


    void Update()
    {

       preview();
        

        if (Input.GetButtonDown("Fire1"))
        {

            LayerMask mask = LayerMask.GetMask("Part");

            RaycastHit hit;

            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 100f, mask))
            {
                Debug.Log(hit.transform.name);
                //Building a new block
                Vector3 blockPos = hit.point + hit.normal / 2;
                Vector3 awayNormal = hit.normal;


                blockPos.x = (float)Math.Round(blockPos.x, MidpointRounding.AwayFromZero);
                blockPos.y = (float)Math.Round(blockPos.y, MidpointRounding.AwayFromZero);
                blockPos.z = (float)Math.Round(blockPos.z, MidpointRounding.AwayFromZero);

                GameObject block = (GameObject)Instantiate(newBlock, blockPos, Quaternion.identity);
                block.transform.up = hit.normal;
            }
        }


        if (Input.GetButtonDown("Fire2"))
        {

            LayerMask mask = LayerMask.GetMask("Part");

            RaycastHit Delete;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out Delete, 100f, mask))
            {
                Debug.Log(Delete.transform.name);

                Destroy(Delete.transform.gameObject);
            }
        }

    }
   
    
    
    
    void preview()
    {



        LayerMask mask = LayerMask.GetMask("Part");
        LayerMask Preview = LayerMask.GetMask("Preview");

        RaycastHit hit;



        
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 100f, mask))
        {

            

            Debug.Log(hit.transform.name);
            //Building a new block
            Vector3 blockPos = hit.point + hit.normal / 2;

            blockPos.x = (float)Math.Round(blockPos.x, MidpointRounding.AwayFromZero);
            blockPos.y = (float)Math.Round(blockPos.y, MidpointRounding.AwayFromZero);
            blockPos.z = (float)Math.Round(blockPos.z, MidpointRounding.AwayFromZero);

            previewBlock = GameObject.FindWithTag("Preview");


            previewBlock.transform.position = blockPos;

            
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log(hit.transform.name);
            //Building a new block
            Vector3 blockPos = hit.point + hit.normal / 2;

            blockPos.x = (float)Math.Round(blockPos.x, MidpointRounding.AwayFromZero);
            blockPos.y = (float)Math.Round(blockPos.y, MidpointRounding.AwayFromZero);
            blockPos.z = (float)Math.Round(blockPos.z, MidpointRounding.AwayFromZero);

            previewBlock = GameObject.FindWithTag("Preview");

            Debug.Log("click registered");

            previewBlock.transform.position = blockPos;
        }


    }
    
    
}
