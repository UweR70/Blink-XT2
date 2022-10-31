namespace Info
{
    internal class Oracle_Version_ReadMe
    {
        /* Hier 
         * https://github.com/UweR70/Blink-XT2/wiki/Tutorial:-How-to-decompile-an-apk%3F
         * beschreibe ich, was getan werden muss um an die REST-API calls der apk zu bekommen.
         * 
         * Das funktionierte auch Ende Oktober 2022 fehlerfrei. 
         * Es trat jedoch das Problem auf, dass JAVA auf dem neuen Rechner (AMD 5700G, ...) noch nicht installiert war.
         * 
         * Grundlage der JAVA Installation ist stets eine "JAVA SE" Version, siehe
         * https://www.oracle.com/java/technologies/downloads/archive/#JavaSE
         * 
         * Aber das in meinem Tutorial verwendete "dex2jar" Programm benötigt offensichtlich eine spezielle Version; 
         * irgendeine (neuere) führt zu Problemen. 
         * Die im Tutorial genannte Version "jdk1.8.0_161" funktionierte auch Ende Oktober 2022 noch.
         * Diese Version konnte aber nur nach Erstellung eines Oracle Accounts herutergeladen werden.
         * Ich habe daher einen FAKE Oracle Account angelegt.
         * Der Account wird aber nur aktiviert, wenn der Button in der von Oracle gesendeten Bestätigungs-email angeklickt wird ...
         * Für die FAKE email Addresse habe ich dies verwendet:
         * https://muellmail.com/#/BegeisterndLiebenswerterGepard@tonne.to
         * 
         * Wo fand ich die korrekte Version?
         * a) https://www.oracle.com/java/technologies/downloads/archive/#JavaSE
         *    -> "Java SE 8 (8u202 and erlier)"
         *    führt zu:
         * b) https://www.oracle.com/java/technologies/javase/javase8-archive-downloads.html
         *    dort nach "161" suchen,
         *    dort "Java SE Development Kit 8u161" 
         *    dort "Windows x64" -> "206.51 MB" -> "jdk-8u161-windows-x64.exe"
         *    wählen!
         *    
         *    WICHTIG: 
         *    Es muss das "... Development Kit ..." sein, also nicht die 
         *      "Java SE Runtime Environment 8u161" 
         *    noch die 
         *      "Server JRE (Java SE Runtime Environment) 8u161"
         *    Variante!
         * 
         * Im cmd ohne Adminrechte feuern:
         *  java -version
         * 
         * 
         * https://stackoverflow.com/questions/9170832/list-of-java-class-file-format-major-version-numbers
         *  
         *  
         * Es war schwierig zu verstehen welche Version "1.8.0_161" ist.
         * Der folgende Link zeigt es auf:         *  
         * https://www.oracle.com/java/technologies/javase/8u161-relnotes.html
         *   
         *          JRE Family Version 	JRE Security Baseline (Full Version String)
         *              8                   1.8.0_161-b12
         *              7                   1.7.0_171-b11
         *              6                   1.6.0_181-b10
         *              
         * Die von mir gesuchte Version 
         *  "1.8.0_161" 
         * gehört also zur "8"ter ("JRE Family") Version .
         * -> Also wird "8u161" benötigt.
         * -> Also "Java SE Development Kit 8u161" ...
         */
    }
}
