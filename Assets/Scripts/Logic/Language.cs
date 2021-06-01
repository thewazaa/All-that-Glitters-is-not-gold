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

    public string allTheWorldIsAStage = "All the world's a stage,";
    public string andAlltheMenAndWomenMerelyPlayers = "And all the men and women merely players:";
    public string theyHaveTheirExitsAndTheirEntrances = "They have their exits and their entrances";

    public string oRomeo = "O Romeo,";
    public string romeo = "Romeo";
    public string whereforeArtThou = "wherefore art thou";
    public string romeo2 = "Romeo?";

    public string tCoins = "Coins";
    public string tBombs = "Bombs";
    public string tWalkingBoxes = "Walking boxes";
    public string tBackBoxes = "Back boxes";
    public string tBeware = "Beware the glitter";

    public string bEasy = "Gold is gold, boms are bombs (easy)";
    public string bNormal = "All that glitters is gold (normal)";
    public string bHard = "All that glitters is not gold (hard)";
    public string bVeryHard = "Why so hard? (very hard)";

    public string highScoreFurtherText = "At \"[difficulty]\" the longest time you done is [time] with [gold] coins";
    public string highScoreHighestText = "At \"[difficulty]\" the biggest score you done is [gold] coins in [time]";
    public string highScoreNotText = "You had still not played \"[difficulty]\"";
}

