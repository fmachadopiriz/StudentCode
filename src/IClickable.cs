//------------------------------------------------------------------------------
// <copyright file="IClickable.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

namespace Proyecto.StudentsCode
{
    public delegate void OnClick();

    /// <summary>
    /// Los objetos de este tipo pueden ser cliqueados.
    /// </summary>
    public interface IClickable
    {
        /// <summary>
        /// Invocado cuando se hace clic en el elemento.
        /// </summary>
        OnClick OnClick { get; set; }
    }
}
