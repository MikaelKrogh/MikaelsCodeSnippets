using BankUnitTest;
namespace BankUnitTests
{
    public class Tests
    {
        private BankAccount accountOne;
        [SetUp]
        public void Setup()
        {
            //ARRANGE
            accountOne = new BankAccount(1000);
        }


        [Test]
        public void AddingFundsUpdatesBalance()
        {
            //ACT
            accountOne.AddMoney(500);

            //ASSERT
            Assert.AreEqual(1500, accountOne.Balance);
        }
        [Test]
        public void WithDrawFundsUpdatesBalance()
        {

            //ACT
            accountOne.WithdrawMoney(600);

            //ASSERT
            Assert.AreEqual(400, accountOne.Balance);
        }

        [Test]
        public void TransferFundsBetweenTwoAccounts()
        {
            //ARRANGE
            var accountTwo = new BankAccount(2000);

            //ACT
            accountOne.TranferFundTo(accountTwo, 500);

            //ASSERT
            Assert.AreEqual(500, accountOne.Balance);
            Assert.AreEqual(2500, accountTwo.Balance);
        }
        [Test]
        public void ThrowExceptionWhenAddingNegativeMoney()
        {
            //ARRANGE
            var account = new BankAccount();

            //ACT ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => account.AddMoney(-500));
        }
    }
}