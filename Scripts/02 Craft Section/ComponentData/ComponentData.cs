using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComponentData : MonoBehaviour
{
    public ComponenetTemplate powerComponent01;

    public ComponenetTemplate weaponsComponent11;
    public ComponenetTemplate weaponsComponent12;
    public ComponenetTemplate weaponsComponent13;
    public ComponenetTemplate weaponsComponent14;

    public ComponenetTemplate armourComponent21;

    public ComponenetTemplate batteryComponent31;
    public ComponenetTemplate batteryComponent32;


    public ComponenetTemplate engineComponent41;

    public Image powerCompImage01;


    public Sprite weaponsCompImage11;
    public Sprite weaponsCompImage12;
    public Sprite armourCompImage21;
    public Sprite batteryCompImage31;
    public Sprite batteryCompImage32;

    public GameObject bulletPrefab11;
    public GameObject bulletPrefab12;
    public GameObject bulletPrefab13;

    public List<ComponenetTemplate> allComponents;
    public List<ComponenetTemplate> allComponenets2;

    private void Start()
    {
        allComponents = new List<ComponenetTemplate>();
        allComponenets2 = new List<ComponenetTemplate>();
        powerComponent01 = new ComponenetTemplate();
        PowerComponentData01();

        for (int i =0;i<100;i++)
        {
           // Debug.Log("here");
            allComponenets2.Add(powerComponent01);
         //   Debug.Log(allComponenets2.Count);
        }





        weaponsComponent11 = new ComponenetTemplate();
        weaponsComponent12 = new ComponenetTemplate();
        weaponsComponent13 = new ComponenetTemplate();
        weaponsComponent14 = new ComponenetTemplate();

        armourComponent21 = new ComponenetTemplate();
        batteryComponent31 = new ComponenetTemplate();
        batteryComponent32 = new ComponenetTemplate();

        engineComponent41 = new ComponenetTemplate();


        WeaponsComponentData11();
        WeaponsComponentData12();
        ArmourComponentData21();
        BatteryComponentData31();
        BatteryComponentData32();
    }


    public void PowerComponentData01()
    {
        powerComponent01.componentName = "Power Cell";
        powerComponent01.componentID = 01;
        powerComponent01.componentSizeX = 1;
        powerComponent01.componentSizeY = 1;
        allComponents.Add(powerComponent01);
        
    }



    public void WeaponsComponentData11()
    {
        weaponsComponent11.componentName = "PDC System";
        weaponsComponent11.componentID = 11;
        weaponsComponent11.componentSizeX = 1;
        weaponsComponent11.componentSizeY = 1;
        weaponsComponent11.componentImage = weaponsCompImage11;
        weaponsComponent11.shotsPerSalvo = 5;
        weaponsComponent11.timeBetweenSalvos = 2;
        weaponsComponent11.timeBetweenEachShot = 0.08f;
        weaponsComponent11.bulletPrefab = bulletPrefab11;
        weaponsComponent11.bulletSpeed = 80f;
        weaponsComponent11.bulletDamage = 10;
        weaponsComponent11.inaccuracy = 0.025f;

        allComponents.Add(weaponsComponent11);
        allComponenets2[11] = weaponsComponent11; 
    }

    public void WeaponsComponentData12()
    {
        weaponsComponent12.componentName = "Cannon 01";
        weaponsComponent12.componentID = 12;
        weaponsComponent12.componentSizeX = 1;
        weaponsComponent12.componentSizeY = 1;
        weaponsComponent12.componentImage = weaponsCompImage12;
        weaponsComponent12.shotsPerSalvo = 1;
        weaponsComponent12.timeBetweenSalvos = 2;
        weaponsComponent12.timeBetweenEachShot = 0.1f;
        weaponsComponent12.bulletPrefab = bulletPrefab12;
        weaponsComponent12.bulletSpeed = 100f;
        weaponsComponent12.bulletDamage = 100;
        weaponsComponent12.inaccuracy = 0.001f;
        allComponents.Add(weaponsComponent12);
        allComponenets2[12] = weaponsComponent12;
    }

    public void WeaponsComponentData13()
    {
        weaponsComponent13.componentName = "Cannon 02";
        weaponsComponent13.componentID = 13;
        weaponsComponent13.componentSizeX = 1;
        weaponsComponent13.componentSizeY = 1;
        weaponsComponent13.componentImage = weaponsCompImage12;
        weaponsComponent13.shotsPerSalvo = 2;
        weaponsComponent13.timeBetweenSalvos = 2;
        weaponsComponent13.timeBetweenEachShot = 0.1f;
        weaponsComponent13.bulletPrefab = bulletPrefab12;
        weaponsComponent13.bulletSpeed = 100f;
        weaponsComponent13.bulletDamage = 100;
        weaponsComponent13.inaccuracy = 0.001f;
        allComponents.Add(weaponsComponent13);
        allComponenets2[13] = weaponsComponent13;

    }
    public void WeaponsComponentData14()
    {
        weaponsComponent14.componentName = "Ray Gun";
        weaponsComponent14.componentID = 14;
        weaponsComponent14.componentSizeX = 1;
        weaponsComponent14.componentSizeY = 1;
        weaponsComponent14.componentImage = weaponsCompImage12;
        weaponsComponent14.shotsPerSalvo = 1;
        weaponsComponent14.timeBetweenSalvos = 5;
        weaponsComponent14.timeBetweenEachShot = 0.1f;
        weaponsComponent14.bulletPrefab = bulletPrefab12;
        weaponsComponent14.bulletSpeed = 100f;
        weaponsComponent14.bulletDamage = 100;
        weaponsComponent14.inaccuracy = 0.001f;
        allComponents.Add(weaponsComponent14);
        allComponenets2[14] = weaponsComponent14;

    }

    public void ArmourComponentData21()
    {
        armourComponent21.componentName = "Steel Armour";
        armourComponent21.componentID = 21;
        armourComponent21.componentSizeX = 1;
        armourComponent21.componentSizeY = 1;
        armourComponent21.componentImage = armourCompImage21;
        allComponents.Add(armourComponent21);

    }

    public void BatteryComponentData31()
    {
        batteryComponent31.componentName = "Batter Name";
        batteryComponent31.componentID = 31;
        batteryComponent31.componentSizeX = 1;
        batteryComponent31.componentSizeY = 1;
        batteryComponent31.componentImage = batteryCompImage31;
        allComponents.Add(batteryComponent31);
    }


    public void BatteryComponentData32()
    {
        batteryComponent32.componentName = "Batter Name 2x2";
        batteryComponent32.componentID = 32;
        batteryComponent32.componentSizeX = 2;
        batteryComponent32.componentSizeY = 2;
        batteryComponent32.componentImage = batteryCompImage32;
        allComponents.Add(batteryComponent32);
    }


    public int FindMyComponent(int componentID)
    {
        int IDValue;
        IDValue = 0;
        foreach (ComponenetTemplate i in allComponents)
        {
            if(componentID == i.componentID)
            {
               
            }
            else
            {
               
            }
        }
        return IDValue;
    }
}


public class ComponenetTemplate
{
    public string componentName;
    public int componentID;

    public int componentSizeX;
    public int componentSizeY;

    public Sprite componentImage;
    public GameObject bulletPrefab;

    public int shotsPerSalvo;
    public float timeBetweenSalvos;
    public float timeBetweenEachShot;
    public float inaccuracy;
    public float bulletSpeed;
    public float bulletDamage;





}