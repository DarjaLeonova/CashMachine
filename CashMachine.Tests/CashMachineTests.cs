using CashMachine.Exceptions;
using FluentAssertions;

namespace CashMachine.Tests
{
    [TestClass]
    public class CashMachineTest
    {
        private CashMachine _cashMachine;
        private int[] _banknotes = { 10, 20, 5 };
        private int _currentAmountLessThenRealAmountMock;

        [TestInitialize]
        public void SetUp()
        {
            _currentAmountLessThenRealAmountMock = _banknotes.Sum() - 10;
            _cashMachine = new CashMachine();
            _cashMachine.Insert(_banknotes);
        }

        [TestMethod]
        public void Withdraw_ShouldBeSuccessfulResult()
        {
            var withdrawn = _cashMachine.WithDraw(15);

            Assert.AreEqual(withdrawn, 15);
        }
        [TestMethod]
        public void Withdraw_WhenRequestedAmountIsBiggerThenAmmount_ShouldThrowBalanceLessThanRequestedAmountException()
        {
            var withdrawn = 100;

            Action action = () => _cashMachine.WithDraw(withdrawn);
            action.Should().Throw<BalanceLessThanRequestedAmountException>()
               .WithMessage($"Your balance is less then requested {withdrawn} for withdrawn");
        }

        [TestMethod]
        public void Insert_WhenAcceptSupportedBanknotes_ShouldNotThrowException()
        {
            var banknotesForInput = new int[] { 5, 10, 20, 50, 100 };

            Action action = () => _cashMachine.Insert(banknotesForInput);
            action.Should().NotThrow();
           
        }

        [TestMethod]
        public void Insert_WhenAcceptNotSupportedBanknotes_ShouldThrowException()
        {
            var notSupportedBanknote = 15;
            var banknotesForInput = new int[] { notSupportedBanknote, 10, 20, 50, 100 };

            Action action = () => _cashMachine.Insert(banknotesForInput);
            action.Should().Throw<BanknoteIsNotSupportedException>()
                .WithMessage($"{notSupportedBanknote} is Not Supported");
        }
    }
}