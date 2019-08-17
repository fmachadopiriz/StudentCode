//--------------------------------------------------------------------------------
// <copyright file="IBuilder.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

namespace Proyecto.StudentsCode
{
    /// <summary>
    /// Las clases que implementan esta interfaz son capaces de construir una interfaz de usuario interactiva
    /// utilizando un <see cref="IMainViewAdapter"/>.
    /// <remarks>
    /// Esta interfaz no puede ser modificada pero debe ser implementada en la clase <see cref="Builder"/>,
    /// </remarks>
    /// </summary>
    public interface IBuilder
    {
        /// <summary>
        /// Construye una interfaz de usuario interactiva utilizando un <see cref="IMainViewAdapter"/>.
        /// </summary>
        /// <param name="adapter">Un <see cref="IMainViewAdapter"/> que permite construir una interfaz de usuario
        /// interactiva.</param>
        void Build(IMainViewAdapter adapter);
    }
}
