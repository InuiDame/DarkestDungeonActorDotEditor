# DarkestDungeonActorDotEditor
This window program is suitable for quickly editing ActorDot

If you are modifying an existing AD, click "Open JSON"; if not, simply click "Add AD Count" to start writing.
The AD ID and hero/monster name are required (as they affect the generated blank animation), and the update type must be selected from one of the following:

after_turn_attack: Attack without killing

after_turn_attack_kill: Attack with killing

after_turn_friendly: Friendly skill

If you write an AD of type after_turn_attack with ID 123, the next AD, even if you switch types, cannot use ID 123. You must change the ID, for example, to 123_2.

Incomplete-Complete Type AD
The completion probability of the final step of the AD must be 1 (100%); otherwise, the AD cannot be closed. Before completion, the AD will trigger the incomplete effects, meaning that all rows before the final one should have effects under the incomplete section.

Probability-Based Completion Type AD
The completion probability of the AD is not 1 until the final step, and it becomes 1 at the last step. The original Countess's Egg is an example of a probability-based completion type AD.

After creating a new AD, click "Generate" and check the output in the ADskeloutput folder. The JSON and animation files are stored separately.
If you are modifying an existing AD, simply click "Save JSON."

Do not delete the sampleADskel folder or any of its contents!!!
