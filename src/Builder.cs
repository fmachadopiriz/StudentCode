//--------------------------------------------------------------------------------
// <copyright file="Builder.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using Proyecto.Common;

namespace Proyecto.StudentsCode
{
    /// <summary>
    /// Una implementación de referencia de <see cref="IBuilder"/> para mostrar su uso.
    /// </summary>
    public class Builder : IBuilder
    {
        private IMainViewAdapter adapter;

        private string firstPageName;

        private string nextPageName;

        private string dropImage;

        private string dragImage;

        private string sourceImage;

        private string labelId;

        private string hideButtonName;

        /// <summary>
        /// Construye una interfaz de usuario interactiva utilizando un <see cref="IMainViewAdapter"/>.
        /// </summary>
        /// <param name="providedAdapter">Un <see cref="IMainViewAdapter"/> que permite construir una interfaz de usuario
        /// interactiva.</param>
        public void Build(IMainViewAdapter providedAdapter)
        {
            string itemId;

            if (providedAdapter !=  null)
            {
                this.adapter = providedAdapter;
            }
            else
            {
                throw new ArgumentNullException(nameof(providedAdapter));
            }

            this.adapter.AfterBuild += this.AfterBuildShowFirstPage;

            this.firstPageName = this.adapter.AddPage();
            this.adapter.ChangeLayout(Layout.ContentSizeFitter);

            float worldWidth = this.adapter.WorldWidth;
            float worldHeight = this.adapter.WorldHeight;
            const float itemWidth = 100f;
            const float itemHeight = 50f;

            // Etiqueta. Posicionada verticalmente en el medio y horizontalmente contra la izquierda.
            this.labelId = this.adapter.CreateLabel((worldWidth / 2 - itemWidth / 2), 0, itemWidth, itemHeight);
            this.adapter.SetFont(labelId, true, true, 24);
            this.adapter.SetText(labelId, "Este es un texto bien largo", true);

            // Image. Posicionada en la esquina inferior derecha.
            //**string destinationCellImageId = this.adapter.CreateDragAndDropDestination(250, 180, 200, 100);
            this.dropImage = this.adapter.CreateImage((worldWidth / 2 - 200 / 2), -(worldHeight / 2 - 100 / 2), 200, 100);
            this.adapter.SetImage(this.dropImage, "Cell.png");

            // Image. Posicionada en la esquina inferior izquierda.
            //**string sourceCellImageId = this.adapter.CreateDragAndDropSource(50, 180, 100, 200);
            this.sourceImage = this.adapter.CreateImage(-(worldWidth / 2 - 100 / 2), -(worldHeight / 2 - 200 / 2), 100, 200);
            this.adapter.SetImage(sourceImage, "Cell.png");

            //**string itemId = this.adapter.CreateDragAndDropItem(0, 0, 100, 100);
            this.dragImage = this.adapter.CreateImage(0, 0, 100, 100);
            this.adapter.SetImage(this.dragImage, "Hammer.png");
            //**this.adapter.AddItemToDragAndDropSource(sourceCellImageId, itemId);
            this.adapter.MakeDraggable(this.dragImage, true);
            this.adapter.OnDrop += this.OnDrop;
            this.adapter.Center(this.dragImage, sourceImage);


            // imageId = this.adapter.CreateImage(40, 100, 100, 100);
            // this.adapter.SetImage(imageId, "pexels-photo-1545505.jpeg");

            string buttonId = this.adapter.CreateButton(150, 100, 100, 100, "#09FF0064", this.GoToNextPage);
            this.adapter.SetImage(buttonId, "BlueButton.png");

            this.adapter.SetDrawingRect(-320, 180, 640, 360);
            this.adapter.OnDrawing += this.Drawing;

            this.hideButtonName = this.adapter.CreateButton(250, 200, 100, 100, "#09FF0064", this.Hide);
            this.adapter.SetText(this.hideButtonName, "Hide");

            this.nextPageName = this.adapter.AddPage(); //this.adapter.AddPage();
            //this.adapter.ChangeLayout(Layout.Grid);

            string gridId = this.adapter.CreateImage(-250, 250, 500, 200);
            this.adapter.ChangeLayout(gridId, Layout.Grid);

            buttonId = this.adapter.CreateButton(0, 0, 100, 100, "#BC2FA864", this.GoToFirstPage);
            this.adapter.SetImage(buttonId, "BlueButton.png");
            this.adapter.SetParent(buttonId, gridId);

            itemId = this.adapter.CreateImage(40, 100, 100, 100);
            this.adapter.SetImage(itemId, "BlueButton.png");
            this.adapter.SetParent(itemId, gridId);

            string inputText = this.adapter.CreateInputField(300, 300, 100, 100, null, this.OnEndEdit);
            this.adapter.SetParent(inputText, gridId);
        }

        public void AfterBuildShowFirstPage()
        {
            this.adapter.ShowPage(this.firstPageName);
        }

        private void GoToFirstPage(string clickedButtonName)
        {
            this.adapter.Debug($"Click on: {clickedButtonName}");
            this.adapter.ShowPage(this.firstPageName);
            this.adapter.PlayAudio("birds.wav");
        }

        private void GoToNextPage(string clickedButtonName)
        {
            this.adapter.Debug($"Click on: {clickedButtonName}");
            this.adapter.ShowPage(this.nextPageName);
            this.adapter.PlayAudio("Birds.wav");
        }

        private void OnTextChanged(string changedInputName, string newText)
        {
            this.adapter.Debug($"Changed: {changedInputName}");
            this.adapter.Debug($"New text: {newText}");
        }

        private void OnEndEdit(string changedInputName, string newText)
        {
            this.adapter.SetText(this.labelId, newText);
            this.adapter.Debug($"End edit: {changedInputName}");
            this.adapter.Debug($"New text: {newText}");
        }

        private void OnDrop(string elementName, float x, float y)
        {
            this.adapter.Debug($"Drop '{elementName}' {x}@{y}");
            if (elementName == this.dragImage && this.adapter.Contains(this.dropImage, x, y))
            {
                // Mueve el elemento arrastrado al destino si se suelta arriba del destino
                this.adapter.Center(elementName, this.dropImage);
            }
            else if (elementName == this.dragImage)
            {
                // Mueve el elemento arrastrado nuevamente al origen en caso contrario
                this.adapter.Center(elementName, this.sourceImage);
            }
        }

        private void Drawing(float x, float y)
        {
            this.adapter.Debug($"Drawing {x}@{y}");
            string imageId = this.adapter.CreateImage(x, y, 10, 10);
            this.adapter.SetImage(imageId, "bluebutton.jpeg");
        }

        private bool hidden = false;

        private void Hide(string clickedButtonName)
        {
            this.hidden = !this.hidden;
            this.adapter.SetActive(this.dropImage, !this.hidden);
        }
    }
}