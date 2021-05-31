using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language : MonoBehaviour
{
    public string languageName = "English";

    public string bStartGame = "Start game";
    public string bConfig = "Config";
    public string bQuit = "Quit";

    public string bMusic = "Music";
    public string bSound = "Sound";
    public string bAbout = "About";

    public string bEnglish = "English";
    public string bSpanish = "Spanish";
    public string bCatalonian = "Catalonian";

    public string bBack = "Back";

    public string tTime = "Time";
    public string tGold = "Gold";

    [Multiline(8)]
    public string tAbout = @"Game made by Josep M. Pons

Graphics: Josep M.Pons

Code: Josep M. Pons

Music

The Intruder - By Rubén Carretón

Sounds

Click1.wav https://freesound.org/people/EdgardEdition/sounds/113051/";

    public string allThatGlittersIsNotGold = "All That Glitters Is Not Gold";

    public string tCoins = "Coins";
    public string tBombs = "Bombs";
    public string tWalkingBoxes = "Walking boxes";
    public string tBackBoxes = "Back boxes";
    public string tBeware = "Beware the glitter";

    public string bEasy = "Gold is gold, boms are bombs (easy)";
    public string bNormal = "All that glitters is gold (normal)";
    public string bHard = "All that glitters is not gold (hard)";
    public string bVeryHard = "Why so hard? (very hard)";
}
