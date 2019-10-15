﻿//--------------------------------------------------------------------------------
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

        private string labelId;

        /// <summary>
        /// Construye una interfaz de usuario interactiva utilizando un <see cref="IMainViewAdapter"/>.
        /// </summary>
        /// <param name="providedAdapter">Un <see cref="IMainViewAdapter"/> que permite construir una interfaz de usuario
        /// interactiva.</param>
        public void Build(IMainViewAdapter providedAdapter)
        {
            string imageId;

            this.adapter = providedAdapter ?? throw new ArgumentNullException(nameof(providedAdapter));

            this.adapter.AfterBuild += this.AfterBuildShowFirstPage;

            this.firstPageName = this.adapter.AddPage();

            this.adapter.ChangeLayout(Layout.ContentSizeFitter);

            // this.dragImage = this.adapter.CreateImage(-(1024 / 2 - 100 / 2), -(768 / 2 - 100 / 2), 100, 100);
            // this.adapter.SetImage(this.dragImage, "color-splash-trail-76686.jpg");
            this.labelId = this.adapter.CreateLabel(-(1024 / 2 - 100 / 2), -(768 / 2 - 100 / 2), 100, 100);
            this.adapter.MakeDraggable(labelId, true);
            this.adapter.OnDrop += this.OnDrop;
            this.adapter.SetFont(labelId, true, true, 24);

            this.dropImage = this.adapter.CreateImage(1024 / 2 - 100 / 2, 768 / 2 - 100 / 2, 200, 200);
            this.adapter.SetImage(this.dropImage, "pexels-photo-1545505.jpeg");

            string sourceCellImageId = this.adapter.CreateDragAndDropSource(50, 180, 100, 200);
            this.adapter.SetImage(sourceCellImageId, "Cell.png");

            string destinationCellImageId = this.adapter.CreateDragAndDropDestination(250, 180, 200, 100);
            this.adapter.SetImage(destinationCellImageId, "Cell.png");

            string itemId = this.adapter.CreateDragAndDropItem(0, 0, 100, 100);
            this.adapter.SetImage(itemId, "Hammer.png");
            this.adapter.AddItemToDragAndDropSource(sourceCellImageId, itemId);

            // imageId = this.adapter.CreateImage(40, 100, 100, 100);
            // this.adapter.SetImage(imageId, "pexels-photo-1545505.jpeg");

            string buttonId = this.adapter.CreateButton(150, 100, 100, 100, "#09FF0064", this.GoToNextPage);
            this.adapter.SetImage(buttonId, "BlueButton.png");

            this.adapter.SetDrawingRect(-320, 180, 640, 360);
            this.adapter.OnDrawing += this.Drawing;

            this.nextPageName = this.adapter.AddPage(); //this.adapter.AddPage();
            this.adapter.ChangeLayout(Layout.Grid);

            buttonId = this.adapter.CreateButton(100, 100, 100, 100, "#BC2FA864", this.GoToFirstPage);
            this.adapter.SetImage(buttonId, "BlueButton.png");
            imageId = this.adapter.CreateImage(40, 100, 100, 100);
            this.adapter.SetImage(imageId, "pexels-photo-1545505.jpeg");

            string inputText = this.adapter.CreateInputField(300, 300, 100, 100, null, this.OnEndEdit);
        }

        public void AfterBuildShowFirstPage()
        {
            this.adapter.ShowPage(this.firstPageName);
        }

        private void GoToFirstPage(string clickedButtonName)
        {
            this.adapter.Debug($"Click on: {clickedButtonName}");
            this.adapter.ShowPage(this.firstPageName);
            this.adapter.PlayAudio("Speech On.wav");
        }

        private void GoToNextPage(string clickedButtonName)
        {
            this.adapter.Debug($"Click on: {clickedButtonName}");
            this.adapter.ShowPage(this.nextPageName);
            this.adapter.PlayAudio("Speech Off.wav");
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
            this.adapter.SetParentAndCenter(elementName, this.dropImage);
        }

        private void Drawing(float x, float y)
        {
            string imageId = this.adapter.CreateImage(x, y, 10, 10);
            this.adapter.SetImage(imageId, "pexels-photo-1545505.jpeg");
        }
    }
}
