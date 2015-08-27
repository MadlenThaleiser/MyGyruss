# MyGyruss
Programmieraufgabe für Exozet

Hallo!

Dies ist meine Lösung für die Programmieraufgabe von Exozet Berlin GmbH. MyGyruss wurde in einer 2D-Optik mit 
der 3D-Phyisk von Unity erstellt (eine 2D-Umsetzung kann analog durch das Verwenden von Sprites statt Gameobjekten
wie Cube oder Capsule umgesetzt werden).

##Steuerung

Es stehen folgende Steuerungsmöglichkeiten zur Verfügung:

- Bewegung nach links:
              linke Pfeiltaste drücken
              Klick mit der linken Maustaste und Bewegung der Maus nach links
- Bewegung nach rechts:
              recht Pfeiltaste drücken
              Klick mit der linken Maustaste und Bewegung der Maus nach rechts
- feuern:
              Spacetaste drücken
              Klick mit der linken Maustaste ohne Bewegung der Maus
              

##Status der Aufgaben

- Verarbeitung der Spieler/User-Eingabe mittels UGB
              umgesetzt
                + innerhalb MyGruss.cs werden die Keymappings für Spacetaste, linke und rechte Pfeiltaste initialisiert
                  und hinzugefügt zu GameInput
                + innerhalb SpaceShip.cs in der Methode Input() werden die Touchbewegungen abgefangen und ausgewertet
                
- Generation von Objekten
              teilweise umgesetzt
                - keine Berücksichtigung von UGBObjectPool
                - Feinde werden nicht auf ein Kreis erzeugt und bewegen sich dementsprechend nicht auf einer Kreislinie
                
- Highscore
              teilweise umgesetzt
                - beste Highscore wird mit Spielernamen gespeichert und angezeigt
                
##Probleme

- nach Eintragen in Highscore, wird Level neugeladen, jedoch kann nicht mehr auf das SpaceShip (den Spielercharakter) 
  zu gegriffen werden (Missing Reference Exception)
- Klassen GameComponent und UGBObjectPool wurden nicht genutzt, da Verwendungzweck nicht ganz klar (UGBObjectPool 
  wahrscheinlich für das Spawnen der Gegner)


Vielen Dank fürs Lesen :)
