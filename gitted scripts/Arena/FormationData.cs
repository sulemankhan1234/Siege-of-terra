using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationData : MonoBehaviour
{


    public Formations boxFormation12;
    public Formations formation20;

    public GameObject tempReference;
    

    private void Start()
    {
         MakingFormation20();
       // BoxFormation12();
       // formation20.parentGameObject.transform.Rotate(0, 90, 0);
    }

    public void MakingFormation20()
    {
        formation20 = new Formations();
        formation20.formationID = 20;
        formation20.formationNodeInfoList = new List<FormationNodeInfoClass>();
        formation20.parentGameObject = Instantiate(new GameObject("Formation20Holder"), new Vector3(0, 0, 0), Quaternion.identity);

        //int x = 0;
       // int z = 0;
        Vector3 pos = new Vector3(0, 0, 0);
        int difference = 6;
        int nodeID = 0;

        for (int z = -1; z<2; z++)
        {
            pos.x = -difference*1.5f;
            pos.z = z * difference; // difference = 5
            FormationMakerHelper(nodeID,pos);
            nodeID++;

            pos.x = pos.x + difference;
            pos.z = z * difference;
            FormationMakerHelper(nodeID, pos);
            nodeID++;

            pos.x = pos.x + difference;
            pos.z = z * difference;
            FormationMakerHelper(nodeID, pos);
            nodeID++;

            pos.x = pos.x + difference;
            pos.z = z * difference;
            FormationMakerHelper(nodeID, pos);
            nodeID++;
        }

        difference = 6;
        for (int z = -1; z < 1; z++)
        {
            pos.x = -30f;
            pos.z = z * difference; // difference = 5
            FormationMakerHelper(nodeID, pos);
            nodeID++;

            pos.x = pos.x - difference;
            pos.z = z * difference;
            FormationMakerHelper(nodeID, pos);
            nodeID++;

        }

        difference = 6;
        for (int z = -1; z < 1; z++)
        {
            pos.x = +30f;
            pos.z = z * difference; // difference = 5
            FormationMakerHelper(nodeID, pos);
            nodeID++;

            pos.x = pos.x + difference;
            pos.z = z * difference;
            FormationMakerHelper(nodeID, pos);
            nodeID++;

        }

    }

    public void FormationMakerHelper(int nodeID, Vector3 pos)
    {

        FormationNodeInfoClass temp = new FormationNodeInfoClass();
        temp.nodeID = nodeID;
        temp.positionInWorldCoordinate =
            Instantiate(tempReference, pos, Quaternion.identity, formation20.parentGameObject.transform);
        formation20.formationNodeInfoList.Add(temp);
        nodeID++;
    }

    public void BoxFormation12()
    {
        boxFormation12 = new Formations();
        boxFormation12.formationID = 12;
        boxFormation12.formationNodeInfoList = new List<FormationNodeInfoClass>();
        boxFormation12.parentGameObject = Instantiate(new GameObject("Formation20Holder"), new Vector3(0, 0, 0), Quaternion.identity);

        //int x = 0;
        // int z = 0;
        Vector3 pos = new Vector3(0, 0, 0);
        int difference = 6;
         int nodeID = 0;

        for (int z = -1; z < 2; z++)
        {
            pos.x = -difference * 1.5f;
            pos.z = z * difference; // difference = 5
            FormationMakerHelper(nodeID, pos);
            nodeID++;

            pos.x = pos.x + difference;
            pos.z = z * difference;
            FormationMakerHelper(nodeID, pos);
            nodeID++;

            pos.x = pos.x + difference;
            pos.z = z * difference;
            FormationMakerHelper(nodeID, pos);
            nodeID++;

            pos.x = pos.x + difference;
            pos.z = z * difference;
            FormationMakerHelper(nodeID, pos);
            nodeID++;
        }

    }


    public void LineFormationMaker(int numberOfCrafts)
    {
        for (int i = 0; i < numberOfCrafts; i++)
        {

        }
    }
}



public class Formations
{
    public int formationID;
    public int tempFormationID;
    public List<FormationNodeInfoClass> formationNodeInfoList; /// if nodeID is -1 it does not exist
    public GameObject parentGameObject;
}

public class FormationNodeInfoClass
{
    public int craftID;
    public int nodeID;
    public GameObject positionInWorldCoordinate;
    public int preferedCraftType; /// set 1 2 or 3.

    // will need to give each craft an ID
    // 
}

