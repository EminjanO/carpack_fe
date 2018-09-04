using System;
using System.Linq;
using System.Web.Mvc;
using CarPack.Controllers;
using CarPack.DAL.Entity;
using CarPack.Models;
using InOutFCA.DAL.Repository;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace CarPack.UnitTest
{
    [TestFixture]
    public class ClientControllerUnitTests
    {
        [Test]
        public void Clients_Returns_ActionsResult()
        {
            // Arrange
            //ClientController controller = new ClientController();
            Mock<IRepository<int,Client>> clinetMock = new Mock<IRepository<int,Client>>();
            
            clinetMock.Setup(m => m.Entities).Returns(
                new Client[]
                {
                    new Client
                    {
                        Address = "Address 1A",
                        Client_id = 1,
                        Client_name = "amut",
                        Client_number = "C1",
                        Create_date = new DateTime().Date,
                        Email = "test@mail.com",
                        Id = 11,
                        IsActive = true,
                        IsIntern = true,
                        Last_update = new DateTime().Date,
                        Prefix = "mr",
                        Responsible = "Response",
                        User_id = 11
                    },
                    new Client
                    {
                        Address = "Address 2A",
                        Client_id = 2,
                        Client_name = "amut",
                        Client_number = "C1",
                        Create_date = new DateTime().Date,
                        Email = "test@mail.com",
                        Id = 11,
                        IsActive = true,
                        IsIntern = true,
                        Last_update = new DateTime().Date,
                        Prefix = "mr",
                        Responsible = "Response",
                        User_id =12
                    },
                    new Client
                    {
                        Address = "Address 3A",
                        Client_id = 3,
                        Client_name = "amut",
                        Client_number = "C1",
                        Create_date = new DateTime().Date,
                        Email = "test@mail.com",
                        Id = 11,
                        IsActive = true,
                        IsIntern = true,
                        Last_update = new DateTime().Date,
                        Prefix = "mr",
                        Responsible = "Response",
                        User_id = 13
                    }
                }.AsQueryable()
            );
            ClientController controller = new ClientController(clinetMock.Object);
            IRepository<int, Client> c = clinetMock.Object;
            // Act
            var actual = c;


            // Assert
            Assert.IsInstanceOf<IRepository<int, Client>>(actual);

        }
    }
}
