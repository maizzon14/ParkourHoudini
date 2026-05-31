### PARKOUR HOUDINI

## Instrucciones
Las instrucciones para jugar a nuestro juego son sencillas. El objetivo es superar todos los puzzles y obstáculos que se te presenten hasta llegar a la meta. 
Para mover al Player se utiliza “WASD”, para saltar la tecla de Espacio, para  interactuar con objetos la tecla “E” y cambiar el jugador de tamaño utilizaremos las teclas 1 ,2 y 3 . 

## Proceso
El proceso para llegar a este resultado de nuestro proyecto ha sido centrado sobre todo en el game design del nivel. 
Hemos implementado sistemas de física como los Joints, Rigidbody, Colliders/Trigger, Physics Material, entre otras. Combinándolas formando un juego de puzzles donde el jugador tendrá que pensar cómo resolverlos para superar el nivel.

## Decisiones
Durante el desarrollo del juego se han tomado diferentes decisiones. 
Por ejemplo, estuvimos barajando la idea de simplemente hacer dos tipos de personaje, pero decidimos finalmente hacer tres (Medida pequeña, mediana y grande), de esta forma hacemos que el juego tome una forma más dinámica. 
Por otra parte, a la hora de plantear las clases de puzzles que íbamos a implementar, decidimos eliminar algunos ya que nos llevarían más tiempo del que disponíamos. Por ejemplo, una de las mecánicas que fue descartada es un puzzle dónde establecimos que una explosión destruyese diferentes tipos de puertas. 

## Juego Propuesto
Finalmente, nuestro juego contiene mecánicas en las que predomina la física. 
Tenemos por una parte: 
-Puentes rompibles					
-Suelos con fricción.
-Mover cajas (pesadas)
-Botones
-Rampa con puerta 
-Plataformas con niveles de salto diferentes.

Y por otra parte, combinamos todas estas mecánicas para formar nuevas y así que el juego adopte más dinamismo. 
-Mueves cajas con el personaje pesado para poder utilizarlas con el ligero.
-Te deslizas con el pequeño en la rampa y en mitad te cambias al grande para poder romper la puerta. 
-Plataformas que se rompan según el peso del personaje.
-Plataformas que suben o bajan dependiendo el peso.
