//--------------------------------------------------------------------------------
// <copyright file="Layout.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

namespace Proyecto.StudentsCode
{
    /// <summary>
    /// Los diferentes tipos de layout soportados.
    /// </summary>
    public enum Layout
    {
        /// <summary>
        /// Ver <see cref="GridLayout"/>.
        /// </summary>
        Grid = 0,

        /// <summary>
        /// Ver <see cref="GridLayout"/>.
        /// </summary>
        Vertical = 1,

        /// <summary>
        /// Ver <see cref="GridLayout"/>.
        /// </summary>
        Horizontal = 2,

        /// <summary>
        /// Ver <see cref="Canvas"/>.
        /// </summary>
        ContentSizeFitter = 3,
    }
}
