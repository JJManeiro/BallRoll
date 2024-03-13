# Ball Roll: Un juego de parkour basico en Unity.
## Cómo ganar?
Una vez inicias el juego tendrás un enemigo que te persigue al inicio del mapa.
Si chocas con el volverás al punto donde iniciaste.
Esquivalo y coge las 30 monedas que hay en las diversas plataformas para ganar el juego!
## Que hace cada script aquí?
Cada script tiene su utilidad.

### Anima.cs
Este script se encarga de las animaciones de reposo y salto de la bolita.
También te indica si el enemigo está cerca tuyo o no.
### CameraController.cs
Mueve la cámara del jugador.
### CameraControllerCopy.cs
Una toma alternativa del código a la hora de mover la cámara del jugador.
### Foe.cs
Se encarga de la creación de un enemigo que te persigue
y si te toca, vuelves al punto del mapa.
### Movement.cs
Hace que el jugador se mueva.
### PlayerController.cs
Se encarga de la ceración del jugador, de sus movimientos y de su condición de victoria.
### Rotator.cs
Un simple script que hace que las monedas giren para darle un toque más llamativo.