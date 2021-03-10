class Bank {
    static noCustomerWithThisID = "We have no customer with this ID!";
    static alreadyCustomer = `${customer.firstName} ${customer.lastName} is already our customer!`;
    static madeDeposit = `${customer.firstName} ${customer.lastName} made deposit of ${amount}$!`;
    static notEnoughAmount = `${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`;
    static WithdrewAount = `${customer.firstName} ${customer.lastName} withdrew ${amount}$!`;
    constructor(bankName) {
        this._bankName = bankName;
        this.allCustomers = [];
    }

    newCustomer(customer) {
        if (this.allCustomers.some(c => c.personalId === customer.personalId)) {
            throw new Error(alreadyCustomer)
        }

        customer.totalMoney = 0;
        customer.allTransactions = [];
        this.allCustomers.push(customer);
        return {
            firstName: customer.firstName,
            lastName: customer.lastName,
            personalId: customer.personalId,
        };
    }

    depositMoney(personalId, amount) {
        let customer = this.allCustomers.find(c => c.personalId === personalId);

        if (customer === undefined) {
            throw new Error(noCustomerWithThisID);
        }

        customer["totalMoney"] += amount;
        customer.allTransactions.push(madeDeposit)
        return `${customer.totalMoney}$`;
    }

    withdrawMoney(personalId, amount) {
        let customer = this.allCustomers.find(c => c.personalId === personalId);

        if (customer === undefined) {
            throw new Error(noCustomerWithThisID);
        }

        if (customer.totalMoney < amount) {
            throw new Error(notEnoughAmount);
        }

        customer.totalMoney -= amount;
        customer.allTransactions.push(WithdrewAmount)

        return `${customer.totalMoney}$`;
    }

    customerInfo(personalId) {
        let customer = this.allCustomers.find(c => c.personalId === personalId);

        if (customer === undefined) {
            throw new Error(noCustomerWithThisID);
        }

        let result = [
            `Bank name: ${this._bankName}`,
            `Customer name: ${customer.firstName} ${customer.lastName}`,
            `Customer ID: ${customer.personalId}`,
            `Total Money: ${customer.totalMoney}$`,
            `Transactions:`
        ]

        for (let index = customer.allTransactions.length; index > 0; index--) {
            const element = customer.allTransactions[index - 1];
            result.push(`${index}. ${element}`);
        }

        return result.join("\n");

    }
}

// TESTING
let bank = new Bank("SoftUni Bank");

console.log(bank.newCustomer({ firstName: "Svetlin", lastName: "Nakov", personalId: 6233267 }));
console.log(bank.newCustomer({ firstName: "Mihaela", lastName: "Mileva", personalId: 4151596 }));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596, 555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));