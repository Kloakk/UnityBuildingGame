using UnityEngine;
using System.Collections;
using System;

public class Build : MonoBehaviour
{

    public Camera fpsCam;
    public GameObject newBlock;
    public GameObject previewBlock;

    public float blockPlace = 1;
    public float totalBlocks = 5;

    public float scrollValue = 1;
    Vector3 rotateValue; 


    void Start()
    {
        Debug.Log("Building Script Loaded.");
        
    }


    void Update()
    {

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            scrollValue = scrollValue + 1;
            Debug.Log(scrollValue);

            if(scrollValue == 5)
            {
                scrollValue = 1;
            }
                
            if(scrollValue == 1)
            {
                rotateValue = new Vector3 (0, 90, 0);
            }

        }





        ///////////////////////// UNFINISHED. Blocks currently can change in the inspector on the press of r, just not to the right one, will try to find gameobject by name later.//////////////////////
        ///////////////////////// Update : this works now, but its far from perfect.    
        //detect key down to cycle through int, will correlate to what block you want to place
        if (Input.GetKeyDown("r"))
        {

            //add one to the counter each time r is pressed
            blockPlace = blockPlace + 1;


            //reset counter once it reaches value in totalBlocks (uncomplete, not sure why it doesnt work >:( , for now just using assigned value)
            if (blockPlace == 4)
            {
                blockPlace = 1;
            }


            //attempt to switch newBlock (see above) to be used by the instantiate blocks, based on the value of blockPlace. 
            if (blockPlace == 1)
            {

                Debug.Log(newBlock + "Cube 1" + blockPlace);
                newBlock = GameObject.FindWithTag("Cube1");

            }
            //Same as above
            else if (blockPlace == 2)
            {
                Debug.Log(newBlock + "Cube 2" + blockPlace);
                newBlock = GameObject.FindWithTag("Cube2");
                // Debug.Log("GameObject newBlock set to " + newBlock);
            }

            else if (blockPlace == 3)
            {
                Debug.Log(newBlock + "Edge 1" + blockPlace);
                newBlock = GameObject.FindWithTag("Edge1");

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

                GameObject block = (GameObject)Instantiate(newBlock, blockPos, Quaternion.identity, rotateValue);

                
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


    
    
}
