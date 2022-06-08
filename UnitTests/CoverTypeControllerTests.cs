using NUnit.Framework;
using Moq;
using eBooks.DataAccess.Repository.IRepository;
using eBooks.Areas.Admin.Controllers;
using eBooks.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace UnitTests
{
    public class CoverTypeControllerTests
    {
        [Test]
        public void Index_WhenCalled_ReturnsListOfCoverTypes()
        {
            var itemsList = new List<CoverType>()
        {
            new CoverType{Id = 1,Name = "item 1"},
            new CoverType(){Id=2,Name="item 2"}

        };
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(u => u.CoverType.GetAll(null,null)).Returns(itemsList);
            var controller = new CoverTypeController(unitOfWork.Object);

            var result = controller.Index();
            var model = ((ViewResult)result).Model as List<CoverType>;

            Assert.That(model.Count == 2);

        }

        [Test]
        public void Create_WhenCalled_AddsNewCoverType()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var controller = new CoverTypeController(unitOfWork.Object);
            var mockTempData = new Mock<ITempDataDictionary>();
            controller.TempData = mockTempData.Object;
            unitOfWork.Setup(u => u.CoverType.Add(It.IsAny<CoverType>()));

            controller.Create(new CoverType());

            unitOfWork.Verify(u => u.CoverType.Add(It.IsAny<CoverType>()), Times.Once);

        }


        [Test]
        public void DeleteConfirm_CoverTypeToDeleteIsNull_ReturnsNotFOund()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var coverType = new CoverType() { Id = 1, Name = "sad"};
            unitOfWork.Setup(u => u.CoverType.GetFirstOrDefault(uw => uw.Id == 1, null))
                .Returns(coverType);
            var controller = new CoverTypeController(unitOfWork.Object);


            var result = controller.DeleteConfirm(1);

            Assert.IsInstanceOf<NotFoundResult>(result);

        }
        [Test]
        public void Edit_IdNull_ReturnsNotFound()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var controller = new CoverTypeController(unitOfWork.Object);

            var result = controller.Edit(0);

            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Edit_CoverTypeNull_ReturnsNotFound()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var controller = new CoverTypeController(unitOfWork.Object);

            unitOfWork.Setup(u => u.CoverType.GetFirstOrDefault(uw => uw.Id == 1, null))
                .Returns((CoverType)null);

            var result = controller.Edit(1);

            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Update_WhenCalled_UpdatesCoverType()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var controller = new CoverTypeController(unitOfWork.Object);
            var mockTempData = new Mock<ITempDataDictionary>();
            controller.TempData = mockTempData.Object;
            unitOfWork.Setup(u => u.CoverType.Update(It.IsAny<CoverType>()));




            //CoverType coverType = new CoverType() { Id = 1 };

            controller.Edit(It.IsAny<CoverType>());

            unitOfWork.Verify(u => u.CoverType.Update(It.IsAny<CoverType>()), Times.Once);
        }


    }
}
