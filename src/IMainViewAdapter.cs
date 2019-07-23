//----------------------------------------------------------------------------------
// <copyright file="IMainViewAdapter.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//----------------------------------------------------------------------------------

namespace Proyecto.StudentsCode
{
    /// <summary>
    /// Provee operaciones para manipular una vista.
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
        /// <param name="color">El color del botón a crear.</param>
        /// <returns>El botón recién creado.</returns>
        IButton CreateButton(int x, int y, int width, int height, string color);


        IDragAndDropCell CreateDragAndDropCell(int x, int y, int width, int height);

        IDragAndDropItem CreateDragAndDropItem(int x, int y, int width, int height);
        
        /// <summary>
        /// Imprime un mensaje en la consola de Unity.
        /// </summary>
        /// <param name="message">El mensaje a imprimir.</param>
        void Debug(string message);
    }
}