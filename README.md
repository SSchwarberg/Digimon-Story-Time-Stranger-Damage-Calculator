This repository includes a tool to calculate damage values for the Game: "Digimon Story: Time Stranger".

**Web Version:**  
https://sschwarberg.github.io/Digimon-Story-Time-Stranger-Damage-Calculator/

**Most recent Release (Desktop App):**  
**04.11.2025:* Version 1.0.2.0 -* https://github.com/SSchwarberg/Digimon-Story-Time-Stranger-Damage-Calculator/releases/tag/v1.0.2.0  

**Application:**  
<img width="644" height="627" alt="image" src="https://github.com/user-attachments/assets/e5c5e5db-c1c0-47de-abd7-c4596c50758a" />  

This application provides various options to calculate a theoretical damage value with the given options  .
- The Damage calculation matches the real damage values in 90% of my test samples.
- Any of the "wrong" calculations were still within a margin of 5%-10% of the real damage, so it should still be close enough for test purposes.

**Input explanations:**  
- Attacker level: The level of your Digimon.
- Offensive Stat (ATK | INT):
  - Physical Attacks use the ATK stat
  - Magical Attacks use the INT stat
- Defensive Stat (DEF | SPI)
  - The DEF stat is used against Physical attacks.
  - The SPI Stat is used against Magical attacks.
- Skill Power: The power used by your Digimons attack.
- Attack count: How many instances of damage your attack includes.
- DMG Rate - Resistance (%): How much damage does the enemy take from resistances.
  - 50% (0.5 ingame) = The target takes half damage.
  - 200% (2.0 ingame) = The receives double damage.
- Bonus Off. Stat (%): How many bonus stats (in percent) your digimon receives from Buffs.
  - (This is optional, if you already use the buffed value in the "Off. Stat (ATK | INT)" field.
  - Use a negative number for Debuffs (-30%).
- Bonus Def Stat (%): How many bonus stats (in percent) your digimon receives from buffs.
  - (This is optional, if you already use the buffed value in the "Off. Stat (DEF | SPI)" field.
  - Use a negative number for Debuffs (-30%).
- Critical Damage (%): How much critical damage you deal.
  - The base critical extra damage is either 30% or 33%.
  - Increase it to for example to 150, if you have an "+20%" crit chance buff.
- DMG Rate - Equipment (%): This includes "Total damage Modifiers" received from equipments.
  - Leave it at 100% if you don't have an equipment that says something like "deal 1.5x damage.
- Has Damage Boost: Has the Digimon received a buff from either "Spell Boost" or "Acceleration Boost"?
  - These spells give a buff that says "Apply Charge Magic" or "Apply charge Physical".
  - It doubles your next damage output.
