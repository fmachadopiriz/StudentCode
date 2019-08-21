//--------------------------------------------------------------------------------
// <copyright file="Builder.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

namespace Proyecto.StudentsCode
{
    /// <summary>
    /// Una implementación de referencia de <see cref="IBuilder"/> para mostrar su uso.
    /// </summary>
    public class Builder : IBuilder
    {
        private IMainViewAdapter Adapter;

        /// <summary>
        /// Construye una interfaz de usuario interactiva utilizando un <see cref="IMainViewAdapter"/>.
        /// </summary>
        /// <param name="adapter">Un <see cref="IMainViewAdapter"/> que permite construir una interfaz de usuario
        /// interactiva.</param>
        public void Build(IMainViewAdapter adapter)
        {
            this.Adapter = adapter;

            // Si se hace prolijo acá se usan visitor/builder; lo hago hardcoded por brevedad.
            this.Adapter.ChangeLayout(Layout.ContentSizeFitter);

            string sourceCellImageId = adapter.CreateDragAndDropSource(50, 180, 100, 200);
            adapter.SetImage(sourceCellImageId, "Images\\Cell");

            string destinationCellImageId = adapter.CreateDragAndDropDestination(250, 180, 200, 100);
            adapter.SetImage(destinationCellImageId, "Images\\Cell");

            string itemId = adapter.CreateDragAndDropItem(0, 0, 100, 100);
            adapter.SetImage(itemId, "Images\\Hammer");
            adapter.AddItemToDragAndDropSource(sourceCellImageId, itemId);

            // adapter.MakeDragAndDropItem(itemId);
            
            // string destinationId = adapter.CreateDragAndDropDestination(400, -180, 100, 100);
            
            // adapter.ChangeParent(itemId, sourceId);
            // string imageId = adapter.CreateImage(-400, -180, 100, 100);
            // adapter.SetImage(imageId, "Images\\BlueButton");

        }
        
        internal void OnClick()
        {
            this.Adapter.Debug($"Button clicked!");
        }
    }
}
