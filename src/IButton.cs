//------------------------------------------------------------------------------
// <copyright file="IButton.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

namespace Proyecto.StudentsCode
{
    /// <summary>
    /// Un botón. Tiene la responsabilidad de conocer el color del botón.
    /// </summary>
    public interface IButton : IUIElement
    {
        /// <summary>
        /// Obtiene y asigna el color del botón en formato RBG hexadecimal (#RRGGBB).
        /// </summary>
        string Color { get; set; }
    }
}
