# BankModel

## Models
1. Bank - represents a banking institution with multiple accounts
2. Account - represents an individual account owned by an Owner, abstract class can be inherited
> Derived Classes:
> - Individual Investment Account
> - Checking Account 
> - Corporate Investment Account
3. Owner - represents the owner of an account, can have multiple accounts
4. Withdrawal Request - represents a request to withdraw from an account, request validated by Account.ProcessTransaction
5. Deposit Request - represents a request to deposit from an account, request validated by Account.ProcessTransaction
6. Transfer Request - represents a request to transfer money between accounts
7. Request Validation Rules:
> - Overdraft Validation Rule - represents a rule that disallows overdrafts
> - Withdrawal Limit Validation Rule - represents a rule that sets a limit for withdrawal requests
---
## Interfaces
1. IBank
2. IAccount
3. IOwner
4. ITransactionRequest
5. ITransferRequest
6. IRequestValidationRule
