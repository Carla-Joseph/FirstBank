# FirstBank

Objectives:

- Practice control structures.
- Practice data structures.
- Practice working with user data.
- Practice with LINQ.
- Practice with OOP concepts.
- Practice working with files.

Requirements:

- Create a console app that allows a user to manage a banking account.

- As user should be able to make transactions against their accounts.

- The transaction information should be stored in a file, using a CSV(or JSON) format to record the data.

- Balances will be computed by determining the cumulative effect of all the transactions in order. For instance, if a user deposits 10 to their savings account and then withdraws 8 from their savings account, their balance is computed as 2.

Explorer Mode:

- The app should load past transactions from a file at start up.
- As a user I should be able to see the balances in my saving and checking account when the program first starts.
- Never allow withdrawing or depositing more money than allowed. That is, we cannot allow our accounts to go negative.
- When prompting for an amount to deposit or withdraw always ensure the amount is positive.
- As a user I should be able to deposit funds to my savings account.
- As a user I should be able to deposit funds to my checking account.
- As a user I should be able to withdraw funds from my savings account.
- As a user I should be able to withdraw funds from my checking account.
- As a user I should be able to see my account balances.
- The app should, after each transaction, write all the transactions to a file using a standard format.
