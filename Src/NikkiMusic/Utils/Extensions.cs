using System;
using Godot;

namespace NikkiMusic.Utils
{
	public static class Extensions
	{
		/// <summary>
		/// Método genérico para obtener el siguiente valor de un Enum cualquiera.
		/// </summary>
		/// <param name="src">representa el tipo del Enum en cuestión</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>Siguiente valor si existe, sino, el primero</returns>
		public static T Next<T>(this T src) where T : Enum
		{
			var array = (T[]) Enum.GetValues(src.GetType());
			int index = Array.IndexOf<T>(array, src) + 1;
			return array.Length == index ? array[0] : array[index];
		}
		
		/// <summary>
		/// Extension para el file handler de Godot que intenta abrir un archivo
		/// con los parámetros entregados.
		/// </summary>
		/// <param name="fileHandler">referencia al objeto que extiende</param>
		/// <param name="result">resultado de la operación. Se obtiene desde el llamado usando out</param>
		/// <param name="path">dirección al archivo que se pretende abrir</param>
		/// <param name="flags">modo de operación (lectura, escritura. ambas)</param>
		/// <returns>Verdadero si fue la operación fue exitosa</returns>
		public static bool TryOpenFile(this File fileHandler, out Error result, string path, File.ModeFlags flags)
		{
			result = fileHandler.Open(path, flags);
			return result == Error.Ok;
		}
		
		/// <summary>
		/// Extiende object para obtener una string legible que describa el objeto.
		/// Usada para entregar contexto a los logs.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static string GetContextName(this object obj)
		{
			return obj is Node node ? $"NODE: {node.Name}" : $"OBJECT: {obj}";
		}
	}
}