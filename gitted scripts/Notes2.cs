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
    /// <one> if the bullet is within the targets x meters. trigger a function in the fighter main script <done>
    /// <two> reduce health when triggered.!! <done>
    /// <three> Plan to add a few new guns.!

    /// <Ship_Maker>
    /// <one> make a feature that creates a grid from template. all we need to do is add where there is a node and it will crate the grid..!
    /// <Task1> Create a grid node template\
    /// <Task2> Create a int 2d array for craft template where -1 means there is no node here. everyone else has a node.
    /// <task3> display this node.!
    /// <Task0> Git mode on.!

    /// <Ship_maker>
    /// <May_31_2022>
    /// 1. Finsih the new panel, move the button closer <done>
    /// 2. Replace the buttons with pic button for crafts. <Later>
    /// 3. Make a small sursury pic for each craft. <done>
    /// 4. make code that creates grid. <done>
    /// 4.1 when clicked display grid.  <done>
    /// 4.2 grid or template reference attached to button. <done>
    /// 4.3 create referenced grid based on data.  <done>
    /// 4.4 distance betweeen each grid node and add bot left start.!  <done>

    /// <ship_Maker>
    /// <june_5_2022>
    /// Make it grid dissapear when other is selected. <done>
    /// make sure one grid is loaded at start. <later>
    /// put the created grid in a list <done>
    /// make the spacing a little better <done>
    /// make embedded script know its grid positon <done>
    /// decide weather to make it bot left scewed or centered.! <Bot_Scewed_Coz_Im_lazy> 
    /// give it Postion bot scewed <done>
    /// find difference or what i have not added in the new nodes as compared to the old ones.! <Done>
    ///    /// find a way to save all types of grids <done>
    /// WP

    /// <Ship_maker>
    /// <june_6_2022>
    /// make the spacing a little better <done> <Ideal_distance_is_61>
    /// understand what needs to be Done to make Save Sytem intigrate with the new grid andmultiple platforms <done>
    /// make a buffer that holds the current display ship temp ID <done>
    /// find a way to fix where we dont have to do a double search in updateGrid <later>
    /// Making it so that only the selected template saved designs are shown in the dropdown list. <next_session>
    /// make it so that drop down list is disabled if there is no grid displayed.! <next_session>
    /// 
    /// if possible put all stuff from placement script to the UIScript.<Later>
    /// 
    /// <Ship_Maker>
    /// <June_7_2022>
    /// Making it so that only the selected template saved designs are shown in the dropdown list. <done>
    /// Make it so that drop down list is disabled if there is no grid displayed.! <>
    /// update the dropdown array when selecting the template button.! <done_Bug_takes_2_clicks_i_dont_know_why>
    /// 
    /// fix so that the color does not change after mosueExit. <done>

    /// 

    /// <Ship_Maker>
    /// <june_9_2022>
    /// integrate new grid Code to ship creator.! <>
    /// for now make ship temp 01 as the battle ship then find new free stuff
    /// make battle ship prefab <done>
    /// Carry templateID forward  <done>
    /// give templateID to craft main script.<done>
    /// give ship size to craft main script. <done>
    /// make bullet hit script use ship size. <done>
    /// Create a prefab list for all templates in ArenaUIScript. <Later>
    /// Use templateID to select Prefab.  <Done>
    /// use same code to instantiate all other things. <done>
    /// create new weaposns. <later>
    /// 

    /// Make it so that the component list is auto updated from the componenet data script
    /// make it so that the template are automatically updated using the shipData script
    /// make atleast 10 merchant ships
    /// and atleast 10 combat ships.
    /// 

    /// <Make_new_Weapons>
    /// <flack_cannon>
    /// exploding rounds need animation
    /// proximity charge will blow near the ship primary target mines and torpedos
    /// 
    /// <a30mm_Cannon>
    /// 
    /// <Simple_MachineGun>
    /// 
    /// <RapidFire_cannon_like_on_the_AC130>
    /// give this one exploding rounds as well.!
    /// 
    /// <june_10_2022>
    /// <Explosive_Round>
    /// my position = start postition.
    /// final position list.
    /// decide on depth.
    /// decide on height.
    /// find x y z position.
    /// have 3 layers.
    /// make prefab.
    /// 

    /// <june_11_2022>
    /// collide with rotation matrix <done_it-collided_with_me>
    /// make a button to change scene. <done>
    /// make a reset button in both. <done>
    /// find sparks animation
    /// explosion animation
    /// any thing that is good for now
    /// 


    /// <june_12_2022>
    /// make torpeedo
    /// did some modeling in blender.! <Done_2h>
    /// 

    /// <June_13_2022>
    /// watched the boys had taken an alp went to sleep early

    /// <June_14_2022>
    /// make torpedo
    /// Simple Model<done>
    /// cylender with cone top, with some fines <done>
    /// engine <done>
    /// Give it Navigation script
    /// 
    /// make shiptemplate buttons
    /// Button prefab is done <done>
    /// give image to shipdata <Done>
    /// give button name ID and image from shipdata  <done>
    /// 
    /// make compoenent Selector. <done>
    /// sprite for compoenent data.  <done>
    /// Make Sure only one panel is open at a time. <done>
    /// make sure selected component is carried out like it should.! <dome> 
    /// 
    /// 
    /// 
    /// 
    /// make ShipMaker Buttons better just remake it all <done>
    /// buttons take info from component data. <done> 
    /// images, and componenet name to make list.! <done>
    /// 
    /// make bullets take info from component data not from gunattachee script <later>
    /// 
    /// targeting system as leaner.  <>
    /// heavy acc 
    /// proximity explosion.
    /// follow target. standard Interception


    /// <june_18_2022>
    /// check why the compoennt data is not spawing at the panel <done>
    /// Make it so grid works with new code <done>
    /// brain storm all kkinds of weapons <sort_of>
    /// from simple conventional weapons to advanced military weapons.! <>
    /// take comp ID from image to ui script <Done>
    /// take comp id from ui script to grid then save, right click deselects componenet <later>
    /// take image from compoenent id to grid image <done>
    /// make sure loading runs as well <done>
    /// 
    /// fix selecting new comp loads the grid to default. <done>
    /// 
    ///  
    /// <June_20_2022>
    /// <brain_storming>
    /// ac 130 40 mm 100 rpm
    /// 40 mm flak exploding rounds
    /// 40 mm ap
    /// 
    /// ac 130 105 mm hawister 10rpm
    /// 105 mm ap
    /// 105 mm flak
    ///  
    /// gatling gun 7.62 1800 rpm  CON ammo capacity
    /// lasers 
    /// torpeedos 
    /// mines
    /// 
    /// rail gun Only ap
    /// 
    /// 
    /// 
    /// plasma energy weapons
    /// 
    /// anti matter weapons
    /// 
    /// neuclear weapons
    /// 
    /// 
    /// <june_21_2022>
    /// 

    /// <june_25th_2022>
    /// 
    /// 1 make all classes static if you need them to be.!
    /// 1a component data
    /// 1b ship data
    /// 1c 
    /// 
    /// add front section for weapons placement 
    /// give different sections different colors in grid
    /// make it work
    /// 
    /// make all weapons 
    /// 
    /// make ai
    /// 
    /// 
    ///<june_26_2022>
    /// remake save game <done>
    /// just add i game instance to the save file. <done>
    /// 

    /// <june_27_2022>
    /// make Central AI controller
    /// Give them List of crafts
    /// give them formation
    /// 
    /// come up with a rearangeing way
    /// idea 1. linear game fixed enemy types.!
    /// backliner, frontliner set places when craft destroyed rearrange formations
    /// 
    /// idea 2. just put biggest most impotant types infront while smaller longer range at flanks
    /// 
    /// idea 3. faster hard hitters at flanks for backline
    /// 
    /// idea 4. make hard coded formation maker. that makes a formation like the gridmaker. make formation put crafts there
    ///         set orientation
    ///         
    /// Make one script that handles Enemy AI.
    /// AI Intercepter.! set range to stop.
    /// AI long Range Shooter.! 
    /// 
    /// 
    /// <july_3rd_2022>
    /// make right click attacker. follower <done>
    /// make hold and right click to attack target.!
    /// press hold will just trun towards the target and fire not move
    /// make sure attack clicking makes craft move towards the enemy and attack the same target.
    /// while other guns fire at other targets.!
    /// 
    /// 
    /// <july_5th_2022>
    /// AI Mover
    /// AI mode 1 Hold and shoot
    ///         1.1 stopping distance
    /// AI Mode 2 Charge.!
    /// 
    /// check if bool is AI is better or not
    /// 
    /// mode 2 Tween Script Find Target. Just Charge it.
    /// 
    /// mode 1 
    /// hold means dont move just shoot
    /// 
    /// 
    /// <July_8th_2022>
    /// Animation Start
    /// Watch Lesson <done>
    /// try out make engine effect <done>
    /// 
    /// <july_9th_2022>
    /// Make engine effect <done>
    /// Make Small Explosion Effect.
    /// Make Shrapnel Effect. <done>
    /// make Donut smoke effect. <done>
    /// Make spark effect.
    /// 
    /// <july_10th_2022>
    /// Make Sprites for guns <all_yellow>
    /// Gun 1 Simple Machine gun 3 round burst
    /// Gun 2 simple Machine gun 5 round burst 
    /// Gun 3 Simple machie gun 3 round burst explosing ammo <Yellowish_green>
    /// 
    /// Cannon 1 light flak 0.5 sec // <all_red> <redish_yellow>
    /// Cannon 2 3 round burst 1 sec
    /// cannon 3 2  round 2 sec delay AP round
    /// 
    /// Gun 4 heavy Cannon 2 sec delay
    /// Gun 6 Heavy cannon 2 round burst exploding round Longer range
    /// 
    /// Gun 7 Torpeedo
    ///  
    /// Advance Gun 1 PDC system
    /// Advance Gun 2 Rail Gun 5 sec 
    /// 
    /// <july_11th_2022>
    /// particle Tutorial try all renderers
    /// read all rendereers description and how they work and their niches
    /// 
    /// 
    /// 
    /// <july_12th_2022>
    /// Make bullet prefab for all weapons
    /// Final today.
    /// fill in component data for these.!
    /// Events and delecgates
    /// 
    /// <july_13th_2022>
    /// simple bullet hit sparks
    /// bullet fire flash
    /// 
    /// damage smoke
    /// damage fire
    /// damage sparks
    /// gass venting.
    /// generic sparks.!
    /// 
    /// bullet tumble after hit
    /// bullet rickocher
    /// 
    /// 
    /// <july_15th_2022>
    /// Make impact flash 
    /// make muzzle flash
    /// damage smoke
    /// damage fire
    /// damage vent gas
    /// 
    /// 
    /// <july_16th_2022>
    /// event delegates.!
    /// subscribe 
    /// unsubscribe list.!
    /// 
    /// 
    /// 
    /// 
    /// <stuff_that_might_be_copy_right_issuer>
    /// muzzle flash. in zart folder newscripst
    /// 
    /// <a href="https://www.freepik.com/vectors/gun-fire">Gun fire vector created by macrovector - www.freepik.com</a>
    /// <a href="https://www.freepik.com/vectors/gun-fire">Gun fire vector created by upklyak - www.freepik.com</a>
    /// 







}
