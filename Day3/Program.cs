using System;
using System.Globalization;

namespace ModernBankingSystem
{
    public class AccountEventArgs : EventArgs
    {
        public decimal Amount { get; }
        public decimal CurrentBalance { get; }
        public DateTime Timestamp { get; }
        public string TransactionId { get; }

        public AccountEventArgs(decimal amount, decimal currentBalance)
        {
            Amount = amount;
            CurrentBalance = currentBalance;
            Timestamp = DateTime.UtcNow;
            TransactionId = Guid.NewGuid().ToString("N");
        }
    }

    public class InsufficientFundsException : Exception
    {
        public decimal AttemptedAmount { get; }
        public decimal CurrentBalance { get; }

        public InsufficientFundsException(decimal attempted, decimal current)
            : base($"Insufficient funds for withdrawal of {attempted.ToString("C", new CultureInfo("en-US"))}. Current balance: {current.ToString("C", new CultureInfo("en-US"))}")
        {
            AttemptedAmount = attempted;
            CurrentBalance = current;
        }
    }

    public class BankAccount
    {
        private decimal _balance;
        private readonly string _accountId;
        private readonly decimal _overdraftLimit;

        public event EventHandler<AccountEventArgs> OnDeposit;
        public event EventHandler<AccountEventArgs> OnWithdrawal;
        public event EventHandler<AccountEventArgs> OnBalanceFalls;
        public event EventHandler<AccountEventArgs> OnLargeTransaction;

        private const decimal LargeTransactionThreshold = 10000m;
        private const decimal LowBalanceThreshold = 100m;

        public BankAccount(decimal initialBalance = 0, decimal overdraftLimit = 0)
        {
            _accountId = Guid.NewGuid().ToString("N");
            _balance = initialBalance;
            _overdraftLimit = overdraftLimit;
        }

        public async Task DepositAsync(decimal amount)
        {
            try
            {
                ValidateAmount(amount);

                await Task.Delay(100); // Simulating network delay
                _balance += amount;

                var eventArgs = new AccountEventArgs(amount, _balance);
                OnDeposit?.Invoke(this, eventArgs);

                if (amount >= LargeTransactionThreshold)
                {
                    OnLargeTransaction?.Invoke(this, eventArgs);
                }
            }
            catch (Exception ex)
            {
                LogError($"Deposit failed: {ex.Message}");
                throw;
            }
        }

        public async Task WithdrawAsync(decimal amount)
        {
            try
            {
                ValidateAmount(amount);
                ValidateWithdrawal(amount);

                await Task.Delay(100); // Simulating network delay
                _balance -= amount;

                var eventArgs = new AccountEventArgs(amount, _balance);
                OnWithdrawal?.Invoke(this, eventArgs);

                if (_balance < LowBalanceThreshold)
                {
                    OnBalanceFalls?.Invoke(this, eventArgs);
                }

                if (amount >= LargeTransactionThreshold)
                {
                    OnLargeTransaction?.Invoke(this, eventArgs);
                }
            }
            catch (Exception ex)
            {
                LogError($"Withdrawal failed: {ex.Message}");
                throw;
            }
        }

        private void ValidateAmount(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be positive", nameof(amount));
            }
        }

        private void ValidateWithdrawal(decimal amount)
        {
            if (_balance - amount < -_overdraftLimit)
            {
                throw new InsufficientFundsException(amount, _balance);
            }
        }

        private void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[{DateTime.UtcNow}] ERROR: {message}");
            Console.ResetColor();
        }

        public decimal GetBalance() => _balance;
    }

    public class BankingDemo
    {
        public static async Task Main()
        {
            try
            {
                // Set culture to ensure proper currency formatting
                CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");

                var account = new BankAccount(1000m, 100m);

                // Setting up event handlers
                account.OnDeposit += (sender, e) =>
                    Console.WriteLine($"[DEPOSIT] Amount: {e.Amount.ToString("C", new CultureInfo("en-US"))} | New Balance: {e.CurrentBalance.ToString("C", new CultureInfo("en-US"))} | Transaction ID: {e.TransactionId}");

                account.OnWithdrawal += (sender, e) =>
                    Console.WriteLine($"[WITHDRAWAL] Amount: {e.Amount.ToString("C", new CultureInfo("en-US"))} | New Balance: {e.CurrentBalance.ToString("C", new CultureInfo("en-US"))} | Transaction ID: {e.TransactionId}");

                account.OnBalanceFalls += (sender, e) =>
                    Console.WriteLine($"[LOW BALANCE ALERT] Current Balance is {e.CurrentBalance.ToString("C", new CultureInfo("en-US"))}");

                account.OnLargeTransaction += (sender, e) =>
                    Console.WriteLine($"[LARGE TRANSACTION ALERT] Amount: {e.Amount.ToString("C", new CultureInfo("en-US"))} | Transaction ID: {e.TransactionId}");

                // Demonstrating various scenarios
                await account.DepositAsync(500m);
                await account.WithdrawAsync(200m);
                await account.DepositAsync(15000m); // Large transaction
                await account.WithdrawAsync(16000m); // Large transaction + Low balance
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"[ERROR] Transaction Failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Unexpected error: {ex.Message}");
            }
        }
    }
}