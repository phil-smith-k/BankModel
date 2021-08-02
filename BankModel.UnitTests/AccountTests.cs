using BankModel.Core.Entities.Accounts;
using BankModel.Core.Entities.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankModel.UnitTests
{
    [TestClass]
    public class AccountTests
    {
        // Initial Balance
        [TestMethod]
        public void CreateCheckingAccount_WithInitialBalance_AccountBalance_Equals_InitialBalance()
        {
            var initialBalance = 100;
            var account = new CheckingAccount(initialBalance);

            Assert.AreEqual(initialBalance, account.Balance);
        }

        [TestMethod]
        public void CreateIndividualInvestmentAccount_WithInitialBalance_AccountBalance_Equals_InitialBalance()
        {
            var initialBalance = 100;
            var account = new IndividualInvestmentAccount(initialBalance);

            Assert.AreEqual(initialBalance, account.Balance);
        }

        [TestMethod]
        public void CreateCorporateInvestmentAccount_WithInitialBalance_AccountBalance_Equals_InitialBalance()
        {
            var initialBalance = 100;
            var account = new CorporateInvestmentAccount(initialBalance);

            Assert.AreEqual(initialBalance, account.Balance);
        }


        // Overdraft
        [TestMethod]
        public void ProcessWithdrawal_ForCheckingAccount_Overdraft_DoesNotWithdraw()
        {
            var initialBalance = 100;
            var withdrawalAmount = 500;
            var account = new CheckingAccount(initialBalance);
            var withdrawalRequest = new WithdrawalRequest(withdrawalAmount);

            var isSuccess = account.ProcessTransaction(withdrawalRequest);

            Assert.IsFalse(isSuccess);
            Assert.AreEqual(initialBalance, account.Balance);
        }

        [TestMethod]
        public void ProcessWithdrawal_ForIndividualInvestmentAccount_Overdraft_DoesNotWithdraw()
        {
            var initialBalance = 100;
            var withdrawalAmount = 500;
            var account = new IndividualInvestmentAccount(initialBalance);
            var withdrawalRequest = new WithdrawalRequest(withdrawalAmount);

            var isSuccess = account.ProcessTransaction(withdrawalRequest);

            Assert.IsFalse(isSuccess);
            Assert.AreEqual(initialBalance, account.Balance);
        }

        [TestMethod]
        public void ProcessWithdrawal_ForCorporateInvestmentAccount_Overdraft_DoesNotWithdraw()
        {
            var initialBalance = 100;
            var withdrawalAmount = 500;
            var account = new CorporateInvestmentAccount(initialBalance);
            var withdrawalRequest = new WithdrawalRequest(withdrawalAmount);

            var isSuccess = account.ProcessTransaction(withdrawalRequest);

            Assert.IsFalse(isSuccess);
            Assert.AreEqual(initialBalance, account.Balance);
        }


        // Individual Investment Acccount Withdrawal Limit
        [TestMethod]
        public void ProcessWithdrawal_ForIndividualInvestmentAccount_GreaterThanLimit_DoesNotDeposit()
        {
            var withdrawalAmount = 1200;
            var initialBalance = 2000;
            var account = new IndividualInvestmentAccount(initialBalance);
            var withdrawalRequest = new WithdrawalRequest(withdrawalAmount);

            var isSuccess = account.ProcessTransaction(withdrawalRequest);

            Assert.IsFalse(isSuccess);
            Assert.AreEqual(initialBalance, account.Balance);
        }


        // Process Withdrawal
        [TestMethod]
        public void ProcessWithdrawal_ForCheckingAccount_Valid_WithdrawalSuccessful()
        {
            var initialBalance = 1000;
            var withdrawalAmount = 500;
            var account = new CheckingAccount(initialBalance);
            var withdrawalRequest = new WithdrawalRequest(withdrawalAmount);

            var isSuccess = account.ProcessTransaction(withdrawalRequest);

            Assert.IsTrue(isSuccess);
            Assert.AreEqual(initialBalance - withdrawalAmount, account.Balance);
        }

        [TestMethod]
        public void ProcessWithdrawal_ForIndividualInvestmentAccount_Valid_WithdrawalSuccessful()
        {
            var initialBalance = 1000;
            var withdrawalAmount = 500;
            var account = new IndividualInvestmentAccount(initialBalance);
            var withdrawalRequest = new WithdrawalRequest(withdrawalAmount);

            var isSuccess = account.ProcessTransaction(withdrawalRequest);

            Assert.IsTrue(isSuccess);
            Assert.AreEqual(initialBalance - withdrawalAmount, account.Balance);
        }

        [TestMethod]
        public void ProcessWithdrawal_ForCorporateInvestmentAccount_Valid_WithdrawalSuccessful()
        {
            var initialBalance = 1000;
            var withdrawalAmount = 500;
            var account = new CorporateInvestmentAccount(initialBalance);
            var withdrawalRequest = new WithdrawalRequest(withdrawalAmount);

            var isSuccess = account.ProcessTransaction(withdrawalRequest);

            Assert.IsTrue(isSuccess);
            Assert.AreEqual(initialBalance - withdrawalAmount, account.Balance);
        }


        // Process Deposit
        [TestMethod]
        public void ProcessDeposit_ForCheckingAccount_Valid_DepositSuccessful()
        {
            var initialBalance = 1000;
            var depositAmount = 500;
            var account = new CheckingAccount(initialBalance);
            var depositRequest = new DepositRequest(depositAmount);

            var isSuccess = account.ProcessTransaction(depositRequest);

            Assert.IsTrue(isSuccess);
            Assert.AreEqual(initialBalance + depositAmount, account.Balance);
        }

        [TestMethod]
        public void ProcessDeposit_ForIndividualInvestmentAccount_Valid_DepositSuccessful()
        {
            var initialBalance = 1000;
            var depositAmount = 500;
            var account = new IndividualInvestmentAccount(initialBalance);
            var depositRequest = new DepositRequest(depositAmount);

            var isSuccess = account.ProcessTransaction(depositRequest);

            Assert.IsTrue(isSuccess);
            Assert.AreEqual(initialBalance + depositAmount, account.Balance);
        }

        [TestMethod]
        public void ProcessDeposit_ForCorporateInvestmentAccount_Valid_DepositSuccessful()
        {
            var initialBalance = 1000;
            var depositAmount = 500;
            var account = new CorporateInvestmentAccount(initialBalance);
            var depositRequest = new DepositRequest(depositAmount);

            var isSuccess = account.ProcessTransaction(depositRequest);

            Assert.IsTrue(isSuccess);
            Assert.AreEqual(initialBalance + depositAmount, account.Balance);
        }


        // Process Transfer Valid
        [TestMethod]
        public void ProcessTransfer_ToCheckingAccountFromIndividualInvestment_Valid_TransferSuccessful()
        {
            var initialBalance = 500;
            var transferAmount = 400;
            var transferRequest = new TransferRequest(transferAmount);
            var checkingAccount = new CheckingAccount(initialBalance);
            var individualInvestmentAccount = new IndividualInvestmentAccount(initialBalance);

            var isSuccess = checkingAccount.ProcessTransfer(individualInvestmentAccount, transferRequest);

            Assert.IsTrue(isSuccess);
            Assert.AreEqual(initialBalance + transferAmount, checkingAccount.Balance);
            Assert.AreEqual(initialBalance - transferAmount, individualInvestmentAccount.Balance);
        }

        [TestMethod]
        public void ProcessTransfer_ToCorporateFromChecking_Valid_TransferSuccessful()
        {
            var initialBalance = 500;
            var transferAmount = 400;
            var transferRequest = new TransferRequest(transferAmount);
            var corporateAccount = new CorporateInvestmentAccount(initialBalance);
            var checkingAccount = new CheckingAccount(initialBalance);

            var isSuccess = corporateAccount.ProcessTransfer(checkingAccount, transferRequest);

            Assert.IsTrue(isSuccess);
            Assert.AreEqual(initialBalance + transferAmount, corporateAccount.Balance);
            Assert.AreEqual(initialBalance - transferAmount, checkingAccount.Balance);
        }


        // Transfer With Overdraft
        [TestMethod]
        public void ProcessTransfer_ToIndividualFromChecking_Overdraft_TransferNotSuccessful()
        {
            var initialBalance = 500;
            var transferAmount = 600;
            var transferRequest = new TransferRequest(transferAmount);
            var individualAccount = new IndividualInvestmentAccount(initialBalance);
            var checkingAccount = new CheckingAccount(initialBalance);

            var isSuccess = individualAccount.ProcessTransfer(checkingAccount, transferRequest);

            Assert.IsFalse(isSuccess);
            Assert.AreEqual(initialBalance, individualAccount.Balance);
            Assert.AreEqual(initialBalance, checkingAccount.Balance);
        }


        // Transfer Over Individual Investment Account Withdrawal Limit
        [TestMethod]
        public void ProcessTransfer_ToCorporateFromIndividual_GreaterThanLimit_TransferNotSuccessful()
        {
            var transferAmount = 1200;
            var initialBalance = 2000;
            var individualInvestmentAccount = new IndividualInvestmentAccount(initialBalance);
            var corporateInvestmentAccount = new CorporateInvestmentAccount(initialBalance);
            var withdrawalRequest = new TransferRequest(transferAmount);

            var isSuccess = corporateInvestmentAccount.ProcessTransfer(individualInvestmentAccount, withdrawalRequest);

            Assert.IsFalse(isSuccess);
            Assert.AreEqual(initialBalance, individualInvestmentAccount.Balance);
            Assert.AreEqual(initialBalance, corporateInvestmentAccount.Balance);
        }
    }
}
