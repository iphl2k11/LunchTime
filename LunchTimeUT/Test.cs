using NUnit.Framework;
using System;
using Moq;
using LunchTime;

namespace LunchTimeUT
{
	[TestFixture ()]
	public class Test
	{
		string testId = "123";
		string testEmailValid = "john.doe@gmail.com";
		string appUidValid = "abc1234567890";

		Mock<IUidGenerator> uidGeneratorMock = new Mock<IUidGenerator> ();
		Mock<IDbInterface> dbInterfaceMock = new Mock<IDbInterface>();
		Mock<IClientDataValidator> clientDataValidatorMock =  new Mock<IClientDataValidator>();

		LunchTime.Main sut; 

		[SetUp]
		public void Init()
		{
			sut = new LunchTime.Main(uidGeneratorMock.Object, 
								     dbInterfaceMock.Object, 
									 clientDataValidatorMock.Object);
		}

		[Test ()]
		public void RegisterProviderSuccessfullScenario ()
		{
			clientDataValidatorMock.Setup (x => x.validateEmail (It.Is<string> (i => i.Equals(testEmailValid)))).Returns (true);
			uidGeneratorMock.Setup (x => x.GenerateProviderId ()).Returns (testId);
			dbInterfaceMock.Setup (x => x.InsertProvider (
				It.Is<string> (i => i.Equals(testId)),
				It.Is<string> (i => i.Equals(testEmailValid)),
				It.Is<string> (i => i.Equals(appUidValid))
			)).Returns(true);

			Assert.AreSame(testId, sut.RegisterProvider(appUidValid, testEmailValid));

			clientDataValidatorMock.VerifyAll ();
			uidGeneratorMock.VerifyAll ();
			dbInterfaceMock.VerifyAll ();
		}

//				[Test ()]
//				public void RegisterConsumerEmptyParameters ()
//				{
//					//This should throw an exception
//					uidGeneratorMock.Setup (x => x.GenerateConsumerId ()).Returns (testId);
//					Assert.AreSame(testId, sut.RegisterConsumer("",""));
//				}
	}
}