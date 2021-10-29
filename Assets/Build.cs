using UnityEngine;
using System.Collections;
using System;

public class Build : MonoBehaviour
{

    public Camera fpsCam;
    public GameObject newBlock;
    public GameObject previewBlock;
    public int blockPlace = 1;
    public float totalBlocks = 5;
        

    void Start()
    {
        Debug.Log("Building Script Loaded.");
        
    }


    void Update()
    {
        ///////////////////////// UNFINISHED. Blocks currently can change in the inspector on the press of r, just not to the right one, will try to find gameobject by name later.//////////////////////
        //detect key down to cycle through int, will correlate to what block you want to place
        if (Input.GetKeyDown("r"))
        {

            //add one to the counter each time r is pressed
            blockPlace++;
            Debug.Log("blockPlace Changed" + blockPlace);

            //reset counter once it reaches value in totalBlocks (uncomplete, not sure why it doesnt work >:( )
            if (blockPlace == 2)
            {
                blockPlace = 1;
            }
            

            //attempt to switch newBlock (see above) to be used by the instantiate blocks, based on the value of blockPlace. 
            if (blockPlace == 1)
            {
                newBlock = GameObject.FindWithTag("Cube1");
                
            }
            //Same as above
            else if (blockPlace == 2)
            {
                newBlock = GameObject.FindWithTag("Cube2");
                // Debug.Log("GameObject newBlock set to " + newBlock);
            }


        }


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
