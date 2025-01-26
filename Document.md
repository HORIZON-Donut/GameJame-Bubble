THE DOCUMENTATION FOR PLAYER, INVENTORY, WEAPON, AND BULLET USAGE
-----------------------------------------------------------------

Player:
======
	Attach with bunch of important variable and function to interact with player charector
 - Variable list:
 	>> move speed: default = 5
		Use to set player normal walkspeed

	>> sprit speed: default 10
		Use to set player running speed

	>> horizontal speed: default 8
		Use to set horizontal rotation speed
	
	>> vertical speed: default 4
		Use to set vertical rotation speed

	>> min - max Angle : default -60 to 80
		Use to set max angle of vertical rotation
	
	>> Health: default 1000
		Use to set player health

		This is player health. If it ran out, player death
		... May have attack type that ignore all defend and do direct damage to health bar
		... And may have ont hit attack
	
	>> Armor: default 500
		Use to set player Armor

		This thing reduce damage player take from get hit but did not completely prevent all damage
		... May have attack type to ignore this type of defend
	
	>> Shield: default 250
		Use to set player shield

		This thing keep damage from player
		If shield still work, nothing can hurt player
		... May have attack type to ignore this type of defend
	
	>> Stamina: default 500
		This use to set player stamina

		Stamina is important. it use to running (Except, you play no running challenge)
		This thing will re-generate automatically
	
	>> max Variable series
	 - Include: health, armor, shield, and stamina
		 This type of variable use to set max value for each variable mention.

	>> Tier Variable series
	 - Include: Armor, and Shield
	 	This type of variable use to define tier of that variable

		Will be use as multiplier when use those stuff.
		This make higher tier, higher quality
	
	>> stamina daley: default 20
		This use to set delay (How many loop pass) before re-generate one amount of stamina
	
	>> hold point
		This is player hold point use to set where weapon will be place
	
	>> And there are other important variable but was define as private variable
	 - rotX
	 - speed
	 - counter
	 - head
	 - rb
	 - inventory
	
 - Function List

 This is public function that can be access to interact with player
 	
	>> TakeDamage(float amount)		//May add "int type" later to define which attack type taken and define how to interact with player stat
		
		Use case:
			use in attack object by check with collision
			Example:

			|_ in attack object script

			private void OnCollisionEnter(Collision collision)
			{
				switch(collision.gameObject.tag)
				{
					case "Player":
						Player player = collision.gameObject.GetComponent<Player>();
						player.TakeDamage(ObjectDamage);	// use player.TakeDamage(ObjectDamage, DamageType) when attack type defined

						.
						.
						.
			____________

		What it does?
			It will take damage amount and make player weaker
			In this case, damage type haven't define yet, so

			if shield amount > 0, prevent all damage from player and reduce damage taken to shield. shield reduce for damage devide by product of shield tier and 4

			if shield has broken but armor stood still. It will reduce player damage taken. Which armor take half of full damage and player take only half 4 of full damage

			if all shield and armor gone, player take full damage
	>> Return value series
	 - Include: GetHoldPoint, GetHealth, GetArmor, GetShield, and GetStamina
	 	
		These function use to return important value from variable and take no argument.

		The function name already explain what it return

Weapon
======

This is script use to attach as component in weapon prefab
After attached, leave isHolding as non-check to prevent annormally situation (Some ghost fire weapon)
the weapon slot use to attach a ScriptableObject 'WeaponItem'
and the Shoot Point use to attach a game object to make spaw point for bullet

This has no avilable public function

Weapon Item
===========

This is ScriptableObject use to define weapon property
Can access this by create new object and choose WeaponItem from the list

The important property contain in this object
 - Weapon name
 	This use to define weapon name. Pick any name you wish

 - bullet number
 	This is number of avilable bullet for weapon

 - start bullet
 	This is amount of bullet have when first pick up this weapon

 - max bullet
 	This is max amount of bullet for the weapon

 - damage
 	This is weapon damage. This will be assign to bullet object to transfer this value to target object through collision function

 - fire rate
 	This is fire rate of the weapon. I don't know it's mechanism, so ask that one who wearing glass. He responsible on this variable

 - bullet speed
 	This is bullet speed of this weapon. Also, i don't know this one. ask him

 - bullet type
 	This is bullet type. take as intiger.
	This tell inventory which bullet pick up is for which weapon. if value is equal, that bullet is belong to that weapon

 - damage type
 	This is damage type. it will be assign to bullet to carry to target object. also take as intiger.

	And this is object variable. The bullet var use to store bullet prefab that contain bullet script as component. Also, body is weapon prefab.
	Note: The weapon compatible to these work flow must follow this structure
		
		root Object --> This contain weapon script and collider
		|__sub object 1
		|__sub object 2
		|
		.
		.
		.
		|__sub object n

 - game object: bullet
 - game object body

Bullet
=====

This script must attach as component to bullet prefab
After attached, leave weapon slot empty.
It will be assign on fly

This script provide function to take damage value and damage type

Function List
 - DamageOnHit()
 	Use to get damage of the bullet
	return value as float number
 - DamageType()
 	use to get type of bullet
	return as intiger number

Inventory
========

This script have to attach as component to player prefab
All avilable public function of this script already be call from Player script

This script 'Inventory' will take responsibility on manage weapon of player
When attach, it provide slot for pre-store weapon. input weapon item object to pre load them.

This script also handle take like Swap weapon, fill ammunation on each weapon, and make player able to hold and pick up weapon on flow.

Camera Script (Cursor control mode)
===================================
This script attach to main camera of player
It provide function to handle cursor on screen

Function Avilable:
------------------
 - enableCursor()
 	Make cursor visible and usable
 - disableCursor()
 	Make cursor dissapear

In real usage, Update() function should be remove

