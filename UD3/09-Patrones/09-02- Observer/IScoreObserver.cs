

//La implementación de un patrón Observer requiere la definición de una interfaz
//que declara el método que ejecutarán los observadores cuando sean notificados
//de los cambios en la puntuación
public interface IScoreObserver
{
    void OnScoreChanged(int newScore);
}
