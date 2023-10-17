export const Data = {
    payment: {
        creditCardNumber: "4925000000000004",
        creditCardNumber3DS: "4761739001010416",
        creditCardCvc: "210",
        creditCardExpirationMonth: creditCardExpirationDate().slice(5, 7),
        creditCardExpirationYear: creditCardExpirationDate().slice(2, 4),
        invoiceEmail: "leia.ahlstrom@payex.com",
        invoicePhone: "+46739000001",
        invoiceSsn: "971020-2392",
        swishPhone: "0739000001",
        trustlyFirstName: "Leia",
        trustlyLastName: "Ahlström"
        
    }
}

export function creditCardExpirationDate() {
    let now = new Date();
    const date = new Date(now.getFullYear() + 1, now.getMonth() + 3, 1);
    return date.toISOString().substring(0, 10);
}
