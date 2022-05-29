using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes2 : MonoBehaviour
{

    // fix movement bug, ()
    // only move when finishing rightclick ()
    // bug fix selection making extra non removeable boxes
    // make them find myship at creation
    // bug fixes Make it so guns shoot at other tags then their own.!
    // change color at selection of team.
    //          -  fix when craaft are destroyed they create error.!

    ////////////////////////////////////
    /////////////////////////////////////


    // thrusters
    // turn off thrusters at stop.
    // turn off thrusters at slow x comp speeds
    // thrusters for manual cntrol
    //

    // full game schedule
    // 17 weeks till august
    // 

    //task remaining for arena
    // task 1 finish movement
    //          - fix movement for all teams
    //          - fix the movmenent when craft flies to backward if the target is near
    //          - lean target when chasing 
    //          - make AI
    //          - make torpeedo Mover
    //          - make 
    //          - balance of power
    //          - ai preference selector button
    //          - formation preference button
    //          - fix the dame door
    //          - make algorithem that converts shiptemplate info to grid in the shipmaker shit
    //          - make AI
    //




    // Task Today
    // dev mode where you can control all ships withright click or manual movement
    // crate AI. that follows and does the planned things

    // task 2 finish thrusters
    //          - add manual thruster animation
    //          - fix x thrusters
    //          - add turn thrusters

    // task 2.5 end game screen.
    // task 2.6 options menu.

    // task 3 different teams tags given at spawn.
    // task 4 kill animation
    // task 5 thruster animation
    // task 6 sound
    // task 7 graphics

    //task for ship maker
    // change color maybe
    // task 2 fix saving bug
    // task 3 make componenet list so it takes stuff directly from a list or array.
    // task 4 make images for all guns
    // task 5 set data for all guns
    // task 6 make projectile prefab for all guns.!
    // add 15 diff ships
    // add weapons
    // weapons 
    //  - laser
    //    - simple
    //    - supercharged
    //  - torpeedo
    //     - 10g
    //     - 15g
    //     - 20g
    //     - explosive warhead
    //     - emp round
    //     - jammer round
    //     - mines 
    //  - mines
    //  - pdc 
    //     - exploding rounds
    //     - armour penitrator rounds
    //  - cannon 
    //     - exploding rounds (used for defence angaist torpedos)
    //     - ap rounds
    //  - rail guns
    //  - 
    //  - plasma weapons
    //     - plasma pdc
    //     - plasma torpeedo
    //     - plasma 
    //  - anti mattar weapons
    //     - anti mattar torpedo
    //     - anti mattar railgun
    //  - emp weapons
    //     - emp mines
    //     - emp torpeedos
    //     - emp cannon rounds
    //     - 
    //  - 
    // componenets 
    //  - 


    // feature for faster speed
    // pause normal double triple speed

    //spawn different team craft

    // work on ai
    // long range ai
    // medium reange ai
    // short range i will rush you ai

    // make a map map
    //earth moon and some planet defence stations
    // 3 defence platforms large full spec production
    // 5 medium size ones medium scale production
    // 10 small scale one small size production. 

    // team indicator colors (later to do)
    // 


    // task for today..
    /// formation making
    // give current formation maker and save it in the  <list> of class formation
    // make it so that whenever it is selected again keep the ships in same formation
    // when you select an object remove it from the formation
    // if selecting a bunch of objects remove them from old formations add them to new one.
    // if you select an object and then move the formation they will not move as a group and not rearrange
    // 

    /// 23 may 2022 (incomplete)
    ///  
    // pass all orders to craft from formation setter
    // 1 2 3 or selected craft will recieve orders from formation setter
    // each order will create formation.
    /// create list of class formations
    /// add all selected moved crafts to this list
    /// if one or some are selected all are selected to undo this add small button to middle of formation to delete formation.
    /// have this middle of formation average of the positions of the objects
    /// 

    /// 23 may 2022
    // make formation face the direction you pointed with vector targeting.!
    /// 

    // give indication of where the crafts will be as you position them..!

    /// For Later <Formations>
    /// <Making_AI> AI
    // ai will work from tweenScript
    // all decisions will be made on the tweenScript
    /// Overall AI Strategy.
    /// <Defenece>
    /// - Make a few fixed defensive formation
    /// - fixed positions for flanks and what crafts to fit there.!

    /// <Offensive>
    /// - Make a few Offensive formations
    /// - fixed positions for flanks and what crafts to fit there.!
    /// - 
    /// - 
    /// choose target using tween script
    /// Set Destination at a distance from enemy.
    // 
    /// <2>  
    /// <3> 
    /// 
    

    /// 28th may 2022
    /// <Bullet_Script>
    /// Make it hold Bullet Speed
    /// make it hold Bullet Damage.
    /// Use this Damage in ships
    /// Give this to Compoenet ID of Weapons.!
   // /// Add A Damage bonus Modifier List to FigherMainScript where all the Damage modifiers are added to bullet damage at spawn
    /// 
    /// 
    ///
    
    ///<May_29_2022>
    /// 1 - make a code for detecting hits on a object
    /// 1a - if the bullet is some distacnce from target hit confirmed.!
    /// <one> if the bullet is within the targets x meters. trigger a function in the fighter main script
    /// <two> reduce health when triggered.!!
    /// <three> Plan to add a few new guns.!
    
    /// <Ship_Maker>
    /// <one> make a feature that creates a grid from template. all we need to do is add where there is a node and it will crate the grid..!
    /// <Task1> Create a grid node template\
    /// <Task2> Create a int 2d array for craft template where -1 means there is no node here. everyone else has a node.
    /// <task3> display this node.!


    

}
