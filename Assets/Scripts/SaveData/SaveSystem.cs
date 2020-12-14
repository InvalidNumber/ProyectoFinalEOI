using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; // Porque vamos a leer y escribir archivos del sistema
using System.Runtime.Serialization.Formatters.Binary; // Porque queremos poder convertirlo en un string de bytes(binario)

public class SaveSystem
{
    #region Player
    public static void SavePlayer(GameObject player, GameObject camera)
    {
        //* Donde guardo la información *//
        // Obtengo la ruta donde puedo guardar ficheros de forma persistente (será diferente en cada platform)
        // y le añado el nombre del fichero donde voy a guardar los datos.
        string path = Application.persistentDataPath + "/player.data";

        // Creo una variable que me permite manejar el archivo player.data. A la vez lo creo. Cada vez que pulse en Salvar Partida
        // crearé un archivo nuevo con nombre player.data y sobreescribirá el anterior (debido a que FileMode está en modo Create)
        // docs.microsoft.com/es-es/dotnet/api/system.io.filemode?view=net-5.0
        FileStream stream = new FileStream(path, FileMode.Create);

        //* Información a guardar *//
        // Creando una nueva instancia de la clase PlayerData con los datos que quiero guardar. Esto permite tener los datos del juego
        // en un formato serializable, en un formato que permita convertilos a bytes.
        PlayerData data = new PlayerData(player, camera);

        //* Serialización  *//
        // Creo una variable de tipo BinaryFormatter que me a permitir convertir los datos de data (PlayerData) en datos binarios y 
        // almacenarlos en un archivo.
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        // Ejecuta la serialiazción (conversión a una cadena de bytes) y los guarda en el archivo player.data
        binaryFormatter.Serialize(stream, data);

        // Cierra el archivo player.data
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {

        //* De donde obtengo la información/datos que quiero recuperar *//
        string path = Application.persistentDataPath + "/player.data";

        // Si el archivo player.data existe en la ruta Application.persistentDataPath
        if (File.Exists(path))
        {
            // Abro el archivo player.data en modo lectura 
            FileStream fileStream = new FileStream(path, FileMode.Open);

            // Creo una variable de tipo BinaryFormatter para desrializar el contenido del archivo player.data, es decir, 
            // convertir una cadena de bytes en tipos y datos que manejar dentro de mis clases y scripts c#
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            // Obtengo los datos del archivo player.data en el formato apropiado para poder recuperar los datos guardados.
            PlayerData data = binaryFormatter.Deserialize(fileStream) as PlayerData;

            // Cerramos el archivo player.data
            fileStream.Close();

            // Devuelvo los datos recuperados para su correspondiente gestión.
            return data;
        }
        // Si el archivo player.data NO existe en la ruta Application.persistentDataPath
        else
        {
            Debug.Log("SaveSystem::LoadPlayer::Path ERROR " + path);
            // Al no existir el archivo no podemos recuperar datos, devolvemos nulo.
            return null;
        }
    }
    #endregion

    #region Enemies
    public static void SaveEnemies(GameObject[] enemies)
    {
        string path = Application.persistentDataPath + "/enemies.data";

        FileStream stream = new FileStream(path, FileMode.Create);

        EnemiesData data = new EnemiesData(enemies);

        BinaryFormatter binaryFormatter = new BinaryFormatter();

        // Ejecuta la serialiazción (conversión a una cadena de bytes) y los guarda en el archivo player.data
        binaryFormatter.Serialize(stream, data);

        // Cierra el archivo player.data
        stream.Close();
    }

    public static EnemiesData LoadEnemies()
    {

        //* De donde obtengo la información/datos que quiero recuperar *//
        string path = Application.persistentDataPath + "/enemies.data";

        // Si el archivo enemies.data existe en la ruta Application.persistentDataPath
        if (File.Exists(path))
        {
            // Abro el archivo enemies.data en modo lectura 
            FileStream fileStream = new FileStream(path, FileMode.Open);

            // Creo una variable de tipo BinaryFormatter para desrializar el contenido del archivo enemies.data, es decir, 
            // convertir una cadena de bytes en tipos y datos que manejar dentro de mis clases y scripts c#
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            // Obtengo los datos del archivo enemies.data en el formato apropiado para poder recuperar los datos guardados.
            EnemiesData data = binaryFormatter.Deserialize(fileStream) as EnemiesData;

            // Cerramos el archivo enemies.data
            fileStream.Close();

            // Devuelvo los datos recuperados para su correspondiente gestión.
            return data;
        }
        // Si el archivo enemies.data NO existe en la ruta Application.persistentDataPath
        else
        {

            // Al no existir el archivo no podemos recuperar datos, devolvemos nulo.
            return null;
        }
    }
    #endregion
}