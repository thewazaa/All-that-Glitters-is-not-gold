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
}
