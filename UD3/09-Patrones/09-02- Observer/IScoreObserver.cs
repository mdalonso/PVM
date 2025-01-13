

//La implementaci�n de un patr�n Observer requiere la definici�n de una interfaz
//que declara el m�todo que ejecutar�n los observadores cuando sean notificados
//de los cambios en la puntuaci�n
public interface IScoreObserver
{
    void OnScoreChanged(int newScore);
}
