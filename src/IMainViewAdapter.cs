//----------------------------------------------------------------------------------
// <copyright file="IMainViewAdapter.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//----------------------------------------------------------------------------------

using System;

namespace Proyecto.StudentsCode
{
    /// <summary>
    /// Provee operaciones para crear una interfaz de usuario interactiva en Unity. Un objeto que implementa esta
    /// interfaz es utilizado en <see cref="IBuilder.Build(IMainViewAdapter)"/> para construir esa interfaz de usuario.
    /// </summary>
    public interface IMainViewAdapter
    {
        /// <summary>
        /// Cambia el layout de la vista.
        /// </summary>
        /// <param name="layout">El nuevo layout.</param>
        void ChangeLayout(Layout layout);

        /// <summary>
        /// Crea un nuevo botón.
        /// </summary>
        /// <param name="x">La posición en el eje horizontal en pixels.</param>
        /// <param name="y">La posición en el eje vertical en pixels.</param>
        /// <param name="width">El ancho en pixels.</param>
        /// <param name="height">El alto en pixels.</param>
        /// <param name="color">El color del botón a crear.</param>
        /// <param name="onClick">El método a ejecutar cuando se hace click en el botón.</param>
        /// <returns>El nombre del botón  creado.</returns>
        string CreateButton(int x, int y, int width, int height, string color, Action onClick);

        /// <summary>
        /// Crea una nueva celda origen de operaciones de arrastrar y soltar. Esta celda debe contener una imagen con
        /// el elemento a arrastrar.
        /// </summary>
        /// <param name="x">La posición en el eje horizontal en pixels.</param>
        /// <param name="y">La posición en el eje vertical en pixels.</param>
        /// <param name="width">El ancho en pixels.</param>
        /// <param name="height">El alto en pixels.</param>
        /// <returns>El nombre de la celda creada.</returns>
        string CreateDragAndDropSource(int x, int y, int width, int height);
        
        /// <summary>
        /// Crea una nueva celda destino de operaciones de arrastrar y soltar.
        /// </summary>
        /// <param name="x">La posición en el eje horizontal en pixels.</param>
        /// <param name="y">La posición en el eje vertical en pixels.</param>
        /// <param name="width">El ancho en pixels.</param>
        /// <param name="height">El alto en pixels.</param>
        /// <returns>El nombre de la celda creada.</returns>
        string CreateDragAndDropDestination(int x, int y, int width, int height);

         /// <summary>
        /// Crea una nueva imagen que se puede arrastrar y soltar.
        /// </summary>
        /// <param name="x">La posición en el eje horizontal en pixels.</param>
        /// <param name="y">La posición en el eje vertical en pixels.</param>
        /// <param name="width">El ancho en pixels.</param>
        /// <param name="height">El alto en pixels.</param>
        /// <returns>El nombre de la imagen creada.</returns>        
        string CreateDragAndDropItem(int x, int y, int width, int height);

         /// <summary>
        /// Crea una nueva imagen a partir de un recurso.
        /// </summary>
        /// <param name="x">La posición en el eje horizontal en pixels.</param>
        /// <param name="y">La posición en el eje vertical en pixels.</param>
        /// <param name="width">El ancho en pixels.</param>
        /// <param name="height">El alto en pixels.</param>
        /// <param name="resourceName">El nombre del recurso para la imagen.</param>
        /// <returns>El nombre de la imagen creada.</returns>     
        string CreateImage(int x, int y, int width, int height, string resourceName);
        
        /// <summary>
        /// Imprime un mensaje en la consola de Unity.
        /// </summary>
        /// <param name="message">El mensaje a imprimir.</param>
        void Debug(string message);

        /// <summary>
        /// Cambia el contenedor de un elemento a un nuevo contenedor.
        /// </summary>
        /// <param name="childName">El nombre del elemento a mover.</param>
        /// <param name="parentName">El nombre del nuevo elemento contenedor.</param>
        void ChangeParent(string childName, string parentName);

        /// <summary>
        /// Asigna una nueva imagen a un elemento. El elemento debe haber sido creado con <see cref="CreateButton"/> o
        /// <see cref="CreateImage"/>.
        /// </summary>
        /// <param name="elementName">El nombre del elemento cuya imagen cambiar.</param>
        /// <param name="resourceName">El nombre del recurso para la imagen.</param>
        void SetImage(string elementName, string resourceName);
    }
}