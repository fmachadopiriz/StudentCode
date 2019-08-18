//--------------------------------------------------------------------------------
// <copyright file="Layout.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System.Diagnostics;

namespace Proyecto.StudentsCode
{
    /// <summary>
    /// Una implementación de referencia de <see cref="IBuilder"/> para mostrar su uso.
    /// </summary>
    public class Builder : IBuilder
    {
        private IMainViewAdapter _adapter;

        /// <summary>
        /// Construye una interfaz de usuario interactiva utilizando un <see cref="IMainViewAdapter"/>.
        /// </summary>
        /// <param name="adapter">Un <see cref="IMainViewAdapter"/> que permite construir una interfaz de usuario
        /// interactiva.</param>
        public void Build(IMainViewAdapter adapter)
        {
            this._adapter = adapter;

            // Si se hace prolijo acá se usan visitor/builder; lo hago hardcoded por brevedad.
            adapter.ChangeLayout(Layout.ContentSizeFitter);
            string buttonId = adapter.CreateButton(400, 180, 160, 50, "#FFFFFF", this.OnClick);
            adapter.SetImage(buttonId, "Images\\BlueButton");
            string sourceId = adapter.CreateDragAndDropSource(-400, 180, 100, 100);
            string destinationId = adapter.CreateDragAndDropDestination(400, -180, 100, 100);
            string itemId = adapter.CreateDragAndDropItem(0, 0, 100, 100);
            adapter.ChangeParent(itemId, sourceId);
            string imageId = adapter.CreateImage(-400, -180, 100, 100, "Images\\BlueButton");
        }
        
        internal void OnClick()
        {
            this._adapter.Debug($"Button clicked!");
        }
    }
}
